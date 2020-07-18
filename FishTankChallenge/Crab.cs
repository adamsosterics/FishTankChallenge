namespace FishTankChallenge
{
    public class Crab : Animal
    {
        public bool IsHidden { get; set; }

        public override void Eat(object obj)
        {
            if (IsDead || IsHidden)
            {
                return;
            }

            if (obj is Crab crab && crab.Size < Size)
            {
                crab.IsDead = true;
            }
        }
    }
}
