namespace EduEDiary.Domain.Repositories;

public class SubjectsRepository : IRepository<Subjects>
{
    private readonly List<Subjects> _subjects = [];
    private int _id = 1;

    public List<Subjects> GetAll() => _subjects;

    public Subjects? Get(int id) => _subjects.Find(s => s.Id == id);

    public void Post(Subjects obj)
    {
        obj.Id = _id++;
        _subjects.Add(obj);
    }

    public bool Put(Subjects obj, int id)
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
