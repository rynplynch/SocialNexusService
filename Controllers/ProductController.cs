using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using SocialNexusService.Models;

namespace SocialNexusService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    // a list of products
    // TODO make this data stored in database
    private static readonly List<Product> products = new List<Product>();

    // used to set primary id, to be removed when db added
    private static int counter = 0;

    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    [Authorize]
    [HttpPost(Name = "PostProduct")]
    [RequiredScope("product.create")]
    public IActionResult Create(Product product)
    {
        // set the id of the product to the length of the list
        product.Id = products.Count;

        // use the user's UID to mark them as the owner

        products.Add(product);

        return Ok(product);
    }

    // return all the products
    [HttpGet(Name = "GetProducts")]
    public IEnumerable<Product> Get()
    {
        return products.AsEnumerable();
    }

    // // return only the products the user created
    // [HttpGet(Name = "GetProduct")]
    // public IActionResult GetById(int id)
    // {
    //     // loop through all the products
    //     foreach (Product p in products)
    //     {
    //         if (p.Id == id)
    //             return Ok();
    //     }

    //     return NotFound();
    // }
}
