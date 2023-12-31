﻿using BusinessLogic.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatabaseImplement.Models;

public class Order
{
    [NotMapped]
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int? ImplementerId { get; set; }
    public int Count { get; set; }
    public decimal Sum { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime DateCreate { get; set; }
    public DateTime? DateImplement { get; set; }
    public virtual Product Product { get; set; }
    public virtual Implementer Implementer { get; set; }
}
