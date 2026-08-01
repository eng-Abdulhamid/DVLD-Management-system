namespace Services
{
    public enum enSearchType
    {
        None = 0,
        Contain = 1,
        StartWith = 2,
        EndWith = 3
    }
    public enum enSorting
    {
        Ascending = 0,
        Descending = 1
    }
    internal class GenericMap
    {
        internal Repositories.enSorting _MapToRepoSorting(enSorting Sorting)
        {

            return (Repositories.enSorting)Sorting;
        }
        internal Repositories.enSearchType _MapToRepoSearchType(enSearchType SearchType)
        {
            return (Repositories.enSearchType)SearchType;
        }
    }
}
