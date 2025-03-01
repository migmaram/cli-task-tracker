### Console task tracker

This is a simple console-based task tracker application, that allows the user keep track of their tasks. Tasks created are stored in a `.json` file called `tasks.json`, this file is created by default in the directory where the application is executed.

### Features/commands:

- Add new task: `cli-task-tracker add <description>`
- Update task: `cli-task-tracker update <taskId> <description>`
- Delete task: `cli-task-tracker delete <taskIid>`
- List tasks: `cli-task-tracker list [todo|in-progress|done]`
- Mark task as in progress: `cli-task-tracker mark-in-progress <taskId>`
- Mark task as done: `cli-task-tracker mark-done <taskIid>`

### Installation

1. Clone repository
    
    ```bash
    git clone https://github.com/migmaram/cli-task-tracker
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
    
5. Run the application (Open your console in the directory where the application was built and run one the allowed commands)

<aside>
✨ The main goal of this project was to practice C# coding, SOLID notions, and file management. I took the idea, as part of the back end software development path, from: https://roadmap.sh/projects/task-tracker
</aside>


