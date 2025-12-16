using Data.Entities;

namespace Lab0.Models;

public interface IComputerService
{
    List<Computer> GetComputers();
    Paging.PagingListAsync<Computer> GetComputersForPaging(int page, int size);
    void AddComputer(Computer computer);
    bool UpdateComputer(Computer computer);
    bool DeleteComputerById(int Id);
    Computer? GetComputerById(int Id);
    List<ManufacturerEntity> FindAllManufacturers();
    void AddManufacturer(ManufacturerEntity manufacturer);
    bool UpdateManufacturer(ManufacturerEntity manufacturer);
    bool DeleteManufacturer(int id);
    ManufacturerEntity? GetManufacturerById(int id);
}