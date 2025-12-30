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

    public virtual DbSet<service_request> service_requests { get; set; }

    public virtual DbSet<user> users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<service_request>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_ServiceRequests");

            entity.HasIndex(e => e.tracking_code, "IX_ServiceRequests_TrackingCode").IsUnique();

            entity.Property(e => e.customer_name).HasMaxLength(120);
            entity.Property(e => e.customer_phone).HasMaxLength(30);
            entity.Property(e => e.device_name).HasMaxLength(120);
            entity.Property(e => e.tracking_code).HasMaxLength(12);
        });

        modelBuilder.Entity<user>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK_Users");

            entity.HasIndex(e => e.username, "IX_Users_Username").IsUnique();

            entity.Property(e => e.role).HasMaxLength(20);
            entity.Property(e => e.username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
