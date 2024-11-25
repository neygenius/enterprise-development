using EduEDiary.Domain;

namespace EduEDiary.Tests;

public class EduEDiaryTestData
{
    public static List<Grades> TestGradesList()
    {
        // Создание классов
        var class1 = new Classes { Id = 1, Number = 8, Letter = "A" };
        var class2 = new Classes { Id = 2, Number = 8, Letter = "Б" };
        var class3 = new Classes { Id = 3, Number = 9, Letter = "A" };
        var class4 = new Classes { Id = 4, Number = 9, Letter = "Б" };
        var class5 = new Classes { Id = 5, Number = 11, Letter = "A" };

        // Создание предметов
        var subject1 = new Subjects { Id = 1, Name = "Математика", Year = "2022-2023" };
        var subject2 = new Subjects { Id = 2, Name = "Русский язык", Year = "2022-2023" };
        var subject3 = new Subjects { Id = 3, Name = "Литература", Year = "2022-2023" };
        var subject4 = new Subjects { Id = 4, Name = "История", Year = "2022-2023" };
        var subject5 = new Subjects { Id = 5, Name = "Физика", Year = "2022-2023" };

        // Создание учащихся
        var student1 = new Students { 
            Id = 1, 
            Passport = "1234 567890", 
            FullName = "Иванов Николай Егорович", 
            BirthDate = new DateOnly(2005, 5, 15), 
            Class = class1 
        };
        var student2 = new Students { 
            Id = 2, 
            Passport = "2345 678901", 
            FullName = "Петров Алекей Дмитриевич", 
            BirthDate = new DateOnly(2005, 4, 20), 
            Class = class2 
        };
        var student3 = new Students { 
            Id = 3, 
            Passport = "3456 789012", 
            FullName = "Сидоров Михаил Иванович", 
            BirthDate = new DateOnly(2005, 3, 10), 
            Class = class3 
        };
        var student4 = new Students { 
            Id = 4, 
            Passport = "4567 890123", 
            FullName = "Кузнецов Василий Алексеевич", 
            BirthDate = new DateOnly(2004, 2, 25), 
            Class = class4 
        };
        var student5 = new Students { 
            Id = 5, 
            Passport = "5678 901234", 
            FullName = "Максимов Семён Викторович", 
            BirthDate = new DateOnly(2004, 1, 5), 
            Class = class5 
        };

        // Создание ведомости
        var grades = new List<Grades>
        {
            new() { 
                Id = 1, 
                Student = student1, 
                Subject = subject1, 
                Grade = 5, 
                Date = new DateOnly(2023, 10, 10) 
            },
            new() { 
                Id = 2, 
                Student = student1, 
                Subject = subject2, 
                Grade = 5, 
                Date = new DateOnly(2023, 10, 16) 
            },
            new() { 
                Id = 3, 
                Student = student1, 
                Subject = subject3, 
                Grade = 5, 
                Date = new DateOnly(2023, 10, 11) 
            },
            new() { 
                Id = 4, 
                Student = student1, 
                Subject = subject4, 
                Grade = 5, 
                Date = new DateOnly(2023, 10, 13) 
            },
            new() { 
                Id = 5, 
                Student = student1, 
                Subject = subject5, 
                Grade = 4, 
                Date = new DateOnly(2023, 10, 12) 
            },
            new() { 
                Id = 6, 
                Student = student2, 
                Subject = subject1, 
                Grade = 4, 
                Date = new DateOnly(2023, 10, 17) 
            },
            new() { 
                Id = 7, 
                Student = student2, 
                Subject = subject2, 
                Grade = 4, 
                Date = new DateOnly(2023, 10, 16) 
            },
            new() { 
                Id = 8, 
                Student = student2, 
                Subject = subject3, 
                Grade = 5, 
                Date = new DateOnly(2023, 10, 16) 
            },
            new() { 
                Id = 9, 
                Student = student2, 
                Subject = subject4, 
                Grade = 3, 
                Date = new DateOnly(2023, 10, 18) 
            },
            new() { 
                Id = 10, 
                Student = student2, 
                Subject = subject5, 
                Grade = 4, 
                Date = new DateOnly(2023, 10, 19) 
            },
            new() { 
                Id = 11, 
                Student = student3, 
                Subject = subject1, 
                Grade = 3, 
                Date = new DateOnly(2023, 10, 10) 
            },
            new() { 
                Id = 12, 
                Student = student3, 
                Subject = subject2, 
                Grade = 4, 
                Date = new DateOnly(2023, 10, 09) 
            },
            new() { 
                Id = 13, 
                Student = student3, 
                Subject = subject3, 
                Grade = 4, 
                Date = new DateOnly(2023, 10, 09) 
            },
            new() { 
                Id = 14, 
                Student = student3, 
                Subject = subject4, 
                Grade = 5, 
                Date = new DateOnly(2023, 10, 19) 
            },
            new() { 
                Id = 15, 
                Student = student3, 
                Subject = subject5, 
                Grade = 4, 
                Date = new DateOnly(2023, 10, 13) 
            },
            new() { 
                Id = 16, 
                Student = student4, 
                Subject = subject1, 
                Grade = 3, 
                Date = new DateOnly(2023, 10, 14) 
            },
            new() { 
                Id = 17, 
                Student = student4, 
                Subject = subject2, 
                Grade = 4, 
                Date = new DateOnly(2023, 10, 07) 
            },
            new() { 
                Id = 18, 
                Student = student4, 
                Subject = subject3, 
                Grade = 3, 
                Date = new DateOnly(2023, 10, 07) 
            },
            new() { 
                Id = 19, 
                Student = student4, 
                Subject = subject4, 
                Grade = 3, 
                Date = new DateOnly(2023, 10, 12) 
            },
            new() { 
                Id = 20, 
                Student = student4, 
                Subject = subject5, 
                Grade = 4, 
                Date = new DateOnly(2023, 10, 13) 
            },
            new() { 
                Id = 21, 
                Student = student5, 
                Subject = subject1, 
                Grade = 3, 
                Date = new DateOnly(2023, 10, 13) 
            },
            new() { 
                Id = 22, 
                Student = student5, 
                Subject = subject2, 
                Grade = 5, 
                Date = new DateOnly(2023, 10, 16) 
            },
            new() { 
                Id = 23, 
                Student = student5, 
                Subject = subject3, 
                Grade = 5, 
                Date = new DateOnly(2023, 10, 16) 
            },
            new() { 
                Id = 24, 
                Student = student5, 
                Subject = subject4, 
                Grade = 4, 
                Date = new DateOnly(2023, 10, 18) 
            },
            new() { 
                Id = 25, 
                Student = student5, 
                Subject = subject5, 
                Grade = 3, 
                Date = new DateOnly(2023, 10, 20) 
            },
        };

        return grades;
    }
}