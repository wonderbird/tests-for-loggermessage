using System;
using Microsoft.Extensions.Logging;

namespace TestsForLoggerMessage.Logic;

public static class LoggerExtensions
{
    private static readonly Action<ILogger, Exception?> HelloWorldAction;

    static LoggerExtensions() =>
        HelloWorldAction =
            LoggerMessage.Define(LogLevel.Information, new EventId(1, nameof(HelloWorld)), "Hello World!");

    public static void HelloWorld(this ILogger logger) => HelloWorldAction(logger, null);
}