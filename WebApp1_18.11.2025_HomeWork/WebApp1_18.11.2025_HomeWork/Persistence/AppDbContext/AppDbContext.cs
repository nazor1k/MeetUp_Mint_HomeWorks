


using Microsoft.EntityFrameworkCore;
using WebApp1_18._11._2025_HomeWork.Domain.Models;

namespace WebApp1_18._11._2025_HomeWork.Persistence.AppDbContext
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<TodoItem> TodoItems { get; set; }

    }
}
