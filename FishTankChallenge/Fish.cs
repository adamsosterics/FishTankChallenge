namespace FishTankChallenge
{
    public class Fish : Animal, IEat<Crab>, IEat<Fish>
    {
        public void Eat(Crab prey)
        {
            if (!IsDead && prey.Size == AnimalSize.Small)
            {
                prey.IsDead = true;
            }
        }

        public void Eat(Fish prey)
        {
            if (!IsDead && Size - prey.Size == 1)
            {
                prey.IsDead = true;
            }
        }
    }
}
