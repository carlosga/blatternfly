using Blatternfly.Components;

namespace System.Linq;

public static class LinqExtensions
{
    public static IQueryable<TSource> OrderBy<TSource, TKey>(this IQueryable<TSource> source, Func<TSource, TKey> keySelector, SortByDirection direction, Func<bool> when)
    {
        if (when())
        {
            return (direction == SortByDirection.Asc)
                ? source.OrderBy(keySelector).AsQueryable()
                    : source.OrderByDescending(keySelector).AsQueryable();
        }

        return source;
    }
}
