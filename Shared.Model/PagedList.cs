namespace Shared.Model
{
    public record PagedList<T>(List<T> Items, int TotalItems)
    {
      
    }
}
