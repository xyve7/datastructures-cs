using System;

namespace DataStructures
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var vec = new MyVector<int>();
            vec.Add(10);
            vec.Add(11);
            vec.Add(12);
            vec[0] = 100;
            
            var vec2 = new MyVector<int>(vec);

            Console.WriteLine(vec);

            vec2.Remove(0);
            Console.WriteLine(vec2.Find(11));
            Console.WriteLine(vec2.Contains(11));
            
            Console.WriteLine(vec2);
            
        }
    }
}