using Lab0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab0.Controllers;

[Authorize]
public class ComputerController(IComputerService service) : Controller

{
    [AllowAnonymous]
    public IActionResult Index(int page = 1, int size = 10)
    {
        return View(service.GetComputersForPaging(page, size));
    }

    [HttpGet]
    public IActionResult Create()
    {
        var model = new Computer();
        model.Manufacturers = service.FindAllManufacturers()
            .Select(m => new SelectListItem() { Value = m.Id.ToString(), Text = m.Name })
            .ToList();
        return View(model);
    }
    
    [HttpPost]
    public IActionResult Create(Computer model)
    {
        if (!ModelState.IsValid)
        {
            model.Manufacturers = service.FindAllManufacturers()
                .Select(m => new SelectListItem() { Value = m.Id.ToString(), Text = m.Name })
                .ToList();
            return View(model);
        }

        service.AddComputer(model);
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var Computer = service.GetComputerById(id);
        if (Computer is not null)
        {
            return View(Computer);
        }
        else
        {
            return NotFound();
        }
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var Computer = service.GetComputerById(id);
        if (Computer is not null)
        {
            Computer.Manufacturers = service.FindAllManufacturers()
                .Select(m => new SelectListItem() { Value = m.Id.ToString(), Text = m.Name })
                .ToList();
            return View(Computer);
        }
        else
        {
            return NotFound();
        }   
    }

    [HttpPost]
    public IActionResult Edit(Computer model)
    {
        if (!ModelState.IsValid)
        {
            model.Manufacturers = service.FindAllManufacturers()
                .Select(m => new SelectListItem() { Value = m.Id.ToString(), Text = m.Name })
                .ToList();
            return View(model);
        }

        service.UpdateComputer(model);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var Computer = service.GetComputerById(id);
        if (Computer is not null)
        {
            return View(Computer);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult DeleteConfirm(int Id)
    {
        service.DeleteComputerById(Id);
        return RedirectToAction("Index");
    }
}