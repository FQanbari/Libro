namespace Infrastructure.Extensions;

public static class PagerExtenstions
{
    public static async Task<IQueryable<T>> ToPaging<T>(this Task<IQueryable<T>> query, int page, int pageSize)
    {
        int skip = Math.Max(pageSize * (page - 1), 0);
        return (await query).Skip(skip).Take(pageSize);
    }
}
