using System.Collections.Generic;

namespace Kelson.Common.Trees.Tests.TreeTypes
{
    public class DivisableNumber
    {
        public readonly int Value;
        public readonly int? Parent;

        public DivisableNumber(int v, int? parent = null)
        {
            Value = v;
            Parent = parent;
        }

        public IEnumerable<DivisableNumber> Divisors()
        {
            for (int i = Value / 2; i > 1; i--)
            {
                if (Value % i != 0)
                    continue;
                yield return new DivisableNumber(i, Value);
            }
        }

        public override string ToString()
        {
            if (Parent.HasValue)
                return $"[{Value} goes into {Parent.Value}]";
            else
                return $"[{Value}]";
        }
    }
}
