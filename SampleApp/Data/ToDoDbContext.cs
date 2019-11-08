
using Microsoft.EntityFrameworkCore;

namespace BIF4DotNetDemo.Data
{
    public class ToDoDbContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }

        public ToDoDbContext(DbContextOptions<ToDoDbContext> option)
            : base(option)
        {
            
        }
    }
}