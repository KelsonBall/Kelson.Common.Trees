using System.Collections;
using System.Collections.Generic;

namespace Kelson.Common.Trees.Tests.TreeTypes
{
    public class Node : IBasicTree<int, Node>
    {
        public readonly List<Node> children = new List<Node>();

        public int Value { get; set; }

        public Node(int v) => Value = v;

        public void Add(Node value) => children.Add(value);

        public IEnumerator<Node> GetEnumerator() => children.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public static Node TestTree =>
            new Node(1)
            {
                new Node(2)
                {
                    new Node(3),
                    new Node(4)
                },
                new Node(5)
                {
                    new Node(6),
                    new Node(7),
                    new Node(8)
                }
            };
    }

}
