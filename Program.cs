using fivemAsService;

internal class Program {
  static async Task Main(string[] args) {
    IHost host = Host.CreateDefaultBuilder(args)
                     .ConfigureServices(
                         services => { services.AddHostedService<Worker>(); })
                     .UseWindowsService()
                     .Build();

    await host.RunAsync();
    await host.StopAsync();
  }
}
