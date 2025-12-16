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
            Producer = entity.Producer,
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
            Producer = model.Producer,
            Cpu = model.Cpu,
            Ram = model.Ram,
            Gpu = model.Gpu,
            ProductionDate = model.ProductionDate,
        };
    }
}
