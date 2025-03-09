namespace task_cli
{
    public interface ITaskService
    {
        void AddTask(string description);
        void DeleteTask(int id);
        void GetDoneTasks();
        void GetInProgessTasks();
        int GetLastId();
        void GetTasks(Status? status = null);
        void GetTodoTasks();
        void MarkTaskAsDone(int id);
        void MarkTaskAsInProgess(int id);
        string TaskToJson(Task task);
        void UpdateTask(int id, string? description = null, Status? status = null);
    }
}