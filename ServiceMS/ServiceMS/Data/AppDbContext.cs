using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ServiceMS.Models.Db;

namespace ServiceMS.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ServiceRequest> ServiceRequests { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ServiceRequest>(entity =>
        {
            entity.HasIndex(e => e.TrackingCode, "IX_ServiceRequests_TrackingCode").IsUnique();

            entity.Property(e => e.CustomerName).HasMaxLength(120);
            entity.Property(e => e.CustomerPhone).HasMaxLength(30);
            entity.Property(e => e.DeviceName).HasMaxLength(120);
            entity.Property(e => e.TrackingCode).HasMaxLength(12);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Username, "IX_Users_Username").IsUnique();

            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
