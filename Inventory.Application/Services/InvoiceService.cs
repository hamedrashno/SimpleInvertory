using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Application.Db;
using Inventory.Application.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Application.Services;

public class InvoiceService(AppDbContext db)
{
    public async Task<InvoiceEntity?> GetByIdAsync(int id)
    {
        return await db.Invoices.FindAsync(id);
    }

    public async Task<List<InvoiceEntity>> SearchAsync(
        string? title = null,
        string? description = null,
        string? partnerName = null,
        DateTime? createdAt = null,
        bool? isActive = null,
        int pageNumber = 1,
        int pageSize = 20)
    {
        var query = db.Invoices.AsQueryable();

        if (!string.IsNullOrWhiteSpace(title))
            query = query.Where(i => i.Title != null && i.Title.Contains(title));

        if (!string.IsNullOrWhiteSpace(description))
            query = query.Where(i => i.Description != null && i.Description.Contains(description));

        if (!string.IsNullOrWhiteSpace(partnerName))
            query = query.Where(i => i.PartnerName != null && i.PartnerName.Contains(partnerName));

        if (createdAt.HasValue)
            query = query.Where(i => i.CreatedAt.Date == createdAt.Value.Date);

        if (isActive.HasValue)
            query = query.Where(i => i.IsActive == isActive);

        return await query
            .OrderBy(i => i.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> AddAsync(InvoiceEntity entity)
    {
        db.Invoices.Add(entity);
        await db.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(InvoiceEntity entity)
    {
        db.Invoices.Update(entity);
        return await db.SaveChangesAsync() > 0;
    }

    public async Task<bool> SetActiveAsync(int id, bool isActive)
    {
        var entity = await db.Invoices.FindAsync(id);
        if (entity == null) return false;

        entity.IsActive = isActive;
        return await db.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await db.Invoices.FindAsync(id);
        if (entity == null) return false;

        entity.IsDeleted = true;
        return await db.SaveChangesAsync() > 0;
    }
}
