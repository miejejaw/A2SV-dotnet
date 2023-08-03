using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

public enum TaskCategory
{
    Work, 
    Errands,
    Personal 
}

public class Task
{
    public string?  Name { get; set;}
    public string?  Description { get; set;}
    public TaskCategory Category{ get; set;}
    public bool? IsCompleted { get; set;}
}

public class TaskManager
{
    List<Task> Tasks;
    private string filePath = "data.csv";
    public TaskManager(){
        Tasks = new List<Task>(); 
        ReadFromFile();
    }
  
    public  async void AddTask(string name,string description,string category,bool isCompleted){
        try{
            TaskCategory category_ = (TaskCategory)Enum.Parse(typeof(TaskCategory), category);
            Tasks.Add(new Task{ Name=name, Description=description, Category=category_, IsCompleted=isCompleted});
            string taskText = $"{name},{description},{category},{isCompleted}\n";
            await File.AppendAllTextAsync(filePath, taskText);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
  
    private async void RewriteToFile(){
        try{
            using (var stream = new FileStream(filePath, FileMode.Truncate)){stream.SetLength(0);}
            foreach(Task task in Tasks){
                string taskText = $"{task.Name},{task.Description},{task.Category},{task.IsCompleted}\n";
                await File.AppendAllTextAsync(filePath, taskText);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
  
    private async void ReadFromFile(){
        try{
            string[] lines = await File.ReadAllLinesAsync(filePath);
            
            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                TaskCategory category = (TaskCategory)Enum.Parse(typeof(TaskCategory), values[2]);
                Tasks.Add(new Task{ Name=values[0], Description=values[1], Category= category, IsCompleted=bool.Parse(values[3])});
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
  
    public void UpdateTask(string name,string desc){
        Task? updateTask = Tasks.Find(task => task.Name == name);
        
        if(updateTask == null) return;
        updateTask.Description = desc;
        RewriteToFile();
    }
  
    public void RemoveTask(string name){
        Task? removeTask = Tasks.Find(task => task.Name == name);
        if(removeTask == null) return;
        Tasks.Remove(removeTask);
        RewriteToFile();
    }

    public void DisplayTasks(List<Task>? tasks = null){

        if(tasks == null){
            tasks = Tasks;
        }
        Console.WriteLine("Tasks:");
        Console.WriteLine("{0,-10}{1,-15}{2,-10}{3}","Name","Description","Category","Completed");
        foreach (Task task in tasks)
        {
            Console.WriteLine("{0,-10}{1,-15}{2,-10}{3}",task.Name,task.Description,task.Category,task.IsCompleted);
        }
    }
  
    public void DisplayTasksByCatagory(string category){
        TaskCategory category_ = (TaskCategory)Enum.Parse(typeof(TaskCategory), category);
        List<Task> filteredTasks = Tasks.Where(task => task.Category == category_).ToList();
        DisplayTasks(filteredTasks);
    }
}

public class Program
{

    public static void Main(){

        TaskManager taskManager =  new TaskManager();

        taskManager.AddTask("AA", "AAAA", "Errands", true);
        taskManager.AddTask("BB", "BBBB", "Personal", false);
        taskManager.AddTask("CC", "CCCC", "Work", false);
        taskManager.AddTask("DD", "DDDD", "Work", true);
        taskManager.AddTask("EE", "EEEE", "Personal", true);

        taskManager.UpdateTask("BB","FF");
        taskManager.RemoveTask("BB");
        taskManager.DisplayTasksByCatagory("Work");
        taskManager.DisplayTasks();
    }
}


