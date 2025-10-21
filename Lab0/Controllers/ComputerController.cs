using Lab0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Lab0.Controllers;

public class ComputerController : Controller

{
    private static Dictionary<int, Computer> _computers = new();
    private static int i = 0;
    public IActionResult Index()
    {
        return View ();
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Computer model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        return RedirectToAction("Index");
    }
}