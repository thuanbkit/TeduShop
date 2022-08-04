using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        IDbFactory dbFactory;
        IPostCategoryRepository objRepositoty;
        IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepositoty = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var list = objRepositoty.GetAll();
            Assert.IsNotNull(list);
        }


        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test category";
            category.Alias = "test-category";
            category.Status = true;
            var result = objRepositoty.Add(category);
            unitOfWork.Commit();
            Assert.IsNotNull(result);
            //Assert.AreEqual(1, result.ID);
            
        }
    }
}