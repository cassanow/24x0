using _24x0.Model;
using Microsoft.EntityFrameworkCore;

namespace _24x0.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    
    public DbSet<Piloto> Pilotos { get; set; }
    public DbSet<Construtor> Construtores { get; set; }
    public DbSet<DesempenhoPiloto> DesempenhosPiloto { get; set; }
    public DbSet<DesempenhoConstrutor> DesempenhosConstrutor { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DesempenhoConstrutor>()
            .ToTable("DesempenhosConstrutor");
    }
}