using backend.Models;

namespace backend.Interfaces
{
    public interface ITaskService
    {
        //Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<IEnumerable<TaskItem>> GetLatestAsync();
        Task<TaskItem?> GetByIdAsync(int id);
        Task<TaskItem> AddAsync(TaskItem item);
        Task<bool> MarkAsDoneAsync(int id);
    }
}
