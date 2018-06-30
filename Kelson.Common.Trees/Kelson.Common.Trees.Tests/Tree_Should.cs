using FluentAssertions;
using System.Linq;
using Xunit;

namespace Kelson.Common.Trees.Tests
{
    public class Tree_Should
    {
        [Fact]
        public void AddChildren()
        {
            var tree = new Tree<int, string>("Root")
            {
                { 1, new Tree<int, string>("First of Root") },
                { 2, new Tree<int, string>("Second of Root")
                    {
                        { 1, new Tree<int, string>("First of Second of Root") }
                    }
                }
            };

            tree.Count().Should().Be(2);
            tree.Descendents.Count().Should().Be(3);
            tree[1].Value.Should().Be("First of Root");
            tree[2].Count().Should().Be(1);
            tree[2].Value.Should().Be("Second of Root");
            tree[2][1].Value.Should().Be("First of Second of Root");
        }

        [Fact]
        public void SupportAddRemove()
        {
            var tree = new Tree<string, int>(1);
            var child = new Tree<string, int>(2);

            child.Parent.Should().BeNull();
            child.Root.Should().BeSameAs(child);

            tree.Add("first", child);

            child.Parent.Should().BeSameAs(tree);
            child.Root.Should().BeSameAs(tree);

            tree.Remove("first");

            child.Parent.Should().BeNull();
            child.Root.Should().BeSameAs(child);
        }
    }
}
