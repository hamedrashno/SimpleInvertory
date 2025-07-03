using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Application.Db.Entities
{
    [Table("Invoice")]
    public class InvoiceEntity:BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? PartnerName { get; set; }
    }
}