using Microsoft.EntityFrameworkCore;
using ToDoAplication.Models;

namespace ToDoAplication.Database
{
    public class ToDoDbContext:DbContext
    {
      
        public ToDoDbContext(DbContextOptions<ToDoDbContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ToDoMapping());
        }
        public DbSet<ToDo> toDos{ get; set; }


    }
}
