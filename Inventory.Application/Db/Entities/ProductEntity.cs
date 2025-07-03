using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Application.Db.Entities
{
    [Table("Product")]
    public class ProductEntity : BaseEntity
    {

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = "";
        public int CategoryId { get; set; }
        public int UnitId { get; set; }
        public int MinStock { get; set; } = 0;

        [ForeignKey(nameof(CategoryId))]
        public virtual CategoryEntity? Category { get; set; }

        [ForeignKey(nameof(UnitId))]
        public virtual UnitEntity? Unit { get; set; }
    }
}
