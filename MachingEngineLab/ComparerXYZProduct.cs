using MatchingEngine.Framework;
using MatchingEngine.Model;
using System.Collections.Generic;

namespace MatchingEngine
{
    public class ComparerXYZProduct : IComparator<Product>
    {
        public virtual IEnumerable<string> CompareOneToOne(Product source1, Product source2)
        {
            if(source1.Name != source2.Name)
            {
                yield return "Name";
            }
        }
    }
}
