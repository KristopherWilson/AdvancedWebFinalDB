using MySqlConnector;

public class AppDb : IDisposable
{
    public MySqlConnection Connection { get; }

    public AppDb(string connectionString)
    {
        if (Connection == null)
            Connection = new MySqlConnection(connectionString);
    }

    public void Dispose()
    {
        Connection.Dispose();
    }
}