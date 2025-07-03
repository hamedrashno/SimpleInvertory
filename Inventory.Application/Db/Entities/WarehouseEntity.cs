using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Application.Db.Entities
{
    [Table("Warehouse")]
    public class WarehouseEntity:BaseEntity
    {
        public string Name { get; set; } = "";
    }
}