using Microsoft.EntityFrameworkCore;
using TestApp1.Models;

namespace TestApp1.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options)
        {

        }

        public DbSet<Spell> Spells=> Set<Spell>();
    }
}
