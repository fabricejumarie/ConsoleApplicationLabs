using System.Collections.Generic;
using System.Linq;
using MatchingEngine.Model;

namespace MatchingEngine
{
    public class ComparerABCProduct : ComparerXYZProduct
    {
        public override IEnumerable<string> CompareOneToOne(Product source1, Product source2)
        {
            var differences = base.CompareOneToOne(source1, source2).ToList();

            if(source1.Price != source2.Price)
            {
                differences.Add("Price");
            }

            if(source1.Currency != source2.Currency)
            {
                differences.Add("Currency");
            }

            return differences;
            
        }
    }
}
