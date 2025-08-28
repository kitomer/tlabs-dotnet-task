using Microsoft.EntityFrameworkCore;
using TestApp.ToDoList.Entity;

namespace TestApp.ToDoList.Store
{
  /// <summary>
  /// DbContext for the ToDo list.
  /// </summary>
  public class ToDoListDbContext : DbContext
  {
    /// <inheritdoc/>
    protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseInMemoryDatabase(databaseName: "InMemoryTodoTasksDb");
    }
    /// <summary>
    /// DB Set for To-Do Items
    /// </summary>
    public DbSet<ToDoItem> ToDoItems { get; set; }

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.UseCollation("NOCASE");
      base.OnModelCreating(modelBuilder);
      var entityModel = new ToDoListEntityModel();
      entityModel.ConfigureModel(modelBuilder);
    }
  }
}