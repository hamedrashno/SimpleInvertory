using System;

namespace Inventory.Application.Models;

public class StockTransactionModels
{
    
}

public class StockTransactionViewDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = "";
    public int TransactionTypeId { get; set; }
    public string TransactionTypeName { get; set; } = "";
    public int Quantity { get; set; }
    public int? InvoiceId { get; set; }
    public DateTime CreatedAt { get; set; }
    public int? UserId { get; set; }
    public string? Username { get; set; }
}