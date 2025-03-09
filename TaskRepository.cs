using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace task_cli
{
    public class TaskRepository : ITaskRepository
    {
        private readonly string _filePath;
        public TaskRepository(string filePath)
        {
            _filePath = filePath;
        }
        public string GetDirectory()
        {
            return _filePath;
        }
        public void AddTask(Task task)
        {
            var tasks = GetTasks();
            tasks.Add(task);

            SaveTasks(tasks);
        }

        public void UpdateTask(int id, Task task)
        {
            var tasks = GetTasks();
            var storedTask = tasks.Find(t => t.Id == id) ?? throw new NullReferenceException($"The task: {id} doesn't exist.");

            storedTask.Id = task.Id;
            storedTask.Description = task.Description;
            storedTask.Status = task.Status;
            storedTask.UpdatedAt = task.UpdatedAt;

            SaveTasks(tasks);
        }

        private void SaveTasks(List<Task> tasks)
        {
            File.WriteAllText(
                _filePath, JsonSerializer.Serialize(
                    tasks, new JsonSerializerOptions { WriteIndented = true }
                    )
                );
        }

        public void DeleteTask(int id)
        {
            var tasks = GetTasks();
            var taskToRemove = tasks.FirstOrDefault(t => t.Id == id);
            if (taskToRemove == null)
                Console.WriteLine($"Task '{id}' not found.");
            else
                tasks.Remove(taskToRemove);

            SaveTasks(tasks);

        }

        public Task GetTaskById(int id)
        {
            return GetTasks().FirstOrDefault(t => t.Id == id) ?? throw new NullReferenceException($"Task {id} not found");
        }

        public List<Task> GetTasks()
        {
            if (!File.Exists(_filePath))
                return [];

            string file = File.ReadAllText(_filePath);

            try
            {
                return JsonSerializer.Deserialize<List<Task>>(file) ?? [];
            }
            catch (JsonException)
            {
                Console.WriteLine($"Error parsing JSON from {_filePath}. Returning empty list.");
                return [];
            }
            catch (Exception e)
            {
                Console.WriteLine($"An unexpected error ocurred: {e.Message}");
                return [];
            }
        }

        public List<Task> GetTasksByStatus(Status? status)
        {
            return GetTasks().Where(t => t.Status == status).ToList();
        }
    }
}
