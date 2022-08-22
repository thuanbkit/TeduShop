using AutoMapper;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.infrastructure.Core;
using TeduShop.Web.Models;
using TeduShop.Web.infrastructure.Extension;

namespace TeduShop.Web.Api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        private IPostCategoryService _postCategoryService;

        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
             {
                 HttpResponseMessage response = null;

                 var listCategory = _postCategoryService.GetAll();
                 var listCategoryVm = Mapper.Map<List<PostCategoryViewModel>>(listCategory);
                 response = request.CreateResponse(HttpStatusCode.OK, listCategoryVm);

                 return response;
             });
        }

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    PostCategory newPostCategory = new PostCategory();
                    newPostCategory.updatePostCategory(postCategoryVm);
                    var category = _postCategoryService.Add(newPostCategory);
                    _postCategoryService.Save();
                    response = request.CreateResponse(HttpStatusCode.Created, category);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postCategoryDb = _postCategoryService.GetById(postCategoryVm.ID);
                    postCategoryDb.updatePostCategory(postCategoryVm);
                    _postCategoryService.Update(postCategoryDb);
                    _postCategoryService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
    }
}