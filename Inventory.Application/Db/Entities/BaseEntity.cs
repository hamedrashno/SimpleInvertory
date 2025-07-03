using System;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Application.Db.Entities;
public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsDeleted { get; set; } = false;

    public bool IsActive { get; set; } = true;
}
