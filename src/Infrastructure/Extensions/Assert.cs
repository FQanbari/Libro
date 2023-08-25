namespace Infrastructure.Extensions;

public static class Assert
{
    public static void NotNull<T>(T obj, string name, string message = null)
        where T : class
    {
        if(obj == null)
            throw new ArgumentNullException($"{name} : {typeof(T)}",message);
    }
}
