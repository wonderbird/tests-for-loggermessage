using MELT;
using Microsoft.Extensions.Logging;
using Xunit;

namespace TestsForLoggerMessage.Logic.Tests;

public class HelloWorldTest
{
    [Fact]
    public void ShouldPrintLogMessage()
    {
        var loggerFactory = TestLoggerFactory.Create();
        var logger = loggerFactory.CreateLogger<HelloWorld>();

        new HelloWorld(logger).LogHelloWorld();

        var log = Assert.Single(loggerFactory.Sink.LogEntries);
        Assert.Equal("Hello World!", log.Message);
    }
}