using System;
using System.Collections.Generic;

namespace MatchingEngine.Framework
{
    public interface IMatcher<TData> where TData : IEquatable<TData>
    {
        void Compare(IEnumerable<TData> source1, IEnumerable<TData> source2, IComparator<TData> comparerOneToOne);
    }
}
