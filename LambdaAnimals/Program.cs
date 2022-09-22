using System;
using System.Collections.Generic;

namespace LambdaAnimals
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog d1 = new Dog("King", 25);
            Dog d2 = new Dog("Tiny", 95);
            Dog d3 = new Dog("Rufus", 36);
            Dog d4 = new Dog("Spot", 55);
            Dog d5 = new Dog("Daisy", 8);
            List<Dog> dogs = new List<Dog> { d1, d2, d3, d4, d5 };

            bool WGT40(Dog d) { return d.Weight > 40;}

            //(Dog d) => { return d.Weight > 40; }

            // Print out all Dogs with a weight larger than 40 kg.
            ConditionalPrint(dogs, WGT40);
            ConditionalPrint(dogs, (Dog d) => {return d.Weight > 40; });

            // Print out all Dogs with a weight smaller than Rufus' weight.
            ConditionalPrint(dogs, (Dog d) => { return d.Weight < d3.Weight; });

            // Print out all Dogs with a name that contains an "i"
            ConditionalPrint(dogs, (Dog d) => { return d.Name.ToUpper().Contains("I"); });


            Console.WriteLine();
            Console.WriteLine("ConditionalPrint2");
            ConditionalPrint2<Dog>(dogs,
                                   (Dog d) => { return d.Weight > 40; },
                                   (Dog d) => { return d.Name.ToUpper().Contains("I"); });
                   

            KeepConsoleWindowOpen();
        }

        public static void ConditionalPrint<T>(List<T> objects, Predicate<T> pred)
        {
            Console.WriteLine();
            foreach (var item in objects.FindAll(pred))
            {
                Console.WriteLine(item);
            }
        }

        public static void ConditionalPrint2<T>(List<T> objects, 
                                                Predicate<T> pred1,
                                                Predicate<T> pred2)
        {
            Console.WriteLine();

            List<T> found = new List<T> ();

            foreach (T item in objects.FindAll(pred1))
            {
                found.Add(item);

            }

            foreach (var item in found.FindAll(pred2))
            {
                Console.WriteLine(item);
            }
        }

        public static void MultiConditionalPrint<T>(List<T> objects, 
                                                    List<Predicate<T>> preds)
        {
            Console.WriteLine();

            List<T> result = objects;

            foreach(Predicate<T> p in preds)
            {
                List<T> found = new List<T>();

                foreach (T item in result.FindAll(p))
                {
                    found.Add(item);
                }

                result = found;
;           }

            if (result == null || result.Count <= 0)
            {
                Console.WriteLine("Nothing found");
            }
            else
            { 
                foreach (var item in result)
                {   
                   Console.WriteLine(item);
                }
            }
        }

        private static void KeepConsoleWindowOpen()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to close application");
            Console.ReadKey();
        }
    }
}
