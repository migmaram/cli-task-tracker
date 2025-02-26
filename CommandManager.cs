using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cli_task_tracker
{
    internal class CommandManager
    {
        private readonly ITaskService _service;
        private readonly Dictionary<string, Action<string[]>> _commands;

        public CommandManager(TaskService service)
        {
            _service = service;
            _commands = new Dictionary<string, Action<string[]>>
            {
                { "list", HandleListCommand },
                { "add", HandleAddCommand },
                { "delete", HandleDeleteCommand },
                { "mark-in-progress", HandleMarkInProgressCommand },
                { "mark-done", HandleMarkDoneCommand },
                { "update", HandleUpdateCommand },
                { "?", HandleHelpCommand },
                { "--help", HandleHelpCommand }
            };
        }

        public void Run(string[] args) 
        {
            var command = args[0].ToLower();

            if (_commands.TryGetValue(command, out var action))
            {
                action(args);
            }
            else
            {
                Console.WriteLine("Invalid command.");
            }
        }

        public void HandleListCommand(string[] args)
        {
            if (args.Length == 1)
            {
                _service.GetTasks();
            }
            else if (args.Length == 2)
            {
                string status = args[1].ToLower();
                switch (status)
                {
                    case "todo":
                        _service.GetTodoTasks();
                        break;
                    case "in-progress":
                        _service.GetInProgessTasks();
                        break;
                    case "done":
                        _service.GetDoneTasks();
                        break;
                    default:
                        Console.WriteLine($"Invalid status: {status}");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid number of arguments for list command.");
            }
        }
        public void HandleAddCommand(string[] args)
        {
            if (args.Length >= 2)
            {
               _service.AddTask(args[1]);
            }
            else
            {
                Console.WriteLine("Missing task description.");
            }
        }
        public void HandleDeleteCommand(string[] args)
        {
            if (args.Length >= 2 && int.TryParse(args[1], out int id))
            {
                _service.DeleteTask(id);
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }
        public void HandleMarkInProgressCommand(string[] args)
        {
            if (args.Length >= 2 && int.TryParse(args[1], out int id))
            {
                _service.MarkTaskAsInProgess(id);
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }
        public void HandleMarkDoneCommand(string[] args)
        {
            if (args.Length >= 2 && int.TryParse(args[1], out int id))
            {
                _service.MarkTaskAsDone(id);
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }
        public void HandleUpdateCommand(string[] args)
        {
            if (args.Length >= 3 && int.TryParse(args[1], out int id))
            {
                _service.UpdateTask(id, args[2]);
            }
            else
            {
                Console.WriteLine("Invalid task ID or missing description.");
            }
        }
        public void HandleHelpCommand(string[] args)
        {
            PrintHelp();
        }
        private void PrintHelp()
        {
            Console.WriteLine("Available commands:");
            Console.WriteLine("  list [todo|in-progress|done]");
            Console.WriteLine("  add <description>");
            Console.WriteLine("  delete <id>");
            Console.WriteLine("  mark-in-progress <id>");
            Console.WriteLine("  mark-done <id>");
            Console.WriteLine("  update <id> <description>");
            Console.WriteLine("  ? or --help");
        }
    }
}
