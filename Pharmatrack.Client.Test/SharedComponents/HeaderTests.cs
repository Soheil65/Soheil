using Pharmatrack.Client.SharedComponents;
using Pharmatrack.Client.Test.TestFixtures;

namespace Pharmatrack.Client.Test.SharedComponents;

public class HeaderTests : IDisposable
{
    private readonly TestContextFactory _contextFactory;

    public HeaderTests()
    {
        _contextFactory = new TestContextFactory();
    }

    [Fact]
    public void Header_Should_Render_Title()
    {
        // Arrange
        using var ctx = _contextFactory.GetContext();

        // Act
        var cut = ctx.Render<Header>();

        // Assert
        var h1 = cut.Find("h1");
        Assert.Contains("Pharmatrack", h1.TextContent);
    }

    [Fact]
    public void Header_Should_Have_Primary_Background()
    {
        // Arrange
        using var ctx = _contextFactory.GetContext();

        // Act
        var cut = ctx.Render<Header>();

        // Assert
        var header = cut.Find("header");
        Assert.Contains("bg-primary", header.ClassName);
    }

    public void Dispose()
    {
        _contextFactory?.Dispose();
    }
}
