using System;

namespace TestApp.ToDoList.Entity
{
  /// <summary>
  /// Entity of the ToDo item
  /// </summary>
  public class ToDoItem
  {
    /// <summary>
    /// Unique Id of the item (autoincrement)
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Title of the to-do item.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// IsCompleted flag of the to-do item.
    /// </summary>
    public bool IsCompleted { get; set; }

    /// <summary>
    /// Creation date of the to-do item.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Completion date of the to-do item.
    /// </summary>
    public DateTime? CompletedAt { get; set; }
  }
}