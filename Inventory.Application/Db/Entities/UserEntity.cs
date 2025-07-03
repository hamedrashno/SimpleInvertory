using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Application.Db.Entities
{
    [Table("User")]
    public class UserEntity:BaseEntity
    {
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = "";
    }
}