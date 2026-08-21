namespace DVLD.DAL.Interfaces
{
    public interface IWriteRepository<T> where T : class 
    {
        int Add(T entity);
        bool Update(T entity); 
        bool Delete(int id);
    }
}
