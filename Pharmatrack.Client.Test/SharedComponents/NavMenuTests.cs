using Pharmatrack.Client.SharedComponents;
using Pharmatrack.Client.Test.TestFixtures;

namespace Pharmatrack.Client.Test.SharedComponents;

public class NavMenuTests : IDisposable
{
    private readonly TestContextFactory _contextFactory;

    public NavMenuTests()
    {
        _contextFactory = new TestContextFactory();
    }

    [Fact]
    public void NavMenu_Should_Render_All_Navigation_Links()
    {
        // Arrange
        using var ctx = _contextFactory.GetContext();

        // Act
        var cut = ctx.Render<NavMenu>();

        // Assert
        var links = cut.FindAll("a");
        Assert.Equal(3, links.Count);
    }

    [Fact]
    public void NavMenu_Should_Have_Home_Link()
    {
        // Arrange
        using var ctx = _contextFactory.GetContext();

        // Act
        var cut = ctx.Render<NavMenu>();

        // Assert
        var homeLink = cut.Find("a[href='']");
        Assert.NotNull(homeLink);
        Assert.Contains("Home", homeLink.TextContent);
    }

    [Fact]
    public void NavMenu_Should_Have_About_Link()
    {
        // Arrange
        using var ctx = _contextFactory.GetContext();

        // Act
        var cut = ctx.Render<NavMenu>();

        // Assert
        var aboutLink = cut.Find("a[href='about']");
        Assert.NotNull(aboutLink);
        Assert.Contains("About", aboutLink.TextContent);
    }

    [Fact]
    public void NavMenu_Should_Have_Products_Link()
    {
        // Arrange
        using var ctx = _contextFactory.GetContext();

        // Act
        var cut = ctx.Render<NavMenu>();

        // Assert
        var productsLink = cut.Find("a[href='products']");
        Assert.NotNull(productsLink);
        Assert.Contains("Products", productsLink.TextContent);
    }

    public void Dispose()
    {
        _contextFactory?.Dispose();
    }
}
