public interface ICrud<T> where T : class
{
    //implementation of CRUD operations
    List<T> Read(); // retur new List<AddressModel>()
    List<T> ReadById(int id);
    void Create(T entity);
    void Update(int id,T entity);
    void Delete(int id);
}