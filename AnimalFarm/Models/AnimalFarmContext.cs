using Microsoft.EntityFrameworkCore;

namespace AnimalFarm.Models
{
  public class AnimalFarmContext : DbContext
  {
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<Animal> Animals { get; set; }
    public DbSet<TrainerAnimal> TrainerAnimal { get; set; }

    public AnimalFarmContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}