namespace EduEDiary.Domain.Repositories;

public class ClassRepository : IRepository<Class>
{
    private readonly List<Class> _classes = [];
    private int _id = 1;

    public List<Class> GetAll() => _classes;

    public Class? Get(int id) => _classes.Find(c => c.Id == id);

    public void Post(Class obj)
    {
        obj.Id = _id++;
        _classes.Add(obj);
    }

    public bool Put(Class obj, int id)
    {
        var oldClass = Get(id);
        if (oldClass == null)
            return false;
        oldClass.Id = obj.Id;
        oldClass.Number = obj.Number;
        oldClass.Letter = obj.Letter;
        return true;
    }

    public bool Delete(int id)
    {
        var deletedClass = Get(id);
        if (deletedClass == null)
            return false;
        _classes.Remove(deletedClass);
        return true;
    }
}
