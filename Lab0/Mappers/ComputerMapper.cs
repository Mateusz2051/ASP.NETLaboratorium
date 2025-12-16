using Data.Entities;
using Lab0.Models;

namespace Lab0.Mappers;

public class ComputerMapper
{
    public static Computer FromEntity(ComputerEntity entity)
    {
        return new Computer()
        {
            Id = entity.Id,
            Name = entity.Name,
            ManufacturerId = entity.ManufacturerId,
            ManufacturerName = entity.Manufacturer?.Name ?? "",
            Cpu = entity.Cpu,
            Ram = entity.Ram,
            Gpu = entity.Gpu,
            ProductionDate = entity.ProductionDate,
        };
    }

    public static ComputerEntity ToEntity(Computer model)
    {
        return new ComputerEntity()
        {
            Id = model.Id,
            Name = model.Name,
            ManufacturerId = model.ManufacturerId,
            Cpu = model.Cpu,
            Ram = model.Ram,
            Gpu = model.Gpu,
            ProductionDate = model.ProductionDate,
        };
    }
}
