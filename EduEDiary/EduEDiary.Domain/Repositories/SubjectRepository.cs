namespace EduEDiary.Domain.Repositories;

public class SubjectRepository : IRepository<Subject>
{
    private readonly List<Subject> _subjects = [];
    private int _id = 1;

    public List<Subject> GetAll() => _subjects;

    public Subject? Get(int id) => _subjects.Find(s => s.Id == id);

    public void Post(Subject obj)
    {
        obj.Id = _id++;
        _subjects.Add(obj);
    }

    public bool Put(Subject obj, int id)
    {
        var oldSubject = Get(id);
        if (oldSubject == null)
            return false;
        oldSubject.Id = obj.Id;
        oldSubject.Name = obj.Name;
        oldSubject.Year = obj.Year;
        return true;
    }

    public bool Delete(int id)
    {
        var deletedSubject = Get(id);
        if (deletedSubject == null)
            return false;
        _subjects.Remove(deletedSubject);
        return true;
    }
}
