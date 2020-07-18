using System;
using System.Collections.Generic;
using System.Text;

namespace FishTankChallenge
{
    public class FishTank
    {
        public FishTank()
        {
            Animals = new List<Animal>();
        }

        public List<Animal> Animals { get; set; }

        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
        }

        public void StartGameofLife()
        {
            for (int i = 0, j = Animals.Count -1 ; i < Animals.Count; i++, j--)
            {
                Animals[i].Eat(Animals[j]);
            }
        }
    }
}
