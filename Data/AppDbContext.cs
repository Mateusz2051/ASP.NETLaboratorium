using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class AppDbContext : DbContext
{
    public DbSet<ComputerEntity> Computers { get; set; }
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
        modelBuilder.Entity<ComputerEntity>().HasData(
            new ComputerEntity() { Id = 1, Name = "Computer 1", Producer = "Dell", Cpu = "Intel i5", Ram = "8GB", Gpu = "Integrated", ProductionDate = new DateOnly(2025, 1, 1) },
            new ComputerEntity() { Id = 2, Name = "Computer 2", Producer = "HP", Cpu = "Ryzen 5", Ram = "16GB", Gpu = "RTX 3060", ProductionDate = new DateOnly(2024, 5, 20) }
        );
    }
}
