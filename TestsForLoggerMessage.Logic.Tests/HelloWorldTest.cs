using Xunit;

namespace TestsForLoggerMessage.Logic.Tests;

public class HelloWorldTest
{
    [Fact]
    public void Hello_ReturnsWorld() => Assert.Equal("World!", HelloWorld.Hello());
}