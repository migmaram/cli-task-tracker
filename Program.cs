using System.Reflection.Metadata.Ecma335;

namespace task_cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repository = new TaskRepository($"{Directory.GetCurrentDirectory()}\\tasks.json");
            var service = new TaskService(repository);
            var commandManager = new CommandManager(service);
            commandManager.Run(args);
        }
            
    }
}
