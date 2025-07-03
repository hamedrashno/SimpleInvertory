using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Application.Db;
using Inventory.Application.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Application.Services;

public class CategoryService(AppDbContext db)
{
    public async Task<CategoryEntity?> GetByIdAsync(int id)
    {
        return await db.Categories.FindAsync(id);
    }

    public List<CategoryEntity> SearchAsync(
        string? name = null,
        bool? isActive = null,
        int pageNumber = 1,
        int pageSize = 20)
    {
        var query = db.Categories.AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(c => c.Name.Contains(name));

        if (isActive.HasValue)
            query = query.Where(c => c.IsActive == isActive);

        return  query
            .OrderBy(c => c.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public async Task<int> AddAsync(CategoryEntity entity)
    {
        db.Categories.Add(entity);
        await db.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(CategoryEntity entity)
    {
        db.Categories.Update(entity);
        return await db.SaveChangesAsync() > 0;
    }

    public async Task<bool> SetActiveAsync(int id, bool isActive)
    {
        var entity = await db.Categories.FindAsync(id);
        if (entity == null) return false;

        entity.IsActive = isActive;
        return await db.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await db.Categories.FindAsync(id);
        if (entity == null) return false;

        entity.IsDeleted = true;
        return await db.SaveChangesAsync() > 0;
    }
}
