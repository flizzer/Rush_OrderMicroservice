using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderAPI.Data;

public class Order
{
    public long Id { get; set; }
    public long CustomerId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string? OrderNumber { get; set; }
    public decimal? Total { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public required string Status { get; set; }
}
