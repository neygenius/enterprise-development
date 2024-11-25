namespace EduEDiary.Domain.Repositories;

public class GradesRepository : IRepository<Grades>
{
    private readonly List<Grades> _grades = [];
    private int _id = 1;

    public List<Grades> GetAll() => _grades;

    public Grades? Get(int id) => _grades.Find(s => s.Id == id);

    public void Post(Grades obj)
    {
        obj.Id = _id++;
        _grades.Add(obj);
    }

    public bool Put(Grades obj, int id)
    {
        var oldGrade = Get(id);
        if (oldGrade == null)
            return false;
        oldGrade.Id = obj.Id;
        oldGrade.Student = obj.Student;
        oldGrade.Subject = obj.Subject;
        oldGrade.Grade = obj.Grade;
        oldGrade.Date = obj.Date;
        return true;
    }

    public bool Delete(int id)
    {
        var deletedGrade = Get(id);
        if (deletedGrade == null)
            return false;
        _grades.Remove(deletedGrade);
        return true;
    }
}
