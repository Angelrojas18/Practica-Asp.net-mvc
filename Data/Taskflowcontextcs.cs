using Microsoft.EntityFrameworkCore;
using prueba_mvc.Models.Entities;

namespace prueba_mvc.Data
{
    public class Taskflowcontextcs : DbContext
    {
         public Taskflowcontextcs(DbContextOptions options  ) : base(options)
        {
        }


        public DbSet<TaskItem> tasks { get; set; }
        public DbSet<Category> categories { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
