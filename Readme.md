
# Serilog Sink test shipping to Datadog

## Description
This repo provides an example a working example of shipping logs from a C# program with Serilog Sink to Datadog

## Prerequisites

Must have `dotnet-sdk` installed on your machine:
* To install this on Debian based Linux distros
```sudo apt-get install -y dotnet-sdk-7.0```
* On a Mac
```brew install dotnet-sdk```

## Running the program

1. Enter your API key in this section in `serilog_debug.cs` and save:
```
  .WriteTo.DatadogLogs(
                    "<YOUR_API_KEY_HERE>",
                    source: "Serilog",
                    service: "Serilog",
                    host: "Serilog-sandbox",
                    tags: new string[] {"sandbox_env:Serilog"},
                    configuration: config
                )

```

2. Execute the `.run.sh` script to install all dependeincies and create the project folder

This wil then run the program which will produce a log file locally in the `publish` directory and ship logs to Datadog
**You should now be able to view logs in Datadog Log Explorer!**

## Demonstration

![Screen Recording 2023-05-03 at 10 30 16 AM](https://user-images.githubusercontent.com/49233513/235947999-b9af702e-0c54-4c5b-ac7d-ed761b498f2d.gif)

