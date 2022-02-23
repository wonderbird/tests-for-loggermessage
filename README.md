# Starter Template for new .NET Projects

[![Build Status Badge](https://github.com/wonderbird/tests-for-loggermessage/workflows/.NET/badge.svg)](https://github.com/wonderbird/tests-for-loggermessage/actions?query=workflow%3A%22.NET%22)

An example on how to unit test [LoggerMessage based High-Performance-Logging](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/loggermessage?view=aspnetcore-6.0) using [Github: alefranz / MELT](https://github.com/alefranz/MELT).

## Thanks

Many thanks to [JetBrains](https://www.jetbrains.com/?from=tests-for-loggermessage) who provide
an [Open Source License](https://www.jetbrains.com/community/opensource/) for this project ❤️.

## Development

### Prerequisites

To compile, test and run this project the latest [.NET SDK](https://dotnet.microsoft.com/download) is required on your
machine. For calculating code metrics I recommend [metrix++](https://github.com/metrixplusplus/metrixplusplus). This
requires python.

If you are interested in test coverage, then you'll need the following tools installed:

```shell
dotnet tool install --global coverlet.console --configfile NuGet-OfficialOnly.config
dotnet tool install --global dotnet-reportgenerator-globaltool --configfile NuGet-OfficialOnly.config
```

## Build, Test, Run

Run the following commands from the folder containing the `.sln` file in order to build and test.

### Build the Solution and Run the Tests

```sh
dotnet build
dotnet test

# If you like continuous testing then use the dotnet file watcher to trigger your tests
dotnet watch -p ./TestsForLoggerMessage.Logic.Tests test

# As an alternative, run the tests with coverage and produce a coverage report
rm -r TestsForLoggerMessage.Logic.Tests/TestResults && \
  dotnet test --no-restore --verbosity normal /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput='./TestResults/coverage.cobertura.xml' && \
  reportgenerator "-reports:TestsForLoggerMessage.Logic.Tests/TestResults/*.xml" "-targetdir:report" "-reporttypes:Html;lcov" "-title:Tests For LoggerMessage"
open report/index.html
```

### Before Creating a Pull Request ...

... apply code formatting rules

```shell
dotnet format
```

... and check code metrics using [metrix++](https://github.com/metrixplusplus/metrixplusplus)

```shell
# Collect metrics
metrix++ collect --std.code.complexity.cyclomatic --std.code.lines.code --std.code.todo.comments --std.code.maintindex.simple -- .

# Get an overview
metrix++ view --db-file=./metrixpp.db

# Apply thresholds
metrix++ limit --db-file=./metrixpp.db --max-limit=std.code.complexity:cyclomatic:5 --max-limit=std.code.lines:code:25:function --max-limit=std.code.todo:comments:0 --max-limit=std.code.mi:simple:1
```

At the time of writing, I want to stay below the following thresholds:

```shell
--max-limit=std.code.complexity:cyclomatic:5
--max-limit=std.code.lines:code:25:function
--max-limit=std.code.todo:comments:0
--max-limit=std.code.mi:simple:1
```

I allow generated files named `*.feature.cs` to exceed these thresholds.

Finally, remove all code duplication. The next section describes how to detect code duplication.

## Identify Code Duplication

The `tools\dupfinder.bat` or `tools/dupfinder.sh` file calls
the [JetBrains dupfinder](https://www.jetbrains.com/help/resharper/dupFinder.html) tool and creates an HTML report of
duplicated code blocks in the solution directory.

In order to use the `dupfinder` you need to globally install
the [JetBrains ReSharper Command Line Tools](https://www.jetbrains.com/help/resharper/ReSharper_Command_Line_Tools.html)
On Unix like operating systems you also need [xsltproc](http://xmlsoft.org/XSLT/xsltproc2.html), which is pre-installed
on macOS.

From the folder containing the `.sln` file run

```sh
tools\dupfinder.bat
```

or

```sh
tools/dupfinder.sh
```

respectively.

The report will be created as `dupfinder-report.html` in the current directory.

# References

* This project is based on the [wonderbird / dotnet-starter](https://github.com/wonderbird/dotnet-starter) template
* [High-performance logging with LoggerMessage in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/loggermessage?view=aspnetcore-6.0)
* Alessio Franceschelli: [How to test logging when using Microsoft.Extensions.Logging](https://alessio.franceschelli.me/posts/dotnet/how-to-test-logging-when-using-microsoft-extensions-logging/)
  * [Github: alefranz / MELT](https://github.com/alefranz/MELT) - Testing Library for Microsoft Extensions Logging.
