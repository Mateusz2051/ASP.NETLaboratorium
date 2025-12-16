using Data;
using Data.Entities;
using Lab0.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Lab0.Models;

public class EFComputerService : IComputerService
{
    private readonly AppDbContext _context;

    public EFComputerService(AppDbContext context)
    {
        _context = context;
    }

    public List<Computer> GetComputers()
    {
        return _context.Computers
            .Include(c => c.Manufacturer)
            .Select(e => ComputerMapper.FromEntity(e))
            .ToList();
    }

    public Paging.PagingListAsync<Computer> GetComputersForPaging(int page, int size)
    {
        return Paging.PagingListAsync<Computer>.Create(
            (p, s) =>
            {
                var data = _context.Computers
                    .Include(c => c.Manufacturer)
                    .OrderBy(c => c.Name)
                    .Skip((p - 1) * s)
                    .Take(s)
                    .ToList();
                return ToAsyncEnumerable(data.Select(e => ComputerMapper.FromEntity(e)));
            },
            _context.Computers.Count(),
            page,
            size);
    }

    private async IAsyncEnumerable<T> ToAsyncEnumerable<T>(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            yield return item;
            await Task.CompletedTask;
        }
    }

    public void AddComputer(Computer computer)
    {
        _context.Computers.Add(ComputerMapper.ToEntity(computer));
        _context.SaveChanges();
    }

    public bool UpdateComputer(Computer computer)
    {
        var entity = _context.Computers.Find(computer.Id);
        if (entity is null)
        {
            return false;
        }

        entity.Name = computer.Name;
        entity.ManufacturerId = computer.ManufacturerId;
        entity.Cpu = computer.Cpu;
        entity.Ram = computer.Ram;
        entity.Gpu = computer.Gpu;
        entity.ProductionDate = computer.ProductionDate;

        _context.Computers.Update(entity);
        _context.SaveChanges();
        return true;
    }

    public bool DeleteComputerById(int id)
    {
        var entity = _context.Computers.Find(id);
        if (entity is null)
        {
            return false;
        }

        _context.Computers.Remove(entity);
        _context.SaveChanges();
        return true;
    }

    public Computer? GetComputerById(int id)
    {
        var entity = _context.Computers.Include(c => c.Manufacturer).FirstOrDefault(c => c.Id == id);
        return entity is null ? null : ComputerMapper.FromEntity(entity);
    }

    public List<ManufacturerEntity> FindAllManufacturers()
    {
        return _context.Manufacturers.ToList();
    }

    public void AddManufacturer(ManufacturerEntity manufacturer)
    {
        _context.Manufacturers.Add(manufacturer);
        _context.SaveChanges();
    }

    public bool UpdateManufacturer(ManufacturerEntity manufacturer)
    {
        var entity = _context.Manufacturers.Find(manufacturer.Id);
        if (entity is null) return false;

        entity.Name = manufacturer.Name;
        entity.Nip = manufacturer.Nip;
        entity.Regon = manufacturer.Regon;
        entity.Address = manufacturer.Address;

        _context.Manufacturers.Update(entity);
        _context.SaveChanges();
        return true;
    }

    public bool DeleteManufacturer(int id)
    {
        var entity = _context.Manufacturers.Find(id);
        if (entity is null) return false;

        _context.Manufacturers.Remove(entity);
        _context.SaveChanges();
        return true;
    }

    public ManufacturerEntity? GetManufacturerById(int id)
    {
        return _context.Manufacturers.Find(id);
    }
}
