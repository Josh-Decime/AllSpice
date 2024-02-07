namespace AllSpice.Interfaces;

public interface IRepository<Type>
{
    List<Type> GetAll();
    Type GetById(int id);
    Type Create(Type createData);
    Type Update(Type updateData);
    void Delete(int id);
}