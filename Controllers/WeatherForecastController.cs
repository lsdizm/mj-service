using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using MySql;
// using Oracle.ManagedDataAccess.Client;

namespace mj_service.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    // [Authorize]
    // [EnableCors("MJCorsPolish")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }


    [HttpGet("connect")]
    // [Authorize]
    // [EnableCors("MJCorsPolish")]
    public IActionResult ConnectDatabase()
    {
        var result = string.Empty;
        var _connectionString =  "host=152.70.232.248;port=3306;user id=mj;password=!Dhfkzmffkdnem1;database=mj;";

        using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_connectionString)) {

            connection.Open();
            
        }
   
        // var _host = "adb.ap-seoul-1.oraclecloud.com";
        // var _serviceName = "g4b9432fe3b1aeb_mj_high.adb.oraclecloud.com";
        // var _userId = "oracle";
        // var _passWord = "!Dhfkzmffkdnem1";
        // //var _security = "CN=adb.ap-seoul-1.oraclecloud.com, OU=Oracle ADB SEOUL, O=Oracle Corporation, L=Redwood City, ST=California, C=US";
        // var _connectionString = 
        //     //$"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={_host})(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={_serviceName}))(security=(ssl_server_cert_dn={_security})));" + 
        //     $"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={_host})(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={_serviceName})));" + 
        //     $"User ID={_userId};Password={_passWord};Connection Timeout=30;";
        

        // _connectionString = @"(description= (retry_count=20)(retry_delay=3)(address=(protocol=tcps)(port=1522)(host=adb.ap-seoul-1.oraclecloud.com))(connect_data=(service_name=g4b9432fe3b1aeb_mj_high.adb.oraclecloud.com))(security=(ssl_server_cert_dn=""\CN=adb.ap-seoul-1.oraclecloud.com, OU=Oracle ADB SEOUL, O=Oracle Corporation, L=Redwood City, ST=California, C=US""\)))";
        // try
        // {
        //     var _conn = new OracleConnection(_connectionString);
        //     _conn.Open();

        //     result = "OK";
        // }
        // catch(Exception ex)
        // {
        //     result = ex.ToString();
        // }
        



        return Ok(result);
    }
}



/*
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using CHIS.DrugReference.Application.Models;

namespace CHIS.DrugReference.Application.Proxies
{
    public class MfdsProxy : IMfdsProxy
    {
        public MfdsResponse RetrieveMfds(string startChangeDate, string endChangeDate, int pageNo, int takeCount)
        {
            // TO-DO : URL, service key를 db로 관리
            var url = "http://apis.data.go.kr/1471057/MdcinPrductPrmisnInfoService/getMdcinPrductItem"; // URL
            var serviceKey = "gKTNtNTmRwLKq8JD1zkpfaggw28u5FJ%2F%2BCZ3PpQxX15sOjBrSoWWMf2oSe3dG%2BJqsIcXim5EW5xlTx1jxGqKgA%3D%3D"; // Service Key"

            var path = url + "?ServiceKey=" + serviceKey + "&pageNo=" + pageNo.ToString() + "&numOfRows=" + takeCount +
                "&start_change_date=" + startChangeDate + "&end_change_date=" + endChangeDate;

            var request = (HttpWebRequest)WebRequest.Create(path);
            request.Method = "GET";

            using (var response = request.GetResponse())
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                var serializer = new XmlSerializer(typeof(MfdsResponse), new XmlRootAttribute("response"));
                var result = (MfdsResponse)serializer.Deserialize(reader); //직렬화되어있는 xml파일인 reader를 MfdsResponse로 역직렬.
                return result;
            }
        }
    }
}


*/
