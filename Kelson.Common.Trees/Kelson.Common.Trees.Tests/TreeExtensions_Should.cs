using FluentAssertions;
using System.Linq;
using System;
using Xunit;
using Kelson.Common.Trees.Tests.TreeTypes;

namespace Kelson.Common.Trees.Tests
{
    public class TreeExtensions_Should
    {       
        [Fact]
        public void DepthFirstSearchAnIBasicTree()
        {
            Node.TestTree.DepthFirstTraverse()
                .Select(n => n.Value)
                .SequenceEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 })
                .Should()
                .BeTrue();
        }

        [Fact]
        public void BreadthFirstSearchAnIBasicTree()
        {
            Node.TestTree.BreadthFirstTraverse()
                .Select(n => n.Value)
                .SequenceEqual(new int[] { 1, 2, 5, 3, 4, 6, 7, 8 })
                .Should()
                .BeTrue();
        }

        [Fact]
        public void DepthFirstSearchWithEnumerableSelector()
        {
            new DivisableNumber(18).DepthFirstTraverse(n => n.Divisors())
                .Select(n => n.ToString())
                .SequenceEqual(new string[] { "[18]", "[9 goes into 18]", "[3 goes into 9]", "[6 goes into 18]", "[3 goes into 6]", "[2 goes into 6]", "[3 goes into 18]", "[2 goes into 18]" })
                .Should()
                .BeTrue();
        }

        [Fact]
        public void BreadthFirstSearchWithEnumerableSelector()
        {
            new DivisableNumber(18).BreadthFirstTraverse(n => n.Divisors())
                .Select(n => n.ToString())
                .SequenceEqual(new string[] { "[18]", "[9 goes into 18]", "[6 goes into 18]", "[3 goes into 18]", "[2 goes into 18]", "[3 goes into 9]", "[3 goes into 6]", "[2 goes into 6]" })
                .Should()
                .BeTrue();
        }

        [Fact]
        public void DepthFirstSearchWithListSelector()
        {
            new DivisableNumber(18).DepthFirstTraverse(n => n.Divisors().ToList())
                .Select(n => n.ToString())
                .SequenceEqual(new string[] { "[18]", "[9 goes into 18]", "[3 goes into 9]", "[6 goes into 18]", "[3 goes into 6]", "[2 goes into 6]", "[3 goes into 18]", "[2 goes into 18]" })
                .Should()
                .BeTrue();
        }        

        [Fact]
        public void DepthFirstSearchWithArraySelector()
        {
            new DivisableNumber(18).DepthFirstTraverse(n => n.Divisors().ToArray())
                .Select(n => n.ToString())
                .SequenceEqual(new string[] { "[18]", "[9 goes into 18]", "[3 goes into 9]", "[6 goes into 18]", "[3 goes into 6]", "[2 goes into 6]", "[3 goes into 18]", "[2 goes into 18]" })
                .Should()
                .BeTrue();
        }        
    }
}
