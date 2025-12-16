using Data;
using Data.Entities;
using Lab0.Mappers;

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
        return _context.Computers.Select(e => ComputerMapper.FromEntity(e)).ToList();
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
        entity.Producer = computer.Producer;
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
        var entity = _context.Computers.Find(id);
        return entity is null ? null : ComputerMapper.FromEntity(entity);
    }
}
