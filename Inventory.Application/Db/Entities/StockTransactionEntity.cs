using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Application.Db.Entities
{
    [Table("StockTransaction")]
    public class StockTransactionEntity : BaseEntity
    {
        public int ProductId { get; set; }
        public string Description { get; set; }

        public int TransactionTypeId { get; set; }

        public int Quantity { get; set; }

        public int? InvoiceId { get; set; }

        public int UserId { get; set; }


        [ForeignKey(nameof(ProductId))]
        public virtual ProductEntity? Product { get; set; }

        [ForeignKey(nameof(TransactionTypeId))]
        public virtual TransactionTypeEntity? TransactionType { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual UserEntity? User { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        public virtual InvoiceEntity? Invoice { get; set; }
    }
}