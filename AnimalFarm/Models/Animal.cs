using System.Collections.Generic;
using System;

namespace AnimalFarm.Models
{
    public class Animal
    {
        public Animal()
        {
            this.JoinEntities = new HashSet<TrainerAnimal>();
        }
        public int AnimalId { get; set; }
        public string AnimalType { get; set; }
        public string AnimalName { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<TrainerAnimal> JoinEntities { get; }
    }
}