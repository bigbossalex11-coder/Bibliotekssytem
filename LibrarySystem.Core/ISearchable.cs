

namespace LibrarySystem.Core
{
    public interface ISearchable<T>
    {
        List<T> Search(string searchTerm);
    }
}
