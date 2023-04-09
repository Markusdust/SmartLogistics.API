using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.Repositories
{
    public class SqlKundenRepository : IKundenRepository
    {
        private readonly SmartLogisticsContext context;

        public SqlKundenRepository(SmartLogisticsContext context)
        {
            this.context = context;
        }



        public List<Kunde> GetKunden()
        {
            return context.Kunden.ToList();
        }
    }
}
