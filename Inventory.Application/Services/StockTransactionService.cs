using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Application.Db;
using Inventory.Application.Db.Entities;
using Inventory.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Application.Services;

public class StockTransactionService(AppDbContext db)
{
    public async Task<StockTransactionEntity?> GetByIdAsync(int id)
    {
        return await db.StockTransactions.FindAsync(id);
    }

    public async Task<int> AddAsync(StockTransactionEntity entity)
    {
        db.StockTransactions.Add(entity);
        await db.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<List<StockTransactionViewDto>> SearchAsync(
        int? productId = null,
        int? transactionTypeId = null,
        int? quantity = null,
        int? invoiceId = null,
        DateTime? createdAt = null,
        int? userId = null,
        int pageNumber = 1,
        int pageSize = 20)
    {
        var query = from st in db.StockTransactions
                    join p in db.Products on st.ProductId equals p.Id
                    join tt in db.TransactionTypes on st.TransactionTypeId equals tt.Id
                    join u in db.Users on st.UserId equals u.Id into userJoin
                    from uj in userJoin.DefaultIfEmpty()
                    where (!productId.HasValue || st.ProductId == productId)
                          && (!transactionTypeId.HasValue || st.TransactionTypeId == transactionTypeId)
                          && (!quantity.HasValue || st.Quantity == quantity)
                          && (!invoiceId.HasValue || st.InvoiceId == invoiceId)
                          && (!createdAt.HasValue || st.CreatedAt.Date == createdAt.Value.Date)
                          && (!userId.HasValue || st.UserId == userId)
                    select new StockTransactionViewDto
                    {
                        Id = st.Id,
                        ProductId = st.ProductId,
                        ProductName = p.Name,
                        TransactionTypeId = st.TransactionTypeId,
                        TransactionTypeName = tt.Name,
                        Quantity = st.Quantity,
                        InvoiceId = st.InvoiceId,
                        CreatedAt = st.CreatedAt,
                        UserId = st.UserId,
                        Username = uj != null ? uj.Username : null
                    };

        return await query
            .OrderByDescending(x => x.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<List<ProductInventoryModel>> SearchInventoryAsync(
        int? productId = null,
        int? categoryId = null,
        DateTime? fromDate = null,
        DateTime? toDate = null,
        int pageNumber = 1,
        int pageSize = 20)
    {
        var query = from st in db.StockTransactions
                    join p in db.Products on st.ProductId equals p.Id
                    join c in db.Categories on p.CategoryId equals c.Id
                    join u in db.Units on p.UnitId equals u.Id
                    join tt in db.TransactionTypes on st.TransactionTypeId equals tt.Id
                    where (!productId.HasValue || p.Id == productId)
                          && (!categoryId.HasValue || p.CategoryId == categoryId)
                          && (!fromDate.HasValue || st.CreatedAt >= fromDate)
                          && (!toDate.HasValue || st.CreatedAt <= toDate)
                    group new { st, p, c, u, tt } by new { p.Id, ProductName = p.Name, CategoryName = c.Name, UnitName = u.Name } into g
                    select new ProductInventoryModel()
                    {
                        Id = g.Key.Id,
                        Name = g.Key.ProductName,
                        CategoryName = g.Key.CategoryName,
                        UnitName = g.Key.UnitName,
                        CurrentStock = g.Sum(x => x.tt.IsIncrement ? x.st.Quantity : -x.st.Quantity)
                    };

        return await query
            .OrderByDescending(p => p.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
}
