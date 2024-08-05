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
    private readonly IConfiguration _config;

    public ProductsController(ILogger<ProductsController> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }

    [Authorize]
    [HttpPost(Name = "PostProduct")]
    [RequiredScope("product.create")]
    public IActionResult Create(Product product)
    {
        // set the id of the product to value of counter
        product.PrimaryKey = counter;

        // increment to counter for next product
        counter++;

        // extract user object id from access_token
        string? callersUserID = User.FindFirstValue("sub");

        // save who created the product
        product.OwnerId = callersUserID!;

        // add the product to the list
        products.Add(product);

        // return status 200 and the product object
        return Ok(product);
    }

    // return all the products
    [HttpGet(Name = "GetProducts")]
    public IEnumerable<Product> Get()
    {
        return products.AsEnumerable();
    }

    [Authorize]
    [HttpDelete(Name = "DeleteProduct")]
    [RequiredScope("product.create")]
    public IActionResult Delete(int id)
    {
        // extract user object id from access_token
        string? callersUserID = User.FindFirstValue("sub");

        // loop over the list of products
        for (int i = 0; i < products.Count; i++)
        {
            // get the product at the current index
            Product p = products.ElementAt(i);

            // if the id of the product matches and
            if (p.PrimaryKey == id)
            {
                // and the call created the product
                if (p.OwnerId == callersUserID)
                {
                    // delete the product
                    products.RemoveAt(i);

                    // return status 200 and the deleted product
                    return Ok(p);
                }
                // if the product was not created by the caller
                else
                    // let them know they are not authorized
                    return Unauthorized(p);
            }
        }

        // we searched the list and found nothing
        return NoContent();
    }
}
