using Microsoft.EntityFrameworkCore;
using ServiceMS.Models;

namespace ServiceMS.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<ServiceRequest> ServiceRequests => Set<ServiceRequest>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ServiceRequest>()
            .HasIndex(x => x.TrackingCode)
            .IsUnique();
    }
}