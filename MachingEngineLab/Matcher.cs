using MatchingEngine.Framework;
using MatchingEngine.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchingEngine
{
    public class Matcher : IMatcher<Product>
    {
        public void Compare(IEnumerable<Product> source1, IEnumerable<Product> source2, IComparator<Product> comparer)
        {
            Maching(source1, source2, comparer);
            Console.WriteLine();
            ManualMatching(source1, source2, comparer);
        }

        public void Maching(IEnumerable<Product> tab1, IEnumerable<Product> tab2, IComparator<Product> comparer)
        {
            var matchingByIds = tab1.Intersect(tab2);

            foreach (var matchingItem in matchingByIds)
            {
                var matchingItem1 = tab1.First(t => t == matchingItem);
                var matchingItem2 = tab2.First(t => t == matchingItem);

                var differences = comparer.CompareOneToOne(matchingItem1, matchingItem2);
                if (differences.ToList().Count == 0)
                {
                    Console.WriteLine("Items {0} are identical", matchingItem.Id);
                }
                else
                {
                    Console.WriteLine("Items {0} have differences on {1}", matchingItem.Id, string.Join(";", differences));
                }
            }
        }

        public void ManualMatching(IEnumerable<Product> tab1, IEnumerable<Product> tab2, IComparator<Product> comparer)
        {
            var result = new List<Product>();
            var onlyInTab1 = tab1.Except(tab2).ToList();
            var onlyInTab2 = tab2.Except(tab1).ToList();
            var manualMatching = new List<Product>();
            var onlyInTab1AfterManualMaching = new List<Product>();

            foreach (var t1 in onlyInTab1)
            {
                var index = onlyInTab2.FindIndex(item2 => comparer.CompareOneToOne(t1, item2).ToList().Count == 0);
                if (index >= 0)
                {
                    manualMatching.Add(t1);
                    onlyInTab2.RemoveAt(index);
                }
                else
                {
                    onlyInTab1AfterManualMaching.Add(t1);
                }
            }

            Console.WriteLine("Manual matching :");
            Print(manualMatching);

            Console.WriteLine("\nOnly in One :");
            Print(onlyInTab1AfterManualMaching);

            Console.WriteLine("\nOnly in Two :");
            Print(onlyInTab2);
        }

        private static void Print<T>(IEnumerable<T> tab)
        {
            foreach (var item in tab)
            {
                Console.WriteLine(item);
            }
        }
    }
}
