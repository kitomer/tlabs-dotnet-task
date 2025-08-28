namespace TestApp.Server
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(builder =>
        {
          builder.UseStartup<Startup>();
          builder.UseUrls("http://*:5000");
        });

    public static void AddAppConfiguration(
        HostBuilderContext hostingContext,
        IConfigurationBuilder config)
    {
      config.Sources.Clear();
      config.AddJsonFile("appsettings.json", optional: true);
    }
  }
}

