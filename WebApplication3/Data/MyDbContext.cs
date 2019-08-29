using Microsoft.EntityFrameworkCore;


namespace FamilyTreeVueDb.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext (DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<FamilyTreeVueDb.Model.Person> Person { get; set; }
    }
}
