using Data.Entities;
using Lab0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab0.Controllers;

[Authorize(Roles = "admin")]
public class ManufacturerController : Controller
{
    private readonly IComputerService _service;

    public ManufacturerController(IComputerService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        return View(_service.FindAllManufacturers());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(ManufacturerEntity manufacturer)
    {
        if (ModelState.IsValid)
        {
            _service.AddManufacturer(manufacturer);
            return RedirectToAction(nameof(Index));
        }
        return View(manufacturer);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var manufacturer = _service.GetManufacturerById(id);
        if (manufacturer == null)
        {
            return NotFound();
        }
        return View(manufacturer);
    }

    [HttpPost]
    public IActionResult Edit(ManufacturerEntity manufacturer)
    {
        if (ModelState.IsValid)
        {
            _service.UpdateManufacturer(manufacturer);
            return RedirectToAction(nameof(Index));
        }
        return View(manufacturer);
    }

    public IActionResult Delete(int id)
    {
        var manufacturer = _service.GetManufacturerById(id);
        if (manufacturer == null)
        {
            return NotFound();
        }
        return View(manufacturer);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        _service.DeleteManufacturer(id);
        return RedirectToAction(nameof(Index));
    }
}
