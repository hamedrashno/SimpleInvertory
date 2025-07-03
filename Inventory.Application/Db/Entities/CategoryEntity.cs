using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Application.Db.Entities
{

    [Table("Category")]

    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; } = "";
    }
}