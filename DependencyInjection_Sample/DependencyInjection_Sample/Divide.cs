namespace DependencyInjection_Sample
{
    public class Divide : ICalculateNumbers
    {
        public int Calculate(int NumberA, int NumberB)
        {
            return NumberA / NumberB;
        }
    }
}
