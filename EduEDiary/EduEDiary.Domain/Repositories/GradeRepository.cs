namespace EduEDiary.Domain.Repositories;

public class GradeRepository : IRepository<Grade>
{
    private readonly List<Grade> _grades = [];
    private int _id = 1;

    public List<Grade> GetAll() => _grades;

    public Grade? Get(int id) => _grades.Find(g => g.Id == id);

    public void Post(Grade obj)
    {
        obj.Id = _id++;
        _grades.Add(obj);
    }

    public bool Put(Grade obj, int id)
    {
        var oldGrade = Get(id);
        if (oldGrade == null)
            return false;
        oldGrade.Id = obj.Id;
        oldGrade.Student = obj.Student;
        oldGrade.Subject = obj.Subject;
        oldGrade.GradeValue = obj.GradeValue;
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
