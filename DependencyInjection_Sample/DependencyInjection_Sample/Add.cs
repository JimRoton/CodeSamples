namespace DependencyInjection_Sample
{
    public class Add : ICalculateNumbers
    {
        public int Calculate(int NumberA, int NumberB)
        {
            return NumberA + NumberB;
        }
    }
}
