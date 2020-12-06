using System;
using System.Collections.Generic;
using System.Linq;

public static class Extention
{
    public static IEnumerable<TSource> Duplicates<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
    {
        var grouped = source.GroupBy(selector);
        var moreThan1 = grouped.Where(i => i.IsMultiple());
        return moreThan1.SelectMany(i => i);
    }

    public static IEnumerable<TSource> Duplicates<TSource, TKey>(this IEnumerable<TSource> source)
    {
        return source.Duplicates(i => i);
    }

    public static bool IsMultiple<T>(this IEnumerable<T> source)
    {
        var enumerator = source.GetEnumerator();
        return enumerator.MoveNext() && enumerator.MoveNext();
    }
}
