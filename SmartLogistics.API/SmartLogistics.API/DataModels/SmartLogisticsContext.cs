using Microsoft.EntityFrameworkCore;

namespace SmartLogistics.API.DataModels
{
    public class SmartLogisticsContext : DbContext
    {
        public SmartLogisticsContext(DbContextOptions<SmartLogisticsContext> options) : base(options)
        {
            
        }
    }
}
