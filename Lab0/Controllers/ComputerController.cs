using Lab0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Lab0.Controllers;

public class ComputerController : Controller

{
    private static Dictionary<int, Computer> _computers = new()
    {
        { 1, new Computer() { Id = 1, Name = "Computer 1", Producer = "Abc", Cpu = "It", Gpu = "Ad", Ram = "T", ProductionDate = DateOnly.Parse("2025-01-01") } },
        { 2, new Computer() { Id = 2, Name = "Computer 2", Producer = "Cba", Cpu = "Ad", Gpu = "Nv", Ram = "Q",  ProductionDate = DateOnly.Parse("2024-01-02") } },

};
    private static int i = 0;
    public IActionResult Index()
    {
        return View (_computers.Values.ToList());
    }

    [HttpPost]
    public IActionResult Create(Computer model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        model.Id = +1;
        _computers.Add(model.Id, model);
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        if(_computers.ContainsKey(id)){
        return View(_computers[id]);
        }else{
        return NotFound();
        }
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
        if(_computers.ContainsKey(id)){
            return View(_computers[id]);
        }else{
            return NotFound();
        }    
    }

    [HttpPost]
    public IActionResult Edit(Computer model)
    {
        if(ModelState.IsValid){
            return View(model);
        }
        _computers[model.Id] = model;
        return RedirectToAction("Index");;
    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        if(_computers.ContainsKey(id)){
            return View(_computers[id]);
        }else{
            return NotFound();
        }    
    }

    [HttpPost]
    public IActionResult DeleteConfirm(int Id)
    {
        _computers.Remove(Id);
        return RedirectToAction("Index");
    }
}