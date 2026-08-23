namespace DVLD.BLL.Interfaces
{
    public interface IAddServices<TAddDTO> where TAddDTO : class
    {
        int AddNew(TAddDTO AddDTO);
    }
}
