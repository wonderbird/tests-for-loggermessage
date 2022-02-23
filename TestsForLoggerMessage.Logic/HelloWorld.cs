using Microsoft.Extensions.Logging;

namespace TestsForLoggerMessage.Logic;

public class HelloWorld
{
    private readonly ILogger<HelloWorld> _logger;

    public HelloWorld(ILogger<HelloWorld> logger) => _logger = logger;

    public void LogHelloWorld() => _logger.HelloWorld();
}
