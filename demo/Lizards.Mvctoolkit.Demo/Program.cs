namespace Lizzards.Mvctoolkit.Demo
{
  using Lamar.Microsoft.DependencyInjection;
  using Microsoft.AspNetCore;
  using Microsoft.AspNetCore.Hosting;

  /// <summary>
  /// Demo starter
  /// </summary>
  public static class Program
  {
    /// <summary>
    /// Defines the entry point of the application.
    /// </summary>
    /// <param name="args">The arguments.</param>
    public static void Main(string[] args)
    {
      BuildWebHost(args).Run();
    }

    /// <summary>
    /// Builds the web host.
    /// </summary>
    /// <param name="args">The arguments.</param>
    /// <returns></returns>
    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<DemoStartup>()
            .UseLamar()
            .Build();
  }
}
