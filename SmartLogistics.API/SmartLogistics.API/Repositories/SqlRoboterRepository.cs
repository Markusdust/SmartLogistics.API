using Microsoft.EntityFrameworkCore;
using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.Repositories
{
    public class SqlRoboterRepository : IRoboterRepository
    {
        private readonly SmartLogisticsContext context;

        public SqlRoboterRepository(SmartLogisticsContext context)
        {
            this.context = context;
        }

        public async Task<List<Roboter>> GetAllRoboterAsync()
        {
            return await context.Roboter.ToListAsync();
        }

        public async Task<Roboter> GetRoboterAsync(Guid roboterId)
        {
            return await context.Roboter.FirstOrDefaultAsync(x => x.Id == roboterId);
        }

        public async Task<bool> Exists(Guid roboterId)
        {
            return await context.Roboter.AnyAsync(x => x.Id == roboterId);
        }

        public async Task<Roboter> UpdateRoboter(Guid roboterId, Roboter request)
        {
            var existingRoboter = await GetRoboterAsync(roboterId);
            if (existingRoboter != null)
            {
                existingRoboter.Name = request.Name;

                await context.SaveChangesAsync();
                return existingRoboter;
            }

            return null;
        }

        public async Task<Roboter> DeleteRoboter(Guid roboterId)
        {
            var roboter = await GetRoboterAsync(roboterId);
            if (roboter != null)
            {
                context.Roboter.Remove(roboter);
                await context.SaveChangesAsync();
            }

            return null;
        }

        public async Task<Roboter> AddRoboter(Roboter request)
        {
            var newRoboter = await context.Roboter.AddAsync(request);
            await context.SaveChangesAsync();
            return newRoboter.Entity;
        }

    }
}
