using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Lab0.Models;

public class Computer : IEnumerable
{
    [HiddenInput]
    public int Id { get; set; }

    [StringLength(maximumLength: 60, MinimumLength = 1)]
    public string Name { get; set; }
    [StringLength(maximumLength: 40, MinimumLength = 1)]
    public string Cpu { get; set; }
    [StringLength(maximumLength: 50, MinimumLength = 1)]
    public string Ram { get; set; }
    [StringLength(maximumLength: 50, MinimumLength = 1)]
    public string Gpu { get; set; }
    [StringLength(maximumLength: 50, MinimumLength = 1)]
    public string Producer { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateOnly ProductionDate { get; set; }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}