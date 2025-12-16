using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("computers")]
public class ComputerEntity
{
    public int Id { get; set; }

    [MaxLength(50)]
    [Required]
    public string Name { get; set; }

    [MaxLength(50)]
    [Required]
    public string Producer { get; set; }
    
    [MaxLength(50)]
    public string Cpu { get; set; }
    
    [MaxLength(50)]
    public string Ram { get; set; }
    
    [MaxLength(50)]
    public string Gpu { get; set; }

    [Column("production_date")]
    public DateOnly ProductionDate { get; set; }
}
