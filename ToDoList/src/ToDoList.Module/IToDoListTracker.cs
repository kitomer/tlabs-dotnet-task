using System.Collections.Generic;
using TestApp.ToDoList.Entity;

namespace TestApp.ToDoList.Module
{
  /// <summary>
  /// Tracking to-do list items.
  /// </summary>
  public interface IToDoListTracker
  {
    /// <summary>
    /// Adds a new to-do item.
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    ToDoItem AddItem(string title);
    /// <summary>
    /// Removes a to-do item.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ToDoItem RemoveItem(int id);
    /// <summary>
    /// Gets a to-do item by its Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ToDoItem GetItem(int id);
    /// <summary>
    /// Gets all to-do items.
    /// </summary>
    /// <returns></returns>
    IEnumerable<ToDoItem> GetAllItems();
    /// <summary>
    /// Edits a to-do item.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updatedTask"></param>
    /// <returns></returns>
    ToDoItem EditItem(int id, ToDoItem updatedTask);
  }
}