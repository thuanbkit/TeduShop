using TeduShop.Data.Infrastructure;
using TeduShop.Model.Models;

namespace TeduShop.Data.Repositories
{
    public interface IVisitorStatisticRepository : IRepository<VisitorStatistic>
    {
        int GetOnline(string alias);
    }

    public class VisitorStatisticRepository : RepositoryBase<VisitorStatistic>, IVisitorStatisticRepository
    {
        public VisitorStatisticRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public int GetOnline(string alias)
        {
            throw new System.NotImplementedException();
        }
    }
}