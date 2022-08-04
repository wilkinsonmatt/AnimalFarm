using System.Collections.Generic;

namespace AnimalFarm.Models
{
  public class Trainer
  {
    public Trainer()
    {
      this.JoinEntities = new HashSet<TrainerAnimal>();
    }

    public int TrainerId { get; set; }
    public string TrainerName { get; set; }
    public string TrainerSpecialty { get; set; }
    public virtual ICollection<TrainerAnimal> JoinEntities { get; set; }
  }
}