namespace AnimalFarm.Models
{
  public class TrainerAnimal
  {
    public int TrainerAnimalId { get; set; }
    public int AnimalId { get; set; }
    public int TrainerId { get; set; }
    public virtual Animal Animal { get; set; }
    public virtual Trainer Trainer { get; set; }
  }
}