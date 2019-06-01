namespace DependencyInjection_Sample
{
    public class CalculationManager
    {
        public int NumberA { get; set; }

        public int NumberB { get; set; }

        public int Calculate(ICalculateNumbers Controller)
        {
            return Controller.Calculate(NumberA, NumberB);
        }
    }
}
