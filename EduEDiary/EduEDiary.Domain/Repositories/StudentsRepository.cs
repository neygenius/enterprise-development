namespace EduEDiary.Domain.Repositories;

public class StudentsRepository : IRepository<Students>
{
    private readonly List<Students> _students = [];
    private int _id = 1;

    public List<Students> GetAll() => _students;

    public Students? Get(int id) => _students.Find(s => s.Id == id);

    public void Post(Students obj)
    {
        obj.Id = _id++;
        _students.Add(obj);
    }

    public bool Put(Students obj, int id)
    {
        var oldStudent = Get(id);
        if (oldStudent == null)
            return false;
        oldStudent.Id = obj.Id;
        oldStudent.Passport = obj.Passport;
        oldStudent.FullName = obj.FullName;
        oldStudent.BirthDate = obj.BirthDate;
        oldStudent.Class = obj.Class;
        return true;
    }

    public bool Delete(int id)
    {
        var deletedStudent = Get(id);
        if (deletedStudent == null)
            return false;
        _students.Remove(deletedStudent);
        return true;
    }
}
