using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using SocialNexusService.Models;

namespace SocialNexusService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorizedController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;

    public AuthorizedController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    [Authorize]
    [HttpPost(Name = "IsAuthorized")]
    public IActionResult IsAuthorized()
    {
        // return status 200 and the product object
        return Ok();
    }
}
