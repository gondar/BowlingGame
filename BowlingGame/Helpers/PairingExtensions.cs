using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.Helpers
{
    public static class PairingExtensions
    {
        public static IEnumerable<Tuple<T, T>> PairUp<T>(this IEnumerable<T> source) where T : class
        {
            using (var iterator = source.GetEnumerator())
            {
                T previous = null;
                while (iterator.MoveNext())
                {
                    if (previous != null)
                    {
                        var first = previous;
                        var second = iterator.Current;
                        yield return Tuple.Create(first, second);   
                    }
                    previous = iterator.Current;
                }
                if (previous != null)
                {
                    yield return Tuple.Create(previous, default(T));   
                }
            }
        }
    }
}
