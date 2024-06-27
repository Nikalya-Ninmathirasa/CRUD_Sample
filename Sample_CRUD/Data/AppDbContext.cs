using Microsoft.EntityFrameworkCore;
using Sample_CRUD.Models;

namespace Sample_CRUD.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        public DbSet<Category> Category { get; set; }
    }

   
}
