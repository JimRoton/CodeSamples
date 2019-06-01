using System;

namespace Extensions_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            int Return1 = Sample1();

            Console.WriteLine("-Sample1-");
            Console.WriteLine(string.Format("Value: {0}", Return1));
            Console.WriteLine(string.Format("Type : {0}", Return1.GetType().FullName));
            Console.WriteLine();

            int Return2 = Sample2();

            Console.WriteLine("-Sample2-");
            Console.WriteLine(string.Format("Value: {0}", Return2));
            Console.WriteLine(string.Format("Type : {0}", Return2.GetType().FullName));
        }

        private static int Sample1()
        {
            /******************************************
             * This demonstrates a simple bit of code using
             * the TryParse extension of the String data type.
             * It’s the simplest way to parse a string into
             * an Integer without building a custom extension.
             ******************************************/
            string myNumber = "1";

            if (!int.TryParse(myNumber, out int myInt))
                myInt = 0;

            return myInt;
        }

        private static int Sample2()
        {
            /******************************************
             * This demonstrates a simple bit of code using
             * an extension to the String data type.
             * It abstracts away the TryParse of the String
             * data type into an extension that can be
             * reused throughout all your projects.
             ******************************************/
            string myNumber = "2";

            int myInt = myNumber.ToIntOrZero();

            return myInt;
        }
    }
}
