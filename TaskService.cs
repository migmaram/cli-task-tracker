using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace cli_task_tracker
{
    public class TaskService : ITaskService
    {
        private ITaskRepository _repository;
        public TaskService(TaskRepository repository)
        {
            _repository = repository;
        }

        public string TaskToJson(Task task)
        {
            return JsonSerializer.Serialize(task);
        }

        public int GetLastId()
        {
            return _repository.GetTasks().OrderByDescending(t => t.Id).FirstOrDefault()?.Id ?? 0;
        }

        public void AddTask(string description)
        {
            _repository.AddTask(
                new Task
                {
                    Id = GetLastId() + 1,
                    Description = description,
                    Status = Status.Todo,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });
        }

        public void UpdateTask(int id, string? description = null, Status? status = null)
        {
            var storedTask = _repository.GetTaskById(id);

            _repository.UpdateTask(id,
                new Task
                {
                    Id = storedTask.Id,
                    Description = description ?? storedTask.Description,
                    Status = status ?? storedTask.Status,
                    CreatedAt = storedTask.CreatedAt,
                    UpdatedAt = DateTime.Now
                });
        }
        public void MarkTaskAsDone(int id)
        {
            UpdateTask(id, status: Status.Done);
        }

        public void MarkTaskAsInProgess(int id)
        {
            UpdateTask(id, status: Status.InProgress);
        }

        public void DeleteTask(int id)
        {
            _repository.DeleteTask(id);
        }

        public void GetTasks(Status? status = null)
        {
            var tasks = status == null ? _repository.GetTasks() : _repository.GetTasksByStatus(status);

            foreach (var task in tasks)
            {
                Console.WriteLine(task.Id);
                Console.WriteLine(task.Description);
                Console.WriteLine(task.Status);
                Console.WriteLine(task.CreatedAt);
                Console.WriteLine(task.UpdatedAt);
                Console.WriteLine();
            }
        }
        public void GetTodoTasks()
        {
            GetTasks(Status.Todo);
        }
        public void GetInProgessTasks()
        {
            GetTasks(Status.InProgress);
        }
        public void GetDoneTasks()
        {
            GetTasks(Status.Done);
        }
    }

}

