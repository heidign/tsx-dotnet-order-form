using Microsoft.EntityFrameworkCore;

namespace tsx_react_project.Models
{

    public class ApplicationContext : DbContext

    {
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}
    public DbSet<Jewelry> JewelryPieces { get; set; }
    public DbSet<Stone> Cabs { get; set; }
    }
    
}