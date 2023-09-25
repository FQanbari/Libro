namespace Application.Throtting
{
    public interface IThrottler
    {
        Task<bool> TryGet();
    }
}