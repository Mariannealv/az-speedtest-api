using Microsoft.AspNetCore.Mvc;
using SpeedTestApi.Models;
namespace SpeedTestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SpeedTestController : ControllerBase
{
    // GET speedtest/ping
    [Route("ping")]
    [HttpGet]
    public string Ping()
    {
        return "PONG";
    }

    // POST speedtest/
    [HttpPost]
    public string UploadSpeedTest([FromBody] TestResult speedTest)
    {
        return $"Got a TestResult from { speedTest.User } with download { speedTest.Data.Speeds.Download } Mbps.";
    }

}