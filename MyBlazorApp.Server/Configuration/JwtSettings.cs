namespace MyBlazorApp.Server.Configuration;

public class JwtSettings
{
    public string SecretKey { get; set; } = "MySecretKeyForAuthenticationMySecretKeyForAuthentication";
    public string Issuer { get; set; } = "https://localhost:7001";
    public string Audience { get; set; } = "https://localhost:5001";
    public int ExpirationInMinutes { get; set; } = 60;
}
