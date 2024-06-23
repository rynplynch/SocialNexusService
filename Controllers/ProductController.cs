using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;
using SocialNexusService.Models;

namespace SocialNexusService.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
public class ProductsController : ControllerBase
{
    // a list of products
    // TODO make this data stored in database
    private static readonly List<Product> products = new List<Product>();

    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Add the passed in product to the products list
    /// </summary>
    /// <returns><c>IAcIActionResult</c></returns>
    [HttpPost(Name = "PostProduct")]
    [ValidateAntiForgeryToken]
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
