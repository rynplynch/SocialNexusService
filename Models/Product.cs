using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SocialNexusService.Models;

public class Product
{
    public required int PrimaryKey { get; set; }

    public required string OwnerId { get; set; }

    [StringLength(15)]
    public required string Title { get; set; }
    public required string Description { get; set; }
}
