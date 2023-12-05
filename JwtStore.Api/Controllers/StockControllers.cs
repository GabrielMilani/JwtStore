using JwtStore.Infra.Data;
using JwtStore.Shared.Commands;
using JwtStore.Stock.Commands;
using JwtStore.Stock.Commands.Results;
using JwtStore.Stock.Commands.Results.Response;
using JwtStore.Stock.Handlers;
using JwtStore.Stock.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JwtStore.Api.Controllers;

[ApiController]
public class StockControllers : ControllerBase
{
    #region Category Create
    [Authorize(Roles = "ADMIN")]
    [HttpPost("v1/stock/categories")]
    public ICommandResult Post([FromBody] CategoryCreateCommand command,
        [FromServices] CategoryCreateHandler handler)
    {
        return (CategoryCommandResult)handler.Handle(command);
    }
    #endregion

    #region Category Update
    [Authorize(Roles = "ADMIN")]
    [HttpPut("v1/stock/categories")]
    public ICommandResult Put([FromBody] CategoryUpdateCommand command,
                             [FromServices] CategoryUpdateHandler handler)
    {
        return (CategoryCommandResult)handler.Handle(command);
    }
    #endregion

    #region Category Select
    [Authorize(Roles = "ADMIN")]
    [HttpGet("v1/stock/categories")]
    public ICommandResult GetCategory(AppDbContext context)
    {
        var categories = context.Categories.AsNoTracking().ToListAsync().Result;
        var listCategoryResponse = new List<CategoryResponse>();
        foreach (var category in categories)
        {
            listCategoryResponse.Add(new CategoryResponse(category.Id, category.Title));
        }
        return new CategoryCommandResult(true, "Categories List", listCategoryResponse);
    }
    #endregion

    #region Category Select by categoryID
    [Authorize(Roles = "ADMIN")]
    [HttpGet("v1/stock/categories/{id:int}")]
    public ICommandResult GetbyId([FromRoute] int id,
                                  [FromServices] ICategorySelectRepository categorySelect)
    {
        var category = categorySelect.GetById(id).Result;
        if (category is null)
            return new CommandResult(false, "Category searsh failed");
        var listCategoryResponse = new List<CategoryResponse>();
        listCategoryResponse.Add(new CategoryResponse(category.Id, category.Title));
        return new CategoryCommandResult(true, "Category", listCategoryResponse);
    }
    #endregion

    #region Product Create
    [Authorize(Roles = "ADMIN")]
    [HttpPost("v1/stock/products")]
    public ICommandResult Post([FromBody] ProductCreateCommand command,
                               [FromServices] ProductCreateHandler handler)
    {
        return (ProductCommandResult)handler.Handle(command);
    }
    #endregion

    #region Product Update
    [Authorize(Roles = "ADMIN")]
    [HttpPut("v1/stock/products")]
    public ICommandResult Put([FromBody] ProductUpdateCommand command,
                              [FromServices] ProductUpdateHandler handler)
    {
        return (ProductCommandResult)handler.Handle(command);
    }
    #endregion

    #region Product Select
    [Authorize(Roles = "ADMIN")]
    [HttpGet("v1/stock/products")]
    public ICommandResult GetProduct(AppDbContext context)
    {
        var products = context.Products.AsNoTracking().ToListAsync().Result;
        var listProductResponse = new List<ProductResponse>();
        foreach (var product in products)
        {
            listProductResponse.Add(new ProductResponse(product.Id, product.Title, product.Description, product.Price,
                                                        product.QuantityOnHand, product.CategoryId));
        }
        return new ProductCommandResult(true, "Product List", listProductResponse);
    }
    #endregion

    #region Product Select by ProductID
    [Authorize(Roles = "ADMIN")]
    [HttpGet("v1/stock/products/{id:int}")]
    public ICommandResult GetbyId([FromRoute] int id,
                                  [FromServices] IProductSelectRepository productSelect)
    {
        var product = productSelect.GetById(id).Result;
        if (product is null)
            return new CommandResult(false, "falha ao buscar por produto");
        var listProductResponse = new List<ProductResponse>();
        listProductResponse.Add(new ProductResponse(product.Id, product.Title, product.Description, product.Price,
                                                    product.QuantityOnHand, product.CategoryId));
        return new ProductCommandResult(true, "Product ", listProductResponse);
    }
    #endregion

}