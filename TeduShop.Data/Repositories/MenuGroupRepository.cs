using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IMenuRepositoryGroup : IRepository<MenuGroup>
    {
    }

    public class MenuRepositoryGroup : RepositoryBase<MenuGroup>, IMenuRepositoryGroup
    {
        public MenuRepositoryGroup(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}