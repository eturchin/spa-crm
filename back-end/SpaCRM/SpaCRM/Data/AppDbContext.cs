using Microsoft.EntityFrameworkCore;
using SpaCRM.Data.Entities;
using SpaCRM.Interfaces;

namespace SpaCRM.Data;

public class AppDbContext(DbContextOptions<AppDbContext> opt) : DbContext(opt)
{
    public DbSet<BookingEntity> Bookings { get; set; }
    
    public DbSet<ServiceEntity> Services { get; set; }
    
    public DbSet<SpecialistEntity> Specialists { get; set; }
    
    public DbSet<RoleEntity> Roles { get; set; }

    public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<UserEntity>(e =>
        {
            e.HasKey(k => k.Id);
            e.HasIndex(i => i.Id);
            e.HasOne(x => x.RoleEntity)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.NoAction);
        });
        
        builder.Entity<SpecialistEntity>(e =>
        {
            e.HasKey(k => k.Id);
            e.HasIndex(i => i.Id);
            e.HasMany(specialist => specialist.Services)
                .WithMany(service => service.Specialists)
                .UsingEntity<Dictionary<string, object>>(
                    "SpecialistService",
                    j => j.HasOne<ServiceEntity>().WithMany().HasForeignKey("ServiceId"),
                    j => j.HasOne<SpecialistEntity>().WithMany().HasForeignKey("SpecialistId")
                );
        });
        
        builder.Entity<RoleEntity>().HasData(
            new RoleEntity { Id = Guid.Parse("1d128140-2409-47d7-b2c3-e4af5a23c175"), Name = "Admin" },
            new RoleEntity { Id = Guid.Parse("e54d1580-d267-4e87-abcd-9c8672831da9"), Name = "Moderator" },
            new RoleEntity { Id = Guid.Parse("855f7b5b-0a38-4d85-9afb-11c642bf47c2"), Name = "User" }
        );

        builder.Entity<ServiceEntity>().HasData(
            new ServiceEntity
            {
                Id = Guid.Parse("a106fbd0-e4fb-4f3c-854f-7d0d008567a7"), Title = "Спа-массаж \"Тонус\"", Price = 30
            },
            new ServiceEntity
            {
                Id = Guid.Parse("58ead15d-f289-4557-ba45-33dea86cfbae"), Title = "Спа-массаж \"Релакс\"", Price = 35
            },
            new ServiceEntity
                { Id = Guid.Parse("767fe2ca-6a2a-4d6f-873e-b622d0762e77"), Title = "Спа-массаж \"Спорт\"", Price = 45 },

            new ServiceEntity
            {
                Id = Guid.Parse("5cb6dd4c-bf69-40c7-8646-078b1ab62fdc"), Title = "Спа-массаж \"В 4 руки\"", Price = 55
            },
            new ServiceEntity
            {
                Id = Guid.Parse("cc550488-16ab-409d-8015-2f2951c22cc4"), Title = "Спа-массаж \"Стоун-ритуал (массаж горячими камнями)\"", Price = 105
            },
            new ServiceEntity
            {
                Id = Guid.Parse("d1540947-17d5-497d-9435-9fee024281fb"), Title = "Спа-массаж \"Тайский массаж\"", Price = 75
            }
        );
        
        builder.Entity<SpecialistEntity>().HasData(
            new SpecialistEntity
            {
                Id = Guid.Parse("e2b3e4b0-e5db-4814-b504-2aa28f683bb7"), FirstName = "Екатерина", LastName = "Иванова"
            },
            new SpecialistEntity
            {
                Id = Guid.Parse("aa5ee78e-201d-4c0f-9e08-30a7ed39f96c"), FirstName = "Андрей", LastName = "Золоторёв"
            },
            new SpecialistEntity
            {
                Id = Guid.Parse("8137d19c-84d1-499b-9277-de2bfff82fee"), FirstName = "Вероника", LastName = "Агафьева"
            },
            new SpecialistEntity
            {
                Id = Guid.Parse("c34d1827-9768-4873-8e8a-88bf6db5a2dc"), FirstName = "Владимир", LastName = "Квасов"
            }
        );
    }
    
    public override int SaveChanges()
    {
        ChangeTracker.DetectChanges();

        var added = ChangeTracker.Entries().Where(w => w.State == EntityState.Added).Select(s => s.Entity).ToList();

        foreach (var entry in added)
        {
            if (entry is not IEntity entity)
            {
                continue;
            }
            
            entity.CreatedDate = DateTime.UtcNow;
            entity.ModificationDate = DateTime.UtcNow;
        }

        var updated = ChangeTracker.Entries().Where(w => w.State == EntityState.Modified).Select(s => s.Entity)
            .ToList();

        foreach (var entry in updated)
        {
            if (entry is IEntity entity)
            {
                entity.ModificationDate = DateTime.UtcNow;
            }
        }

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        return Task.Run(SaveChanges, cancellationToken);
    }
}