using System.Collections.Generic;
using System.Linq;
using TestApp.ToDoList.Entity;
using TestApp.ToDoList.Store;

namespace TestApp.ToDoList.Repository
{
  /// <summary>
  /// Repository for managing to-do items.
  /// </summary>
  public class ToDoItemsRepository : IToDoItemsRepository
  {
    private readonly ToDoListDbContext context;
    /// <summary>
    /// Ctor. Seeds initial data.
    /// </summary>
    /// <param name="context"></param>
    public ToDoItemsRepository(ToDoListDbContext context)
    {
      this.context = context;

      if (!context.ToDoItems.Any())
      {
        context.ToDoItems.AddRange(
        new[] {
          new ToDoItem { Title = "Laundry"},
          new ToDoItem { Title = "Grocery Shopping", IsCompleted = true},
          new ToDoItem { Title = "Pay Bills"},
          new ToDoItem { Title = "Clean the House", IsCompleted = true},
        }
      );
        context.SaveChanges();
      }
    }
    /// <inheritdoc/>
    public ICollection<ToDoItem> GetAllItems()
    {
      return context.ToDoItems.ToList();
    }
    /// <inheritdoc/>
    public ToDoItem GetItemById(int id)
    {
      return context.ToDoItems.Find(id);
    }
    /// <inheritdoc/>
    public ToDoItem Create(ToDoItem item)
    {
      context.ToDoItems.Add(item);
      context.SaveChanges();
      return item;
    }
    /// <inheritdoc/>
    public ToDoItem Update(ToDoItem item)
    {
      context.ToDoItems.Update(item);
      context.SaveChanges();
      return item;
    }
    /// <inheritdoc/>
    public void Delete(int id)
    {
      var item = context.ToDoItems.Find(id);
      if (item != null)
      {
        context.ToDoItems.Remove(item);
        context.SaveChanges();
      }
    }

  }
}