using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TeduShop.Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAlias(string alias);
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Product> GetAlias(string alias)
        {
            return this.DbContext.Products.Where(x => x.Alias == alias);
        }
    }
}