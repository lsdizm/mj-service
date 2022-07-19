using Microsoft.AspNetCore.Mvc;
using mj_service.Connects;

namespace mj_service.Controllers;

[ApiController]
public class SchedulerController : ControllerBase
{
    private readonly IDataBases _databases;
    public SchedulerController(IDataBases databases)
    {
        _databases = databases;
    }

    [HttpPost("schedulers")]
    public async Task<IActionResult> ExecuteScheduler([FromQuery] string remark)
    {
        using (var connection = _databases.Connect()) 
        {
            await connection.OpenAsync().ConfigureAwait(false);
            var sql = $"insert into RACE_SCHEDULER_TEST values (date_format(now(), '%Y%m%d%H%i%s'), '{remark}');";
            await _databases.ExecuteAsync(sql, connection).ConfigureAwait(false);            
            return Ok();
        }   
    }
}
