using Microsoft.EntityFrameworkCore;

using TestApp.ToDoList.Entity;

namespace TestApp.ToDoList.Store
{
  /// <summary>ToDoList's EF model.</summary>
  public class ToDoListEntityModel
  {
    /// <inheritdoc/>
    public void ConfigureModel(ModelBuilder modBuilder)
    {

      modBuilder.Entity<ToDoItem>(s =>
      {
        s.HasKey(d => d.Id);
        s.HasIndex(d => d.Title)
            .IsUnique();
      });
    }
  }
}