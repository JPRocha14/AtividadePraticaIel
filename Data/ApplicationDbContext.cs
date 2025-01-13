using Microsoft.EntityFrameworkCore;
using IELStudentManager.Models;

namespace IELStudentManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Estudante> Estudantes { get; set; }
    }
}
