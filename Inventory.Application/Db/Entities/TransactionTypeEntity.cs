using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Application.Db.Entities
{
    [Table("TransactionType")]
    public class TransactionTypeEntity:BaseEntity
    {
        public string Name { get; set; } = "";
        public bool IsIncrement { get; set; }
    }
}