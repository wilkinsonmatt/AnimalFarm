using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AnimalFarm.Models;

namespace AnimalFarm.Controllers
{
  public class AnimalsController : Controller
  {
    private readonly AnimalFarmContext _db;

    public AnimalsController(AnimalFarmContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
        return View(_db.Animals.ToList());
    }

    public ActionResult Create()
    {
        ViewBag.TrainerId = new SelectList(_db.Trainers, "TrainerId", "TrainerName", "TrainerSpecialty");
        return View();
    }

    [HttpPost]
    public ActionResult Create(Animal animal, int TrainerId)
    {
        _db.Animals.Add(animal);
        _db.SaveChanges();
        if (TrainerId != 0)
        {
            _db.TrainerAnimal.Add(new TrainerAnimal() { TrainerId = TrainerId, AnimalId = animal.AnimalId });
            _db.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        var thisAnimal = _db.Animals
            .Include(animal => animal.JoinEntities)
            .ThenInclude(join => join.Trainer)
            .FirstOrDefault(animal => animal.AnimalId == id);
        return View(thisAnimal);
    }
  }
}