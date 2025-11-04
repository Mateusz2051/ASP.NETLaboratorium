namespace Lab0.Models;

public interface IComputerService
{
    List<Computer> GetComputers();
    void AddComputer(Computer computer);
    bool UpdateComputer(Computer computer);
    bool DeleteComputerById(int Id);
    Computer? GetComputerById(int Id);
}