using System.Collections.Generic;
using System.Linq;
using Inventory.Application.Db;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Inventory.Application.Db.Entities;
using Inventory.Application.Models;


namespace Inventory.Application.Services;


public class ProductService(AppDbContext db)
{
    public ProductEntity? GetByIdAsync(int id)
    {
        return db.Products.Find(id);
    }

    public List<ProductListModel> SearchAsync(
        string? name = null,
        int? categoryId = null,
        int? unitId = null,
        int? minStock = null,
        bool? isActive = null,
        int pageNumber = 1,
        int pageSize = 20)
    {
        var query = db.Products
            .Include(x => x.Category)
            .Include(x => x.Unit)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(p => p.Name.Contains(name));

        if (categoryId.HasValue)
            query = query.Where(p => p.CategoryId == categoryId);

        if (unitId.HasValue)
            query = query.Where(p => p.UnitId == unitId);

        if (minStock.HasValue)
            query = query.Where(p => p.MinStock >= minStock);

        if (isActive.HasValue)
            query = query.Where(p => p.IsActive == isActive);

        return query
            .OrderBy(p => p.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(x => new ProductListModel
            {
                CategoryName = x.Category == null ? string.Empty : x.Category.Name,
                MinStock = x.MinStock,
                Id = x.Id,
                Name = x.Name,
                UnitName = x.Unit == null ? string.Empty : x.Unit.Name
            })
            .ToList();
    }

    public int Add(ProductEntity entity)
    {
        db.Products.Add(entity);
        db.SaveChanges();
        return entity.Id;
    }

    public bool Update(ProductEntity entity)
    {
        db.Products.Update(entity);
        return db.SaveChanges() > 0;
    }

    public bool SetActive(int id, bool isActive)
    {
        var entity = db.Products.Find(id);
        if (entity == null) return false;

        entity.IsActive = isActive;
        return db.SaveChanges() > 0;
    }

    public bool Delete(int id)
    {
        var entity = db.Products.Find(id);
        if (entity == null) return false;

        entity.IsDeleted = true;
        return db.SaveChanges() > 0;
    }
}
