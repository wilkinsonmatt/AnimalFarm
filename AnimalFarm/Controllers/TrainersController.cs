using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AnimalFarm.Models;

namespace AnimalFarm.Controllers
{
  public class TrainersController : Controller
  {
    private readonly AnimalFarmContext _db;

    public TrainersController(AnimalFarmContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Trainer> model = _db.Trainers.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }
    
    [HttpPost]
    public ActionResult Create(Trainer trainer)
    {
      _db.Trainers.Add(trainer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisTrainer = _db.Trainers
        .Include(trainer => trainer.JoinEntities)
        .ThenInclude(join => join.Animal)
        .FirstOrDefault(trainer => trainer.TrainerId == id);
      return View(thisTrainer);
    }

    public ActionResult Edit(int id)
    {
      var thisTrainer = _db.Trainers.FirstOrDefault(trainer => trainer.TrainerId ==id);
      ViewBag.AnimalId = new SelectList(_db.Animals, "AnimalId", "AnimalName", "AnimalType");
      return View(thisTrainer);
    }

    [HttpPost]
    public ActionResult Edit(Trainer trainer, int AnimalId)
    {
      if (AnimalId !=0)
      {
        _db.TrainerAnimal.Add(new TrainerAnimal() { AnimalId = AnimalId, TrainerId = trainer.TrainerId });
      }
      _db.Entry(trainer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisTrainer = _db.Trainers.FirstOrDefault(trainer => trainer.TrainerId == id);
      return View(thisTrainer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisTrainer = _db.Trainers.FirstOrDefault(trainer => trainer.TrainerId == id);
      _db.Trainers.Remove(thisTrainer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
