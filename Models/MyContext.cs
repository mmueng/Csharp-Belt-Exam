using Microsoft.EntityFrameworkCore;

namespace Belt_Exam.Models
{
    public class MyContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> User { get; set; }
        public DbSet<Activitys> Activitys { get; set; }

        public DbSet<Association> association { get; set; }
    }
}