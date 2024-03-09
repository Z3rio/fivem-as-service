using Newtonsoft.Json.Linq;

namespace fivemAsService;

public class Worker : BackgroundService {
  private readonly ILogger<Worker> _logger;

  public Worker(ILogger<Worker> logger) { _logger = logger; }

  private static void LoadConfig() {
    var configFile = File.ReadAllText(
        Path.Combine(AppContext.BaseDirectory, "appsettings.json"));
    dynamic config = JToken.Parse(configFile);
    Config.ExePath = config.Server.fxServerPath;
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
    LoadConfig();

    while (!stoppingToken.IsCancellationRequested) {
      _logger.LogInformation("ExePath: {exePath}", Config.ExePath);
      _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
      await Task.Delay(1000, stoppingToken);
    }
  }
}
