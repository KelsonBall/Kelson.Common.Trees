using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Kelson.Common.Trees
{
    public class Tree<TKey, TValue> : ICompleteTree<TKey, TValue, Tree<TKey, TValue>>
    {
        public TValue Value { get; set; }

        public Tree()
        {
            Root = this;
        }

        public Tree(TValue value) : this() => Value = value;

        private readonly SortedList<TKey, Tree<TKey, TValue>> children = new SortedList<TKey, Tree<TKey, TValue>>();

        public Tree<TKey, TValue> Root { get; private set; }

        public Tree<TKey, TValue> Parent { get; private set; }

        public Tree<TKey, TValue> this[TKey key]
        {
            get => children[key];
            set
            {
                value.Parent = this;
                value.Root = Root;
                if (children.ContainsKey(key))
                    Remove(key);
                children[key] = value;
            }
        }

        public void Add(TKey key, Tree<TKey, TValue> child)
        {
            child.Parent = this;
            child.Root = Root;
            children.Add(key, child);
        }

        public bool ContainsKey(TKey key) => children.ContainsKey(key);

        public bool Remove(TKey key) => Remove(key, out Tree<TKey, TValue> removed);        

        public bool Remove(TKey key, out Tree<TKey, TValue> removed)
        {
            if (children.ContainsKey(key))
            {
                var node = children[key];
                node.Parent = null;
                node.Root = node;
                removed = node;
            }
            else
                removed = default;
            return children.Remove(key);
        }

        public IEnumerator<KeyValuePair<TKey, Tree<TKey, TValue>>> GetEnumerator() => children.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerable<Tree<TKey, TValue>> Ancestors
        {
            get
            {
                var node = this;
                while (node != null)                
                    yield return (node = node.Parent);
            }
        }

        public IEnumerable<Tree<TKey, TValue>> Descendents => this.DepthFirstTraverse(n => n.children.Values).Skip(1);
    }
}
