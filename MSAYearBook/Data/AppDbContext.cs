using Microsoft.EntityFrameworkCore;
using MSAYearBook.Models;

namespace MSAYearBook.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
