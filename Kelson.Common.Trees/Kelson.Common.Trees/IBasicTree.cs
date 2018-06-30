using System.Collections.Generic;

namespace Kelson.Common.Trees
{
    public interface IBasicTree<T, TSelf> : IEnumerable<TSelf> where TSelf : IBasicTree<T, TSelf>
    {
        T Value { get; set; }
        void Add(TSelf value);
    }
}
