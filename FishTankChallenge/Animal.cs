using System;

namespace FishTankChallenge
{
    public abstract class Animal
    {
        public string Name { get; set; }
        public AnimalSize Size { get; set; }
        public bool IsDead { get; set; }

        public virtual void Eat(object obj)
        {
            if (IsDead)
            {
                return;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Animal animal &&
                   Name == animal.Name &&
                   Size == animal.Size &&
                   IsDead == animal.IsDead;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Size, IsDead);
        }

        public enum AnimalSize
        {
            Small,
            Medium,
            Big
        }
    }
}