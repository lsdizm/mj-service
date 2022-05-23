using Microsoft.AspNetCore.Mvc;

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

    [HttpGet(Name = "GetWeatherForecast")]
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
