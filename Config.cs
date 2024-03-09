using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fivemAsService;

public class Config {
  /// <summary>
  /// Absolute path to FXServer Executable
  /// </summary>
  public static string? ExePath { get; set; }

  /// <summary>
  /// Arguments to pass with the FXServer Executable
  /// </summary>
  public static Dictionary<string, object>? Args { get; set; }
}
