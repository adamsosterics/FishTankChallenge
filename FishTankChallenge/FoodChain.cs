namespace FishTankChallenge
{
    static class FoodChain
    {
        public static bool CanEat(Animal predator, Animal prey) =>
            predator switch
            {
                Animal { IsDead: true } => false,
                Crab { IsHidden: true } => false,
                Crab c => prey switch
                {
                    Crab p when (p.Size < c.Size) => true,
                    _ => false
                },
                Fish f => prey switch
                {
                    Crab { Size: Animal.AnimalSize.Small } => true,
                    Fish p when (f.Size - p.Size == 1) => true,
                    _ => false
                },
                _ => false
            };
    }
}
