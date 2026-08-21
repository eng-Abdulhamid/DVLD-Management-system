using System.Collections.Generic;
namespace DVLD.DAL.Interfaces
{
    public interface IReadRepository<T> where T : class
    {
        int Count();
        List<T> GetAll();
        T Find(int id);
        bool Exists(int id);
    }
}
