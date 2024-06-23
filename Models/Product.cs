using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SocialNexusService.Models;

public class Product
{
    // do not allow this data to be passed via json
    // Id is used by the database
    [JsonIgnore]
    public int Id { get; set; }

    public int OwnerId { get; set; }

    [StringLength(15)]
    public required string Title { get; set; }
    public required string Description { get; set; }
}
