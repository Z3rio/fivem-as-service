using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace fivemAsService;

public class Worker : BackgroundService {
  private readonly ILogger<Worker> _logger;

  public Worker(ILogger<Worker> logger) { _logger = logger; }
  private static readonly Process Proc = new Process();

  private static void LoadConfig() {
    var configFile = File.ReadAllText(
        Path.Combine(AppContext.BaseDirectory, "appsettings.json"));
    dynamic config = JToken.Parse(configFile);
    Config.ExePath = config.Server.fxServerPath;
    Config.Args = config.Server.args.ToObject<Dictionary<string, object>>();
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
    LoadConfig();

    while (!stoppingToken.IsCancellationRequested) {
      _logger.LogInformation("ExePath: {exePath}", Config.ExePath);
      _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
      await StartProc(stoppingToken);
      await Task.Delay(-1, stoppingToken);
    }
  }

  private static async Task StartProc(CancellationToken stoppingToken) {
    Proc.StartInfo.FileName = Config.ExePath;
    Proc.StartInfo.UseShellExecute = false;
    if (Config.Args != null) {
      foreach (var arg in Config.Args) {
        Proc.StartInfo.Arguments += $"{arg.Key} {arg.Value} ";
      }
    }
    Proc.Start();
    Console.WriteLine($"Started FiveM server at process id: {Proc.Id}");
    await Proc.WaitForExitAsync(stoppingToken);
  }
}
