using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Application.Db;
using Inventory.Application.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Application.Services;

public class TransactionTypeService(AppDbContext db)
{
    public async Task<TransactionTypeEntity?> GetByIdAsync(int id)
    {
        return await db.TransactionTypes.FindAsync(id);
    }

    public async Task<List<TransactionTypeEntity>> SearchAsync(
        string? name = null,
        bool? isIncrement = null,
        bool? isActive = null,
        int pageNumber = 1,
        int pageSize = 20)
    {
        var query = db.TransactionTypes.AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(t => t.Name.Contains(name));

        if (isIncrement.HasValue)
            query = query.Where(t => t.IsIncrement == isIncrement);

        if (isActive.HasValue)
            query = query.Where(t => t.IsActive == isActive);

        return await query
            .OrderBy(t => t.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> AddAsync(TransactionTypeEntity entity)
    {
        db.TransactionTypes.Add(entity);
        await db.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(TransactionTypeEntity entity)
    {
        db.TransactionTypes.Update(entity);
        return await db.SaveChangesAsync() > 0;
    }

    public async Task<bool> SetActiveAsync(int id, bool isActive)
    {
        var entity = await db.TransactionTypes.FindAsync(id);
        if (entity == null) return false;

        entity.IsActive = isActive;
        return await db.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await db.TransactionTypes.FindAsync(id);
        if (entity == null) return false;

        entity.IsDeleted = true;
        return await db.SaveChangesAsync() > 0;
    }
}
