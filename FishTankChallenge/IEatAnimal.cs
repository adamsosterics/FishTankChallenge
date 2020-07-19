namespace FishTankChallenge
{
    public interface IEat<in T> where T : Animal
    {
        void Eat(T prey);
    }
}
