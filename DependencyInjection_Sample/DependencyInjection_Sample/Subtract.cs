namespace DependencyInjection_Sample
{
    public class Subtract : ICalculateNumbers
    {
        public int Calculate(int NumberA, int NumberB)
        {
            return NumberA - NumberB;
        }
    }
}
