namespace FishTankChallenge
{
    static class FoodChain
    {
        public static void Eat(Crab predator, Crab prey)
        {
            if (!predator.IsDead && !predator.IsHidden && prey.Size < predator.Size)
            {
                prey.IsDead = true;
            }
        }

        public static void Eat(Fish predator, Crab prey)
        {
            if (!predator.IsDead && prey.Size == Animal.AnimalSize.Small)
            {
                prey.IsDead = true;
            }
        }

        public static void Eat(Fish predator, Fish prey)
        {
            if (!predator.IsDead && (predator.Size - 1 == prey.Size))
            {
                prey.IsDead = true;
            }
        }

        public static void Eat(Animal predator, Animal prey)
        {

        }
    }
}
