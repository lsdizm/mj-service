using System;

namespace mj_service.Services;

public class SchedulerService
{
    public SchedulerService()
    {
    }

    public void Start() 
    {
        var timer = new Timer(new TimerCallback(OnTick), this, 0, 60000);
    }

    public void OnTick(Object o)
    {
        var _connectionString =  "host=152.70.232.248;port=3306;user id=mj;password=!Dhfkzmffkdnem1;database=mj;";

        using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString)) 
        {
            connection.Open();
            var now = DateTime.Now.ToString("yyyyMMddHHmmss");
            var sql = $"insert into RACE_SCHEDULER_TEST values (date_format(now(), '%Y%m%d%H%i%s'), '{now}');";
            var command = new MySql.Data.MySqlClient.MySqlCommand(sql, connection);
            var result = command.ExecuteNonQuery();
        }   
    }

    public async Task<bool> Execute()
    {
        var _connectionString =  "host=152.70.232.248;port=3306;user id=mj;password=!Dhfkzmffkdnem1;database=mj;";

        using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString)) 
        {
            await connection.OpenAsync().ConfigureAwait(false);
            var now = DateTime.Now.ToString("yyyyMMddHHmmss");
            var sql = $"insert into RACE_SCHEDULER_TEST values (date_format(now(), '%Y%m%d%H%i%s'), '{now}');";
            var command = new MySql.Data.MySqlClient.MySqlCommand(sql, connection);
            var result = await command.ExecuteNonQueryAsync().ConfigureAwait(false);

            return (result == 1);
        }   
    }
}
