using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab0.Models;

public class Computer
{
    [HiddenInput]
    public int Id { get; set; }

    [StringLength(maximumLength: 60, MinimumLength = 1)]
    [Display(Name = "Nazwa")]
    public string Name { get; set; }
    
    [HiddenInput]
    [Display(Name = "Producent")]
    public int ManufacturerId { get; set; }

    [ValidateNever]
    [Display(Name = "Producent")]
    public string ManufacturerName { get; set; }

    [ValidateNever]
    public List<SelectListItem> Manufacturers { get; set; }
    
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
}