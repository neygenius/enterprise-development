using EduEDiary.Domain;

namespace EduEDiary.Tests;

public class EduEDiaryTests() : IClassFixture<EduEDiaryTestData>
{
    // ��������: ������� ���������� ��� ���� ���������
    [Fact]
    public void AllSubjectsTest()
    {
        var subjects = EduEDiaryTestData.TestGradesList()
            .Select(g => g.Subject).ToList();

        Assert.Contains(subjects, s => s.Name == "����������");
        Assert.Contains(subjects, s => s.Name == "������� ����");
        Assert.Contains(subjects, s => s.Name == "����������");
        Assert.Contains(subjects, s => s.Name == "�������");
        Assert.Contains(subjects, s => s.Name == "������");
    }

    // ��������: ������� ���������� ��� ���� �������� � ��������� ������, ����������� �� ���
    [Fact]
    public void AllStudentsInSelectedClassTest()
    {
        var classId = 3;

        var students = EduEDiaryTestData.TestGradesList()
            .Select (g => g.Student)
            .Where (s => s.Class.Id == classId)
            .OrderBy(s => s.FullName)
            .ToList();

        Assert.Equal("������� ������ ��������", students.First().FullName);
    }

    // ��������: ������� ���������� ��� ���� ��������, ���������� ������ � ��������� ����
    [Fact]
    public void AllStudentsThatGetGradeInSelectedDayTest()
    {
        var day = new DateOnly(2023, 10, 16);

        var students = EduEDiaryTestData.TestGradesList()
            .Where(g => g.Date == day)
            .Select(g => g.Student)
            .Distinct()
            .ToList();

        Assert.Contains(students, s => s.FullName == "������ ������� ��������");
        Assert.Contains(students, s => s.FullName == "������ ������ ����������");
        Assert.Contains(students, s => s.FullName == "�������� ���� ����������");
    }

    // ��������: ������� ��� 5 �������� �� �������� �����
    [Fact]
    public void TopFiveStudentsForAvgGradeTest()
    {
        var students = EduEDiaryTestData.TestGradesList()
            .GroupBy(g => g.Student)
            .Select(g => new {
                Student = g.Key,
                AvgGrade = g.Average(gr => gr.Grade)
            })
            .OrderByDescending(a => a.AvgGrade)
            .ThenBy(a => a.Student.Id)
            .Take(5)
            .ToList();

        Assert.Equal("������ ������� ��������", students[0].Student.FullName);
        Assert.Equal("������ ������ ����������", students[1].Student.FullName);
        Assert.Equal("������� ������ ��������", students[2].Student.FullName);
        Assert.Equal("�������� ���� ����������", students[3].Student.FullName);
        Assert.Equal("�������� ������� ����������", students[4].Student.FullName);
    }

    // ��������: ������� �������� � ������������ ������� ������ �� ��������� ������
    [Fact]
    public void StudentsWithMaxAvgGradeForTimeSpanTest()
    {
        var start = new DateOnly(2023, 10, 05);
        var end = new DateOnly(2023, 10, 25);

        var sGrades = EduEDiaryTestData.TestGradesList()
            .Where(g => g.Date >= start && g.Date <= end)
            .GroupBy(g => g.Student)
            .Select(g => new {
                Student = g.Key,
                AvgGrade = g.Average(gr => gr.Grade)
            })
            .ToList();

        var maxAvgGrade = sGrades.Max(a => a.AvgGrade);

        var students = sGrades
            .Where(a => a.AvgGrade == maxAvgGrade)
            .Select(a => a.Student)
            .ToList();

        Assert.Equal("������ ������� ��������", students.First().FullName);
    }

    // ��������: ������� ���������� � �����������, ������� � ������������ ����� �� ������� ��������
    [Fact]
    public void MinAvgMaxGradeForEachSubjectTest()
    {
        var statistics = EduEDiaryTestData.TestGradesList()
            .GroupBy(g => g.Subject)
            .Select(g => new
            {
                Subject = g.Key,
                MinGrade = g.Min(gr => gr.Grade),
                MaxGrade = g.Max(gr => gr.Grade),
                AvgGrade = g.Average(gr => gr.Grade)
            })
            .ToList();

        Assert.Contains(statistics, s => s.Subject.Id == 1 && s.MinGrade == 3 && s.AvgGrade > 3.59 && s.AvgGrade < 3.61 && s.MaxGrade == 5);
        Assert.Contains(statistics, s => s.Subject.Id == 2 && s.MinGrade == 4 && s.AvgGrade > 4.39 && s.AvgGrade < 4.41 && s.MaxGrade == 5);
        Assert.Contains(statistics, s => s.Subject.Id == 3 && s.MinGrade == 3 && s.AvgGrade > 4.39 && s.AvgGrade < 4.41 && s.MaxGrade == 5);
        Assert.Contains(statistics, s => s.Subject.Id == 4 && s.MinGrade == 3 && s.AvgGrade > 3.99 && s.AvgGrade < 4.01 && s.MaxGrade == 5);
        Assert.Contains(statistics, s => s.Subject.Id == 5 && s.MinGrade == 3 && s.AvgGrade > 3.79 && s.AvgGrade < 3.81 && s.MaxGrade == 4);
    }
}