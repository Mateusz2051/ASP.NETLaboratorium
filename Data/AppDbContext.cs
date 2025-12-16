using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<ComputerEntity> Computers { get; set; }
    public DbSet<ManufacturerEntity> Manufacturers { get; set; }
    private string DbPath { get; set; }

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "computers.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        

        string ADMIN_ID = Guid.NewGuid().ToString();
        string ROLE_ID = Guid.NewGuid().ToString();


        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Name = "admin",
            NormalizedName = "ADMIN",
            Id = ROLE_ID,
            ConcurrencyStamp = ROLE_ID
        });

        var admin = new IdentityUser
        {
            Id = ADMIN_ID,
            Email = "adam@wsei.edu.pl",
            EmailConfirmed = true,
            UserName = "adam",
            NormalizedUserName = "ADAM",
            NormalizedEmail = "ADAM@WSEI.EDU.PL"
        };

        PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
        admin.PasswordHash = ph.HashPassword(admin, "1234abcd!@#$ABCD");
        
        modelBuilder.Entity<IdentityUser>().HasData(admin);

        modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

        string USER_ID = Guid.NewGuid().ToString();
        string USER_ROLE_ID = Guid.NewGuid().ToString();

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Name = "user",
            NormalizedName = "USER",
            Id = USER_ROLE_ID,
            ConcurrencyStamp = USER_ROLE_ID
        });

        var student = new IdentityUser
        {
            Id = USER_ID,
            Email = "student@wsei.edu.pl",
            EmailConfirmed = true,
            UserName = "student",
            NormalizedUserName = "STUDENT",
            NormalizedEmail = "STUDENT@WSEI.EDU.PL"
        };
        student.PasswordHash = ph.HashPassword(student, "1234abcd!@#$ABCD");
        modelBuilder.Entity<IdentityUser>().HasData(student);

        modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = USER_ROLE_ID,
                UserId = USER_ID
            });

        modelBuilder.Entity<ManufacturerEntity>()
            .OwnsOne(e => e.Address);

        modelBuilder.Entity<ComputerEntity>()
            .HasOne(e => e.Manufacturer)
            .WithMany(m => m.Computers)
            .HasForeignKey(e => e.ManufacturerId);

        modelBuilder.Entity<ManufacturerEntity>()
            .ToTable("manufacturers")
            .HasData(
                new ManufacturerEntity() { Id = 1, Name = "Dell", Nip = "1234567890", Regon = "12345" },
                new ManufacturerEntity() { Id = 2, Name = "HP", Nip = "0987654321", Regon = "54321" }
            );

        modelBuilder.Entity<ManufacturerEntity>()
            .OwnsOne(e => e.Address)
            .HasData(
                new { ManufacturerEntityId = 1, City = "Kraków", Street = "Wadowicka 1", PostalCode = "30-001", Region = "Małopolska" },
                new { ManufacturerEntityId = 2, City = "Warszawa", Street = "Jerozolimskie 100", PostalCode = "00-001", Region = "Mazowieckie" }
            );

        modelBuilder.Entity<ComputerEntity>().HasData(
            new ComputerEntity() { Id = 1, Name = "Inspiron", ManufacturerId = 1, Cpu = "Intel i5", Ram = "8GB", Gpu = "Integrated", ProductionDate = new DateOnly(2025, 1, 1) },
            new ComputerEntity() { Id = 2, Name = "Pavilion", ManufacturerId = 2, Cpu = "Ryzen 5", Ram = "16GB", Gpu = "RTX 3060", ProductionDate = new DateOnly(2024, 5, 20) }
        );
    }
}
