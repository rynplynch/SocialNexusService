using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNexusService.Models;

namespace SocialNexusService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TimeController : ControllerBase
{
    private readonly ILogger<TimeController> _logger;

    public TimeController(ILogger<TimeController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetTime")]
    public ActionResult Get()
    {
        // c# class for handling dates and times
        // get the current date time value
        DateTime now = DateTime.Now;

        // also pass a formated version
        TimeSpan formated = now.TimeOfDay;

        // construct the Time object to return
        Time t = new Time() { Now = now, Formated = formated };

        // return status 200 along with the Time object
        return Ok(t);
    }
}
