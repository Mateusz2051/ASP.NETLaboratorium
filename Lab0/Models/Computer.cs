using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Lab0.Models;

public class Computer : IEnumerable
{
    [HiddenInput]
    public int Id { get; set; }

    [StringLength(maximumLength: 60, MinimumLength = 1)]
    [Display(Name = "Nazwa")]
    public string Name { get; set; }
    
    [StringLength(maximumLength: 50, MinimumLength = 1)]
    [Display(Name = "Producent")]
    public string Producer { get; set; }
    
    [StringLength(maximumLength: 40, MinimumLength = 1)]
    [Display(Name = "Procesor")]
    
    public string Cpu { get; set; }
    [StringLength(maximumLength: 50, MinimumLength = 1)]
    [Display(Name = "Ram")]
    public string Ram { get; set; }
    [StringLength(maximumLength: 50, MinimumLength = 1)]
    [Display(Name = "Gpu")]
    public string Gpu { get; set; }
    
    [DataType(DataType.Date)]
    [Display(Name = "Data Produkcji")]
    public DateOnly ProductionDate { get; set; }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}