using Pharmatrack.Client.Services;

namespace Pharmatrack.Client.Test.TestFixtures;

public class TestContextFactory : IDisposable
{
    private readonly BunitContext _testContext;

    public TestContextFactory()
    {
        _testContext = new BunitContext();
        
        // Register mock services
        _testContext.Services.AddSingleton<AppStateService>();
    }

    public BunitContext GetContext() => _testContext;

    public void Dispose()
    {
        _testContext?.Dispose();
    }
}
