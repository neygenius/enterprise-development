namespace EduEDiary.Domain.Repositories;

public class ClassesRepository : IRepository<Classes>
{
    private readonly List<Classes> _classes = [];
    private int _id = 1;

    public List<Classes> GetAll() => _classes;

    public Classes? Get(int id) => _classes.Find(c => c.Id == id);

    public void Post(Classes obj)
    {
        obj.Id = _id++;
        _classes.Add(obj);
    }

    public bool Put(Classes obj, int id)
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
