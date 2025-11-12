using Pharmatrack.Client.Pages.Home;
using Pharmatrack.Client.Test.TestFixtures;

namespace Pharmatrack.Client.Test.Pages;

public class HomeTests : IDisposable
{
    private readonly TestContextFactory _contextFactory;

    public HomeTests()
    {
        _contextFactory = new TestContextFactory();
    }

    [Fact]
    public void Home_Should_Render_Welcome_Message()
    {
        // Arrange
        using var ctx = _contextFactory.GetContext();

        // Act
        var cut = ctx.Render<Home>();

        // Assert
        var h1 = cut.Find("h1");
        Assert.Contains("Welcome to Pharmatrack", h1.TextContent);
    }

    [Fact]
    public void Home_Should_Render_Cards()
    {
        // Arrange
        using var ctx = _contextFactory.GetContext();

        // Act
        var cut = ctx.Render<Home>();

        // Assert
        var cards = cut.FindAll(".card");
        Assert.Equal(3, cards.Count);
    }

    [Fact]
    public void Home_Should_Have_Products_Link()
    {
        // Arrange
        using var ctx = _contextFactory.GetContext();

        // Act
        var cut = ctx.Render<Home>();

        // Assert
        var productLink = cut.Find("a[href='/products']");
        Assert.NotNull(productLink);
    }

    public void Dispose()
    {
        _contextFactory?.Dispose();
    }
}
