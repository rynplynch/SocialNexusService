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
        DateTime t = DateTime.Now;

        return Ok(t.TimeOfDay);
    }
}
