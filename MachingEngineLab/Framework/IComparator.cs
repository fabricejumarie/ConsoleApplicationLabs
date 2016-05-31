using System.Collections.Generic;

namespace MatchingEngine.Framework
{
    public interface IComparator<TData>
    {
        IEnumerable<string> CompareOneToOne(TData source1, TData source2);
    }
}
