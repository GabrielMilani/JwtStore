﻿using JwtStore.Shared.Entities;
using JwtStore.Stock.Entities;

namespace JwtStore.Order.Entities;

public class OrderItem : Entity
{
    public OrderItem()
    {
    }

    public OrderItem(Product? product, decimal? quantity)
    {
        Product = product;
        Quantity = quantity;
        Price = product?.Price;
    }

    public Product? Product { get; private set; }
    public decimal? Quantity { get; private set; }
    public decimal? Price { get; private set; }
}