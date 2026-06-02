using Microsoft.EntityFrameworkCore;
using TaskManager.Business.Abstraction.Interfaces.Services;
using TaskManager.Domain.Models;

namespace TaskManager.Infrastructure.Persistance.Context;

public class InitialDataSeeder
{
    private readonly ApplicationDbContext _context;
    private readonly IPasswordService _passwordService;

    public InitialDataSeeder(ApplicationDbContext context, IPasswordService passwordService)
    {
        _context = context;
        _passwordService = passwordService;
    }

    public async Task SeedDataAsync()
    {
        if (await _context.Set<Role>().AnyAsync(r => r.Title == "SysAdmin"))
            return;

        var sysAdminRole = new Role { Title = "SysAdmin" };
        await _context.Set<Role>().AddAsync(sysAdminRole);

        if (await _context.Set<Role>().AnyAsync(r => r.Title == "SysAdmin"))
            return;

        var adminRole = new Role { Title = "Admin" };
        await _context.Set<Role>().AddAsync(adminRole);

        if (await _context.Set<Role>().AnyAsync(r => r.Title == "User"))
            return;

        var userRole = new Role { Title = "User" };
        await _context.Set<Role>().AddAsync(userRole);

        await _context.SaveChangesAsync();

        if (await _context.Set<User>().AnyAsync(r => r.Username == "sysAdmin"))
            return;

        var hashedPassword = _passwordService.HashPassword("SysAdmin1381");

        var sysAdminUser = new User
        {
            Name = "sysAdmin",
            LastName = "sysAdmin",
            NationalCode = "0000000000",
            BirthDate = DateTime.UtcNow,
            Email = "admin@admin.com",
            PhoneNumber = "09129992222",
            EmailConfirmed = true,
            Username = "sysAdmin",
            PasswordHash = hashedPassword
        };

        _context.Set<User>().AddAsync(sysAdminUser);

        await _context.SaveChangesAsync();

        var userRoles = new List<UserRole>();

        userRoles.Add(new UserRole { UserId = sysAdminUser.Id, RoleId = sysAdminRole.Id });
        userRoles.Add(new UserRole { UserId = sysAdminUser.Id, RoleId = userRole.Id });

        await _context.Set<UserRole>().AddRangeAsync(userRoles);

        await _context.SaveChangesAsync();
    }
}