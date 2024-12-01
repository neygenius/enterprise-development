using Microsoft.EntityFrameworkCore;

namespace EduEDiary.Domain.Repositories;

public class SubjectRepository(EduEDiaryContext context) : IRepository<Subject>
{
    public async Task<List<Subject>> GetAll() => await context.Subjects.ToListAsync();

    public async Task<Subject?> Get(int id) => await context.Subjects.FindAsync(id);

    public async Task Post(Subject obj)
    {
        await context.Subjects.AddAsync(obj);
        await context.SaveChangesAsync();
    }

    public async Task Put(Subject obj, int id)
    {
        var oldSubject = await Get(id);
        if (oldSubject == null)
            return;

        oldSubject.Name = obj.Name;
        oldSubject.Year = obj.Year;
        context.Subjects.Update(oldSubject);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var deletedSubject = await Get(id);
        if (deletedSubject == null)
            return;

        context.Subjects.Remove(deletedSubject);
        await context.SaveChangesAsync();
    }
}
