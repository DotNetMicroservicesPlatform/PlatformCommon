namespace PlatformCommon.Settings;

public class SqlDbSettings
{
    private string _connectionString;
    public string Server { get; init; }
    public string Port { get; init; }
    public string DbName { get; init; }
    public string User { get; init; }
    public string Password { get; init; }

    public string ConnectionString
    {
        get
        {
            return string.IsNullOrEmpty(_connectionString) ? $"Server={Server},{Port};Initial Catalog={DbName};User ID={User};Password={Password};TrustServerCertificate=true" : _connectionString;
        }
        init
        {
            _connectionString = value;
        }
    }
}