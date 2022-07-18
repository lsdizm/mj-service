using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using MySql;

namespace mj_service.Controllers;

[ApiController]
public class QueryController : ControllerBase
{
    public QueryController()
    {
    }

    [HttpGet("queries/{id}")]
    public async Task<IActionResult> GetQuery(string id)
    {
        var _connectionString =  "host=152.70.232.248;port=3306;user id=mj;password=!Dhfkzmffkdnem1;database=mj;";

        using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString)) 
        {
            connection.Open();
            var sql = await Dapper.SqlMapper.QueryFirstAsync<string>(connection, $"select SQL_CONTENT from SQL_STORAGE where id = '{id}'").ConfigureAwait(false);

            if (!string.IsNullOrWhiteSpace(sql)) {
                var result = await Dapper.SqlMapper.QueryAsync<dynamic>(connection, sql).ConfigureAwait(false);
                return Ok(result);
            }
            else 
            {
                return BadRequest("empty sql data");
            }
        }   
    }
}
