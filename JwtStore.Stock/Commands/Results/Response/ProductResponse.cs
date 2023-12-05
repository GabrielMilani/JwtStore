namespace JwtStore.Stock.Commands.Results.Response;

public class ProductResponse
{
    public ProductResponse(int? id, string? title, string? description, decimal? price, decimal? quantityOnHand, int? categoryId)
    {
        Id = id;
        Title = title;
        Description = description;
        Price = price;
        QuantityOnHand = quantityOnHand;
        CategoryId = categoryId;
    }

    public int? Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public decimal? QuantityOnHand { get; set; }
    public int? CategoryId { get; set; }
}