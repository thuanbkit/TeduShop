using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IMenuRepositoryGroup
    {
    }

    public class MenuRepositoryGroup : RepositoryBase<Menu>, IMenuRepositoryGroup
    {
        public MenuRepositoryGroup(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}