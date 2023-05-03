
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

1. Open the command line and navigate to the directory where you want to create your project.
2. Run `dotnet new console -n MyProject` to create a new console project called `MyProject`.
3. Move into the Project directory using `cd MyProject`
4. Populate the `csproj` file by running `cat csproj_config >> MyProject.csproj`
5. Run the following commands to add the required NuGet packages:

```
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Sinks.Datadog.Logs
dotnet add package Serilog.Sinks.Console --version 4.1.0
dotnet restore
```

6. Move the `.cs` file into the project folder using `mv ../serilog_debug.cs ./`

7. Enter your API key in this section in `serilog_debug.cs` and save:
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
8. Run `dotnet publish -c Release -o ./publish` to build the application and generate the publish folder.
9. Navigate to the `publish` folder by running `cd publish`.
10. Run `dotnet MyProject.dll` to start the application.
**You should now be shipping logs to Datadog**


