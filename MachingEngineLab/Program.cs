using MatchingEngine.Framework;
using MatchingEngine.Model;
using System;
using System.Linq;
using System.Collections.Generic;

namespace MatchingEngine
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Product> products1 = new[]
            {
                new Product(1, "name1", 127, "EUR"), new Product(10, "name2"), new Product(3, "name3", 10, "EUR"), new Product(4, "name4", 5, "USD")
            };

            IEnumerable<Product> products2 = new[]
            {
                new Product(3, "name3", 10, "EUR"), new Product(6, "name6", 6, "USD")
            };

            var onlyInOne = products1.Except(products2);
            Console.WriteLine("Item only in One :");
            foreach (var item in onlyInOne)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void Reconciliation()
        {
            Product[] products1 = new[]
            {
                new Product(1, "name1", 127, "EUR"), new Product(2, "name2"), new Product(3, "name3", 10, "EUR"), new Product(4, "name4", 5, "USD"),
                new Product(5, "name5"), new Product(6, "name6"), new Product(7, "name7"), new Product(8, "name8"),
                new Product(-4, "name4")
            };

            Product[] products2 = new[]
            {
                new Product(1, "name1", 127, "EUR"), new Product(2, "name22"), new Product(3, "name3", 10, "EUR"), new Product(-1, "name4", 5, "USD"),
                new Product(-2, "name5"),
                new Product(-3, "name5"), new Product(9, "name9")
            };

            var matcherFullClassName = "MatchingEngine.Matcher, MatchingEngine";
            var o = Activator.CreateInstance(Type.GetType(matcherFullClassName));

            var orchestrator = new Orchestrator<Product>();
            orchestrator.ParserSource1 = new ParserXYZ(products1);
            orchestrator.ParserSource2 = new ParserXYZ(products2);
            orchestrator.Matcher = new Matcher();
            orchestrator.Comparer = new ComparerABCProduct();
            orchestrator.Run();
        }

        
    }
}
