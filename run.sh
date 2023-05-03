#!/bin/bash
brew install dotnet-sdk
dotnet new console -n MyProject
cd MyProject
cat ../csproj_config > MyProject.csproj
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Sinks.Datadog.Logs
dotnet add package Serilog.Sinks.Console --version 4.1.0
dotnet restore
rm -r Program.cs && mv ../serilog_debug.cs ./

dotnet publish -c Release -o ./publish
cd publish
dotnet MyProject.dll