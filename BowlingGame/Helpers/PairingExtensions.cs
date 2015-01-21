using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.Helpers
{
    public static class PairingExtensions
    {
        public static IEnumerable<Tuple<T, T, T>> GetTriples<T>(this IEnumerable<T> source) where T : class
        {
            using (var iterator = source.GetEnumerator())
            {
                T first = null;
                T second = null;
                while (iterator.MoveNext())
                {
                    var third = iterator.Current;
                    if (first != null && second != null)
                    {
                        yield return Tuple.Create(first, second, third);
                    }
                    first = second;
                    second = third;
                }
                if (first != null)
                {
                    if (second != null)
                    {
                        yield return Tuple.Create(first, second, default(T));
                        yield return Tuple.Create(second, default(T), default(T));
                    }
                    else
                    {
                        yield return Tuple.Create(first, default(T), default(T));   
                    }
                }
            }
        }
    }
}
