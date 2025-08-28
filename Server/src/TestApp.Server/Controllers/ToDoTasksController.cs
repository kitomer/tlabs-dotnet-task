using Microsoft.AspNetCore.Mvc;
using TestApp.ToDoList.Entity;
using TestApp.ToDoList.Module;

namespace TestApp.Server.Controllers
{
  [ApiController]
  [Route("api/tasks")]
  public class ToDoTasksController : ControllerBase
  {
    private readonly IToDoListTracker toDoListTracker;

    public ToDoTasksController(IToDoListTracker toDoListTracker)
    {
      this.toDoListTracker = toDoListTracker;
    }

    [HttpGet]
    public IList<ToDoItem> GetTasks()
    {
      var tasks = toDoListTracker.GetAllItems();
      return tasks.ToList();
    }

    [HttpPost]
    public ToDoItem CreateTask([FromBody] ToDoItem newTask)
    {

      var task = toDoListTracker.AddItem(newTask.Title);
      return task;
    }

    [HttpPut("{id}")]
    public ToDoItem EditTask(int id, [FromBody] ToDoItem updatedTask)
    {
      var task = toDoListTracker.EditItem(id, updatedTask);
      return task;
    }

    [HttpDelete("{id}")]
    public ToDoItem DeleteTask(int id)
    {
      var task = toDoListTracker.RemoveItem(id);
      return task;
    }
  }
}