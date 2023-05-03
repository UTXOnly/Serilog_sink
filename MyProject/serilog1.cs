using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.File;
using Serilog.Sinks.Datadog.Logs;

namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new DatadogConfiguration(url: "intake.logs.datadoghq.com", port: 443, useSSL: true, useTCP: true);
            using (var log = new LoggerConfiguration()
                .WriteTo.DatadogLogs(
                    "d18767d3b768351098fa401daa72abeb",
                    source: "Serilog",
                    service: "Serilog",
                    host: "Serilog-sandobox",
                    tags: new string[] {"sandbox_env:Serilog"},
                    configuration: config
                )
                .CreateLogger())
            {
                Log.Information("Are you reading this in Log Explorer??");
                Log.CloseAndFlush();
            }
        }
    }
}





