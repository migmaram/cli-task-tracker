
namespace task_cli
{
    public interface ITaskRepository
    {
        void AddTask(Task task);
        void DeleteTask(int id);
        string GetDirectory();
        Task GetTaskById(int id);
        List<Task> GetTasks();
        List<Task> GetTasksByStatus(Status? status);
        void UpdateTask(int id, Task task);
    }
}