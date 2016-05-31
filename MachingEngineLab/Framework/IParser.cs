using System.Collections.Generic;

namespace MatchingEngine.Framework
{
    public interface IParser<TData>
    {
        IEnumerable<TData> GetData();
    }
}
