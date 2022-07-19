namespace mj_service.Connects;
public interface IDataBases 
{
    MySql.Data.MySqlClient.MySqlConnection Connect();
    Task<int> ExecuteAsync(string sql, MySql.Data.MySqlClient.MySqlConnection connection);
}