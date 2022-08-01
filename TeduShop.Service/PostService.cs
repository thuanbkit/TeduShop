using TeduShop.Model.Models;
using System.Collections.Generic;
using TeduShop.Data.Repositories;
using TeduShop.Data.Infrastructure;

namespace TeduShop.Service
{
    public interface IPostService
    {
        void Add(Post post);

        void Update(Post post);

        void Delete(int id);

        IEnumerable<Post> GetALl();

        IEnumerable<Post> getALLPaging(string tag, int page, int pageSize, out int totalRow);

        IEnumerable<Post> getAllByTagPaging(int page, int pageSize, out int totalRow);

        Post getByID(int ID);

        void saveChanges();
    }

    public class PostService : IPostService
    {
        private IPostRepository _postRepository;
        private IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Post post)
        {
            _postRepository.Add(post);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetALl()
        {
            return _postRepository.GetAll();
        }

        public IEnumerable<Post> getAllByTagPaging(int page, int pageSize, out int totalRow)
        {
            // Todo : select all post by tag
            return _postRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public IEnumerable<Post> getALLPaging(string tag, int page, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public Post getByID(int ID)
        {
            return _postRepository.GetSingleById(ID);
        }

        public void saveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}