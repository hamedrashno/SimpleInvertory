using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Application.Db;
using Inventory.Application.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Application.Services;

public class UserService(AppDbContext db)
{
    public async Task<UserEntity?> GetByIdAsync(int id)
    {
        return await db.Users.FindAsync(id);
    }

    public async Task<List<UserEntity>> SearchAsync(
        string? username = null,
        bool? isActive = null,
        int pageNumber = 1,
        int pageSize = 20)
    {
        var query = db.Users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(username))
            query = query.Where(u => u.Username.Contains(username));

        if (isActive.HasValue)
            query = query.Where(u => u.IsActive == isActive);

        return await query
            .OrderBy(u => u.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> AddAsync(UserEntity entity)
    {
        db.Users.Add(entity);
        await db.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> UpdatePasswordAsync(int id, string newPassword)
    {
        var entity = await db.Users.FindAsync(id);
        if (entity == null) return false;

        // هش کردن پسورد جدید قبل از ذخیره‌سازی
        entity.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
        return await db.SaveChangesAsync() > 0;
    }

    public async Task<UserEntity?> FindByCredentialsAsync(string username, string password)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
        return await db.Users
            .FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == passwordHash);
    }

    public async Task<bool> SetActiveAsync(int id, bool isActive)
    {
        var entity = await db.Users.FindAsync(id);
        if (entity == null) return false;

        entity.IsActive = isActive;
        return await db.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await db.Users.FindAsync(id);
        if (entity == null) return false;

        entity.IsDeleted = true;
        return await db.SaveChangesAsync() > 0;
    }
}
