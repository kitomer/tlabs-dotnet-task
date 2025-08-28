using TestApp.ToDoList.Store;
using TestApp.ToDoList.Module;
using TestApp.ToDoList.Tracker;
using TestApp.ToDoList.Repository;


namespace TestApp.Server
{
  public class Startup
  {
    IConfiguration configuration;

    public Startup(IConfiguration configuration)
    {
      this.configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
      // Add DB
      services.AddDbContext<ToDoListDbContext>();

      // Add controllers
      services.AddControllers();

      // Configure app services
      services.AddScoped<IToDoListTracker, ToDoListTracker>();
      services.AddSingleton<IToDoItemsRepository, ToDoItemsRepository>();
      services.AddScoped<ToDoListEntityModel>();

      services.AddCors(options =>
      {
        options.AddDefaultPolicy(policy =>
        {
          policy.AllowAnyOrigin()
            .AllowAnyHeader();
        });
      });

      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider svcProv)
    {

      // Enable Swagger in all environments
      app.UseSwagger();
      app.UseSwaggerUI();

      var appLifetime = svcProv.GetRequiredService<IHostApplicationLifetime>();
      appLifetime.ApplicationStarted.Register(onApplicationStarted);

      app.UseRouting();
      app.UseAuthorization();

      app.UseCors();

      app.UseEndpoints(endpoints =>
        {
          endpoints.MapControllers();
        }
      );
    }

    void onApplicationStarted()
    {
      // Do nothing
    }

  }
}