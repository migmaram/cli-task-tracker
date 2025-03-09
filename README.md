### Console task tracker

This is a simple console-based task tracker application, that allows the user keep track of their tasks. Tasks created are stored in a `.json` file called `tasks.json`, this file is created by default in the directory where the application is executed.

### Features/commands:

- Add new task: `task-cli add <description>`
- Update task: `task-cli update <taskId> <description>`
- Delete task: `task-cli delete <taskId>`
- List tasks: `task-cli list [ todo | in-progress | done ]`
- Mark task as in progress: `task-cli  mark-in-progress <taskId>`
- Mark task as done: `task-cli mark-done <taskIid>`

### Installation

1. Clone repository
    
    ```bash
    git clone https://github.com/migmaram/task-cli 
    ```
    
2. Navigate to the project directory
    
    ```bash
    cd <project_directory>
    ```
    
3. Restore dependencies
    
    ```bash
    dotnet restore
    ```
    
4. Build project
    
    ```bash
    dotnet build
    ```
    
5. Run the application (In the directory where the application was built, open your console and run any of the commands in the Feaures/commands section)



✨ The goal of building this project was to practice C# coding, SOLID principles, and file management. I took the idea from: [Developer Roadmaps - Task Tracker CLI](https://roadmap.sh/projects/task-tracker)



