using System;

namespace MatchingEngine.Framework
{
    public class Orchestrator<TData> where TData : IEquatable<TData>
    {
        public IParser<TData> ParserSource1 { get; set; }

        public IParser<TData> ParserSource2 { get; set; }

        public IMatcher<TData> Matcher { get; set; }

        public IComparator<TData> Comparer { get; set; }
        
        public void Run()
        {
            var source1 = ParserSource1.GetData();
            var source2 = ParserSource2.GetData();
            Matcher.Compare(source1, source2, Comparer);
        }
    }
}
