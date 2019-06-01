using System.Collections;

namespace GenericT_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable Table = new Hashtable();

            Table.Add("IsConnected", true);
            Table.Add("MyClass", new TestClass());

            bool IsConnected = Table.TryGet<bool>("IsConnected", false);

            TestClass MyClass = Table.TryGet<TestClass>("MyClass", null);
        }

        private class TestClass
        {

        }
    }
}
