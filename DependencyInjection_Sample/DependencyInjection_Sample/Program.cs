using System;

namespace DependencyInjection_Sample
{
    class Program
    {
        static void Main(string[] args)
        {

            CalculationManager CM = new CalculationManager()
            {
                NumberA = 10,
                NumberB = 5
            };

            // add
            int Added = CM.Calculate(new Add());

            Console.WriteLine(string.Format(
                "{0} + {1} = {2}",
                CM.NumberA,
                CM.NumberB, Added)
            );

            // subtract
            int Subtracted = CM.Calculate(new Subtract());

            Console.WriteLine(string.Format(
                "{0} - {1} = {2}",
                CM.NumberA,
                CM.NumberB,
                Subtracted)
            );

            // multiplie
            int Multiplied = CM.Calculate(new Mulitply());

            Console.WriteLine(string.Format(
                "{0} * {1} = {2}",
                CM.NumberA,
                CM.NumberB,
                Multiplied)
            );

            // divide
            int Divided = CM.Calculate(new Divide());

            Console.WriteLine(string.Format(
                "{0} / {1} = {2}",
                CM.NumberA,
                CM.NumberB,
                Divided)
            );
        }
    }
}
