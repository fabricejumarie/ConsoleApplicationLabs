using MatchingEngine.Framework;
using MatchingEngine.Model;
using System.Collections.Generic;

namespace MatchingEngine
{
    public class ParserXYZ : IParser<Product>
    {
        private IEnumerable<Product> _products { get; set; }
        public ParserXYZ(IEnumerable<Product> products)
        {
            _products = products;
        }
        public IEnumerable<Product> GetData()
        {
            return _products;
        }
    }
}
