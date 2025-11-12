namespace Pharmatrack.Client.ServerConnector.Helpers;

public static class ApiRoutes
{
    public const string BaseUrl = "api";
    
    public static class Products
    {
        public const string Base = $"{BaseUrl}/products";
        public const string GetAll = Base;
        public const string GetById = $"{Base}/{{0}}";
        public const string Create = Base;
        public const string Update = $"{Base}/{{0}}";
        public const string Delete = $"{Base}/{{0}}";
    }
}
