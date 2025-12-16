using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("manufacturers")]
public class ManufacturerEntity
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public string Nip { get; set; }
    public string Regon { get; set; }
    
    public Address? Address { get; set; }
    
    public ISet<ComputerEntity> Computers { get; set; }
}
