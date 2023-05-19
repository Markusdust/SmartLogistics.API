using SmartLogistics.API.DataModels;

namespace SmartLogistics.API.Repositories
{
    public interface IRoboterRepository
    {
        Task<List<Roboter>> GetAllRoboterAsync();

        Task<Roboter> GetRoboterAsync(Guid roboterId);

        Task<bool> Exists(Guid roboterId);

        Task<Roboter> UpdateRoboter(Guid roboterId, Roboter request);

        Task<Roboter> DeleteRoboter(Guid roboterId);
        Task<Roboter> AddRoboter(Roboter request);
    }
}
