using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using mj_service.Connects;
using Dapper;
using MySql;

namespace mj_service.Controllers;

[ApiController]
public class QueryController : ControllerBase
{
    private readonly IDataBases _databases;
    public QueryController(IDataBases databases)
    {
        _databases = databases;
    }

    [HttpGet("queries/{id}")]
    public async Task<IActionResult> GetQuery(string id)
    {
        using (var connection = _databases.Connect()) 
        {
            await connection.OpenAsync().ConfigureAwait(false);            
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
