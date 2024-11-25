namespace EduEDiary.Tests;

public class EduEDiaryTests() : IClassFixture<EduEDiaryTestData>
{
    /// <summary>
    /// Проверка: Вывести информацию обо всех предметах
    /// </summary>
    [Fact]
    public void AllSubjectsTest()
    {
        var subjects = EduEDiaryTestData.TestGradesList()
            .Select(g => g.Subject).ToList();

        Assert.Contains(subjects, s => s.Name == "Математика");
        Assert.Contains(subjects, s => s.Name == "Русский язык");
        Assert.Contains(subjects, s => s.Name == "Литература");
        Assert.Contains(subjects, s => s.Name == "История");
        Assert.Contains(subjects, s => s.Name == "Физика");
    }

    /// <summary>
    /// Проверка: Вывести информацию обо всех учениках в указанном классе, упорядочить по ФИО
    /// </summary>
    [Fact]
    public void AllStudentsInSelectedClassTest()
    {
        var classId = 3;

        var students = EduEDiaryTestData.TestGradesList()
            .Select(g => g.Student)
            .Where(s => s.Class.Id == classId)
            .OrderBy(s => s.FullName)
            .ToList();

        Assert.Equal("Сидоров Михаил Иванович", students.First().FullName);
    }

    /// <summary>
    /// Проверка: Вывести информацию обо всех учениках, получивших оценки в указанный день
    /// </summary>
    [Fact]
    public void AllStudentsThatGetGradeInSelectedDayTest()
    {
        var day = new DateOnly(2023, 10, 16);

        var students = EduEDiaryTestData.TestGradesList()
            .Where(g => g.Date == day)
            .Select(g => g.Student)
            .Distinct()
            .ToList();

        Assert.Contains(students, s => s.FullName == "Иванов Николай Егорович");
        Assert.Contains(students, s => s.FullName == "Петров Алекей Дмитриевич");
        Assert.Contains(students, s => s.FullName == "Максимов Семён Викторович");
    }

    /// <summary>
    /// Проверка: Вывести топ 5 учеников по среднему баллу
    /// </summary>
    [Fact]
    public void TopFiveStudentsForAvgGradeTest()
    {
        var students = EduEDiaryTestData.TestGradesList()
            .GroupBy(g => g.Student)
            .Select(g => new
            {
                Student = g.Key,
                AvgGrade = g.Average(gr => gr.GradeValue)
            })
            .OrderByDescending(a => a.AvgGrade)
            .ThenBy(a => a.Student.Id)
            .Take(5)
            .ToList();

        Assert.Equal("Иванов Николай Егорович", students[0].Student.FullName);
        Assert.Equal("Петров Алекей Дмитриевич", students[1].Student.FullName);
        Assert.Equal("Сидоров Михаил Иванович", students[2].Student.FullName);
        Assert.Equal("Максимов Семён Викторович", students[3].Student.FullName);
        Assert.Equal("Кузнецов Василий Алексеевич", students[4].Student.FullName);
    }

    /// <summary>
    /// Проверка: Вывести учеников с максимальным средним баллом за указанный период
    /// </summary>
    [Fact]
    public void StudentsWithMaxAvgGradeForTimeSpanTest()
    {
        var start = new DateOnly(2023, 10, 05);
        var end = new DateOnly(2023, 10, 25);

        var sGrades = EduEDiaryTestData.TestGradesList()
            .Where(g => g.Date >= start && g.Date <= end)
            .GroupBy(g => g.Student)
            .Select(g => new
            {
                Student = g.Key,
                AvgGrade = g.Average(gr => gr.GradeValue)
            })
            .ToList();

        var maxAvgGrade = sGrades.Max(a => a.AvgGrade);

        var students = sGrades
            .Where(a => a.AvgGrade == maxAvgGrade)
            .Select(a => a.Student)
            .ToList();

        Assert.Equal("Иванов Николай Егорович", students.First().FullName);
    }

    /// <summary>
    /// Проверка: Вывести информацию о минимальном, среднем и максимальном балле по каждому предмету
    /// </summary>
    [Fact]
    public void MinAvgMaxGradeForEachSubjectTest()
    {
        var statistics = EduEDiaryTestData.TestGradesList()
            .GroupBy(g => g.Subject)
            .Select(g => new
            {
                Subject = g.Key,
                MinGrade = g.Min(gr => gr.GradeValue),
                MaxGrade = g.Max(gr => gr.GradeValue),
                AvgGrade = g.Average(gr => gr.GradeValue)
            })
            .ToList();

        Assert.Contains(statistics, s => s.Subject.Id == 1 && s.MinGrade == 3 && s.AvgGrade > 3.59 && s.AvgGrade < 3.61 && s.MaxGrade == 5);
        Assert.Contains(statistics, s => s.Subject.Id == 2 && s.MinGrade == 4 && s.AvgGrade > 4.39 && s.AvgGrade < 4.41 && s.MaxGrade == 5);
        Assert.Contains(statistics, s => s.Subject.Id == 3 && s.MinGrade == 3 && s.AvgGrade > 4.39 && s.AvgGrade < 4.41 && s.MaxGrade == 5);
        Assert.Contains(statistics, s => s.Subject.Id == 4 && s.MinGrade == 3 && s.AvgGrade > 3.99 && s.AvgGrade < 4.01 && s.MaxGrade == 5);
        Assert.Contains(statistics, s => s.Subject.Id == 5 && s.MinGrade == 3 && s.AvgGrade > 3.79 && s.AvgGrade < 3.81 && s.MaxGrade == 4);
    }
}