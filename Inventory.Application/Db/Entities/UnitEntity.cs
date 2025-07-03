using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Application.Db.Entities
{
    [Table("Unit")]
    public class UnitEntity:BaseEntity
    {
        public string Name { get; set; } = "";
    }
}