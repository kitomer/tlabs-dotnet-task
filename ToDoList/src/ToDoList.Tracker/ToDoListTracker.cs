using System;
using System.Collections.Generic;
using System.Linq;
using TestApp.ToDoList.Entity;
using TestApp.ToDoList.Module;
using TestApp.ToDoList.Repository;

namespace TestApp.ToDoList.Tracker
{
  /// <summary>
  /// Implementation of the to-do list tracking.
  /// </summary>
  public class ToDoListTracker : IToDoListTracker
  {
    private readonly IToDoItemsRepository repository;
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="repository"></param>
    public ToDoListTracker(IToDoItemsRepository repository)
    {
      this.repository = repository;
    }

    /// <inheritdoc/>
    public ToDoItem AddItem(string title)
    {
      // Implementation for adding a to-do item
      var newItem = new ToDoItem { Title = title, IsCompleted = false };
      newItem = repository.Create(newItem);
      return newItem;
    }
    /// <inheritdoc/>
    public ToDoItem RemoveItem(int id)
    {
      var item = repository.GetItemById(id);
      if (null == item)
        throw new ArgumentException($"Item with id {id} not found");

      repository.Delete(id);
      return item;
    }
    /// <inheritdoc/>
    public ToDoItem GetItem(int id)
    {
      // Implementation for getting a specific to-do item
      var item = repository.GetItemById(id);
      if (null == item)
        throw new ArgumentException($"Item with id {id} not found");

      return item;
    }
    /// <inheritdoc/>
    public IEnumerable<ToDoItem> GetAllItems()
    {
      // Implementation for getting all to-do items
      return repository.GetAllItems().ToList();
    }
    /// <inheritdoc/>
    public ToDoItem EditItem(int id, ToDoItem updatedTask)
    {
      var item = repository.GetItemById(id);
      if (null == item)
        throw new ArgumentException($"Item with id {id} not found");

      item.Title = updatedTask.Title;
      item.IsCompleted = updatedTask.IsCompleted;
      item.CompletedAt = updatedTask.IsCompleted ? DateTime.UtcNow : null;
      repository.Update(item);
      return item;
    }
  }
}