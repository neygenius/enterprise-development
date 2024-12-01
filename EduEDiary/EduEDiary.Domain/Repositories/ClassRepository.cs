using Microsoft.EntityFrameworkCore;

namespace EduEDiary.Domain.Repositories;

public class ClassRepository(EduEDiaryContext context) : IRepository<Class>
{
    public async Task<List<Class>> GetAll() => await context.Classes.ToListAsync();

    public async Task<Class?> Get(int id) => await context.Classes.FindAsync(id);

    public async Task Post(Class obj)
    {
        await context.Classes.AddAsync(obj);
        await context.SaveChangesAsync();
    }

    public async Task Put(Class obj, int id)
    {
        var oldClass = await Get(id);
        if (oldClass == null)
            return;

        oldClass.Number = obj.Number;
        oldClass.Letter = obj.Letter;
        context.Classes.Update(oldClass);
        await context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var deletedClass = await Get(id);
        if (deletedClass == null)
            return;

        context.Classes.Remove(deletedClass);
        await context.SaveChangesAsync();
    }
}
