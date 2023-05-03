using Serilog;
using System;
using DotNetEnv;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.Datadog.Logs;
using Serilog.Sinks.File;
//working
namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {

            var config = new DatadogConfiguration(url: "intake.logs.datadoghq.com", port: 10516 , useSSL: true, useTCP: true);
            using (var Log = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File("logs.txt",
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Verbose,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}")
                .WriteTo.DatadogLogs(
                    "",
                    source: "Serilog",
                    service: "Serilog",
                    host: "Serilog-sandbox",
                    tags: new string[] {"sandbox_env:Serilog"},
                    configuration: config
                )
                .CreateLogger())
            
                //Log.Verbose("This is a verbose message.");
                Log.Debug("This is a debug message.");
                //Log.Information("This is an informational message.");
                //Log.Warning("This is a warning message.");
                //Log.Error("This is an error message.");
                //Log.Fatal("This is a fatal message.");
                Log.CloseAndFlush();
            
        }
    }
}
