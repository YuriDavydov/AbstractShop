﻿namespace DatabaseImplement.Models;

/// <summary>
/// Сколько компонентов, требуется при изготовлении изделия
/// </summary>
public class ProductComponent
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ComponentId { get; set; }
    public int Count { get; set; }
    public virtual Component Component { get; set; }
    public virtual Product Product { get; set; }
}

