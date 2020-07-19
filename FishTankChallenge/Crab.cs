namespace FishTankChallenge
{
    public class Crab : Animal, IEat<Crab>
    {
        public bool IsHidden { get; set; }

        public void Eat(Crab prey)
        {
            if (!IsHidden && !IsDead && prey.Size < Size)
            {
                prey.IsDead = true;
            }
        }
    }
}
