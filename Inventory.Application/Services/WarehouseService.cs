using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Application.Db;
using Inventory.Application.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Application.Services;

public class WarehouseService(AppDbContext db)
{
    public async Task<WarehouseEntity?> GetByIdAsync(int id)
    {
        return await db.Warehouses.FindAsync(id);
    }

    public async Task<List<WarehouseEntity>> SearchAsync(
        string? name = null,
        bool? isActive = null,
        int pageNumber = 1,
        int pageSize = 20)
    {
        var query = db.Warehouses.AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(w => w.Name.Contains(name));

        if (isActive.HasValue)
            query = query.Where(w => w.IsActive == isActive);

        return await query
            .OrderBy(w => w.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> AddAsync(WarehouseEntity entity)
    {
        db.Warehouses.Add(entity);
        await db.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(WarehouseEntity entity)
    {
        db.Warehouses.Update(entity);
        return await db.SaveChangesAsync() > 0;
    }

    public async Task<bool> SetActiveAsync(int id, bool isActive)
    {
        var entity = await db.Warehouses.FindAsync(id);
        if (entity == null) return false;

        entity.IsActive = isActive;
        return await db.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await db.Warehouses.FindAsync(id);
        if (entity == null) return false;

        entity.IsDeleted = true;
        return await db.SaveChangesAsync() > 0;
    }
}
