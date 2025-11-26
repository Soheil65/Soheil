using Pharmatrack.Client.SharedComponents;
using Pharmatrack.Client.Test.TestFixtures;

namespace Pharmatrack.Client.Test.SharedComponents;

public class FooterTests : IDisposable
{
    private readonly TestContextFactory _contextFactory;

    public FooterTests()
    {
        _contextFactory = new TestContextFactory();
    }

    [Fact]
    public void Footer_Should_Render_Copyright()
    {
        // Arrange
        using var ctx = _contextFactory.GetContext();

        // Act
        var cut = ctx.Render<Footer>();

        // Assert
        var paragraph = cut.Find("p");
        Assert.Contains("Pharmatrack", paragraph.TextContent);
        Assert.Contains("All rights reserved", paragraph.TextContent);
    }

    [Fact]
    public void Footer_Should_Display_Current_Year()
    {
        // Arrange
        using var ctx = _contextFactory.GetContext();
        var currentYear = DateTime.Now.Year.ToString();

        // Act
        var cut = ctx.Render<Footer>();

        // Assert
        var paragraph = cut.Find("p");
        Assert.Contains(currentYear, paragraph.TextContent);
    }

    public void Dispose()
    {
        _contextFactory?.Dispose();
    }
}
