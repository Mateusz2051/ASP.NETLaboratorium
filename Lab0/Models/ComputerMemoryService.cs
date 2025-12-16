namespace Lab0.Models;

public class ComputerMemoryService: IComputerService
{
    private static Dictionary<int, Computer> _computers = new()
    {
        { 1, new Computer() { Id = 1, Name = "Computer 1", ManufacturerId = 1, ManufacturerName= "Dell", Cpu = "It", Gpu = "Ad", Ram = "T", ProductionDate = DateOnly.Parse("2025-01-01") } },
        { 2, new Computer() { Id = 2, Name = "Computer 2", ManufacturerId = 2, ManufacturerName= "HP", Cpu = "Ad", Gpu = "Nv", Ram = "Q",  ProductionDate = DateOnly.Parse("2024-01-02") } },
    };
    
    public List<Computer> GetComputers()
    {
        return _computers.Values.ToList();
    }

    public void AddComputer(Computer computer)
    {
        _computers.Add(+1, computer);
    }

    public bool UpdateComputer(Computer computer)
    {
        if (_computers.ContainsKey(computer.Id))
        {
            _computers[computer.Id] = computer;
            return true;
        }
        return false;
    }

    public bool DeleteComputerById(int Id)
    {
        if (_computers.ContainsKey(Id))
        {
            _computers.Remove(Id);
            return true;
        }
        return false;
        
    }

    public Computer? GetComputerById(int Id)
    {
        if (_computers.ContainsKey(Id))
        {
            return _computers[Id];
        }
        return null;
    }

    public Paging.PagingListAsync<Computer> GetComputersForPaging(int page, int size)
    {
        throw new NotImplementedException();
    }

    public List<Data.Entities.ManufacturerEntity> FindAllManufacturers()
    {
        throw new NotImplementedException();
    }

    public void AddManufacturer(Data.Entities.ManufacturerEntity manufacturer)
    {
        throw new NotImplementedException();
    }

    public bool UpdateManufacturer(Data.Entities.ManufacturerEntity manufacturer)
    {
        throw new NotImplementedException();
    }

    public bool DeleteManufacturer(int id)
    {
        throw new NotImplementedException();
    }

    public Data.Entities.ManufacturerEntity? GetManufacturerById(int id)
    {
        throw new NotImplementedException();
    }
}