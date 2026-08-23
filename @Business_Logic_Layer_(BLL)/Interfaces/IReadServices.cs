namespace DVLD.BLL.Interfaces
{
    public interface IReadServices<TReadDTO, TColumns> where TColumns : Enum where TReadDTO : class, new()
    {
        //OperationResults<TReadDTO> GetPeople(SearchCriteria<TColumns> criteria);
        //OperationResults<TReadDTO> GetAllPeople();
        int GetCountOfAllWithoutFilter();
    }
}
