using Microsoft.EntityFrameworkCore;

namespace EduEDiary.Domain.Repositories;

public class GradeRepository(EduEDiaryContext context) : IRepository<Grade>
{
    public async Task<List<Grade>> GetAll() => await context.Grades.Include(g => g.Student).Include(g => g.Subject).ToListAsync();

    public async Task<Grade?> Get(int id) => await context.Grades.Include(g => g.Student).Include(g => g.Subject).FirstOrDefaultAsync(g => g.Id == id);

    public async Task Post(Grade obj)
    {
        await context.Grades.AddAsync(obj);
        await context.SaveChangesAsync();
    }

    public async Task Put(Grade obj, int id)
    {
        var oldGrade = await Get(id);
        if (oldGrade == null)
            return;

        oldGrade.Student = obj.Student;
        oldGrade.Subject = obj.Subject;
        oldGrade.GradeValue = obj.GradeValue;
        oldGrade.Date = obj.Date;
        context.Grades.Update(oldGrade);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var deletedGrade = await Get(id);
        if (deletedGrade == null)
            return;

        context.Grades.Remove(deletedGrade);
        await context.SaveChangesAsync();
    }
}
