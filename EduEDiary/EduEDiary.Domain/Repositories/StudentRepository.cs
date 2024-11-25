namespace EduEDiary.Domain.Repositories;

public class StudentRepository : IRepository<Student>
{
    private readonly List<Student> _students = [];
    private int _id = 1;

    public List<Student> GetAll() => _students;

    public Student? Get(int id) => _students.Find(s => s.Id == id);

    public void Post(Student obj)
    {
        obj.Id = _id++;
        _students.Add(obj);
    }

    public bool Put(Student obj, int id)
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
