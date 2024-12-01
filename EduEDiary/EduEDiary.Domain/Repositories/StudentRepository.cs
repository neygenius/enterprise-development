using Microsoft.EntityFrameworkCore;

namespace EduEDiary.Domain.Repositories;

public class StudentRepository(EduEDiaryContext context) : IRepository<Student>
{
    public async Task<List<Student>> GetAll() => await context.Students.Include(s => s.Class).ToListAsync();

    public async Task<Student?> Get(int id) => await context.Students.Include(s => s.Class).FirstOrDefaultAsync(s => s.Id == id);

    public async Task Post(Student obj)
    {
        await context.Students.AddAsync(obj);
        await context.SaveChangesAsync();
    }

    public async Task Put(Student obj, int id)
    {
        var oldStudent = await Get(id);
        if (oldStudent == null)
            return;

        oldStudent.Passport = obj.Passport;
        oldStudent.FullName = obj.FullName;
        oldStudent.BirthDate = obj.BirthDate;
        oldStudent.Class = obj.Class;
        context.Students.Update(oldStudent);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var deletedStudent = await Get(id);
        if (deletedStudent == null)
            return;

        context.Students.Remove(deletedStudent);
        await context.SaveChangesAsync();
    }
}
