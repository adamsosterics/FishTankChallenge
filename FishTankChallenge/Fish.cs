namespace FishTankChallenge
{
    public class Fish : Animal
    {
        public override void Eat(object obj)
        {
            base.Eat(obj);

            if (obj is Crab crab && crab.Size == AnimalSize.Small)
            {
                crab.IsDead = true;
            }

            if (obj is Fish fish && (fish.Size == AnimalSize.Small && Size == AnimalSize.Medium || fish.Size == AnimalSize.Medium && Size == AnimalSize.Big))
            {
                fish.IsDead = true;
            }
        }
    }
}
