using Microsoft.EntityFrameworkCore;
using WebApp.DTO;

namespace WebApp;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    // public DbSet<Journey> Journey { get; set; } = default!;
}