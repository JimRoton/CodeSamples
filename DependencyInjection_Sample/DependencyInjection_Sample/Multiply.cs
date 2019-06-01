namespace DependencyInjection_Sample
{
    public class Mulitply : ICalculateNumbers
    {
        public int Calculate(int NumberA, int NumberB)
        {
            return NumberA * NumberB;
        }
    }
}
