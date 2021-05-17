using System;
using static EnumerableEducation.Car;
using System.Collections;

namespace EnumerableEducation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10, 20, 50 };
            Garage g = new Garage();
            foreach(Car i in g)
            {
                Console.WriteLine(i.PetName);
            }
            IEnumerator enumerator = g.GetEnumerator();
        }
    }
}
