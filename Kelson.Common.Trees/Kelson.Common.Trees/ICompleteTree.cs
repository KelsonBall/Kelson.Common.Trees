using System.Collections.Generic;

namespace Kelson.Common.Trees
{
    /// <summary>
    /// A tree with Key Value Pair descendents, a Parent reference, and a Root reference
    /// </summary>    
    public interface ICompleteTree<TKey, TValue, TSelf> : IEnumerable<KeyValuePair<TKey, TSelf>> where TSelf : ICompleteTree<TKey, TValue, TSelf>
    {
        TValue Value { get; set; }

        TSelf Root { get; }
        TSelf Parent { get; }

        IEnumerable<TSelf> Ancestors { get; }
        IEnumerable<TSelf> Descendents { get; }


        TSelf this[TKey key] { get; set; }

        bool ContainsKey(TKey key);
        void Add(TKey key, TSelf child);
        bool Remove(TKey key);
        bool Remove(TKey key, out TSelf removed);
    }
}
