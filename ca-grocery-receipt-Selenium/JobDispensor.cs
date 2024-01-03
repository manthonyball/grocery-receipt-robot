using System.Collections.Generic;

class JobDispensor
{
    private ISubTask taskInterface;
    private List<ISubTask> tasksInterface;

    //Constructor: assigns strategy to interface  
    public JobDispensor(ISubTask aSubTask) => taskInterface = aSubTask;

    public JobDispensor(List<ISubTask> subTasks) => tasksInterface = subTasks;

    //Executes the strategy  
    public void CompleteTheTask(ConfigDTO setting) => taskInterface.ExecuteTheTask(setting);

    public void CompleteThoseTasks(ConfigDTO setting)
    {
        if (tasksInterface != null && tasksInterface.Count > 0)
            foreach (var aTask in tasksInterface)
                aTask.ExecuteTheTask(setting);
    }
}
