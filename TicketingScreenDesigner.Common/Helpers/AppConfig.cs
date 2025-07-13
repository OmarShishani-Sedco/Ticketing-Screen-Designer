using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Configuration;

public static class AppConfig
{
    private static IConfigurationRoot? _configuration;
    private static bool _initialized = false;

    public static void Initialize()
    {
        if (_initialized) return;

        var configDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config");
        var configFilePath = Path.Combine(configDirectory, "appsettings.json");

        if (!Directory.Exists(configDirectory))
            throw new DirectoryNotFoundException($"Config directory not found at: {configDirectory}");

        if (!File.Exists(configFilePath))
            throw new FileNotFoundException($"Configuration file 'appsettings.json' not found at: {configFilePath}");

        _configuration = new ConfigurationBuilder()
            .SetBasePath(configDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        _initialized = true;
    }

    public static string GetConnectionString()
    {
        if (!_initialized)
            throw new InvalidOperationException("AppConfig is not initialized. Call AppConfig.Initialize() first.");

        var connStr = _configuration!.GetConnectionString("DbConnection");

        if (string.IsNullOrWhiteSpace(connStr))
            throw new ConfigurationErrorsException("Connection string 'DbConnection' is missing or empty.");

        // Validate critical fields
        var builder = new SqlConnectionStringBuilder(connStr);

        if (string.IsNullOrWhiteSpace(builder.DataSource))
            throw new ConfigurationErrorsException("The 'Server' (DataSource) is missing in the connection string.");

        if (string.IsNullOrWhiteSpace(builder.InitialCatalog))
            throw new ConfigurationErrorsException("The 'Database' (InitialCatalog) is missing in the connection string.");

        // Optionally check for credentials (if not using Integrated Security)
        if (!builder.IntegratedSecurity)
        {
            if (string.IsNullOrWhiteSpace(builder.UserID) || string.IsNullOrWhiteSpace(builder.Password))
                throw new ConfigurationErrorsException("Database credentials (User ID or Password) are missing in the connection string.");
        }

        return connStr;
    }

}
