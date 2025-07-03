using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Application.Db;
using Inventory.Application.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Application.Services;

public class UnitService(AppDbContext db)
{
    public async Task<UnitEntity?> GetByIdAsync(int id)
    {
        return await db.Units.FindAsync(id);
    }

    public async Task<List<UnitEntity>> SearchAsync(
        string? name = null,
        bool? isActive = null,
        int pageNumber = 1,
        int pageSize = 20)
    {
        var query = db.Units.AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(u => u.Name.Contains(name));

        if (isActive.HasValue)
            query = query.Where(u => u.IsActive == isActive);

        return await query
            .OrderBy(u => u.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> AddAsync(UnitEntity entity)
    {
        db.Units.Add(entity);
        await db.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(UnitEntity entity)
    {
        db.Units.Update(entity);
        return await db.SaveChangesAsync() > 0;
    }

    public async Task<bool> SetActiveAsync(int id, bool isActive)
    {
        var entity = await db.Units.FindAsync(id);
        if (entity == null) return false;

        entity.IsActive = isActive;
        return await db.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await db.Units.FindAsync(id);
        if (entity == null) return false;

        entity.IsDeleted = true;
        return await db.SaveChangesAsync() > 0;
    }
}