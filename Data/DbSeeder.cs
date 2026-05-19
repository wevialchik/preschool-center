using nз3.Models;

namespace nз3.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(SchoolContext context)
    {
        if (context.Children.Any()) return;

        var children = new List<Child>
        {
            new Child { FullName = "Верховых Виктория Алексеевна", BirthDate = new DateTime(2020, 4, 25), InsuranceNumber = "SNILS001" },
            new Child { FullName = "Косолапова Виктория Дмитриевна", BirthDate = new DateTime(2021, 5, 5), InsuranceNumber = "SNILS002" },
            new Child { FullName = "Дробжева Анна Дмитриевна", BirthDate = new DateTime(2020, 11, 10), InsuranceNumber = "SNILS003" },
            new Child { FullName = "Барышников Владислав Владимирович", BirthDate = new DateTime(2020, 5, 27), InsuranceNumber = "SNILS004" }
        };

        await context.Children.AddRangeAsync(children);
        await context.SaveChangesAsync();

        // Расширенные описания курсов
        var courses = new List<Course>
        {
            new Course 
            { 
                Title = "Математика", 
                Description = "Развитие логического мышления через игровые задания. Дети учатся считать до 100, решать примеры на сложение и вычитание, знакомятся с геометрическими фигурами. Занятия проходят с использованием ярких наглядных пособий и интерактивных игр. Формируем навыки работы в тетради и самостоятельного решения задач. Каждое занятие включает физкультминутку и творческое задание.", 
                MaxStudents = 15 
            },
            new Course 
            { 
                Title = "Английский язык", 
                Description = "Погружение в английский язык через песни, сказки и ролевые игры. Дети учатся понимать речь на слух, правильно произносить звуки и составлять простые предложения. Изучаем алфавит, базовую лексику (семья, животные, цвета, еда) и простые диалоги. Занятия ведутся носителем языка с педагогическим образованием. Используем методику полного физического реагирования (TPR).", 
                MaxStudents = 12 
            },
            new Course 
            { 
                Title = "Рисование и творчество", 
                Description = "Развитие мелкой моторики и творческого воображения. Дети знакомятся с различными техниками: акварель, гуашь, пластилинография, аппликация. Учимся смешивать цвета, создавать композиции и выражать эмоции через рисунок. Каждое занятие завершается мини-выставкой работ. Развиваем усидчивость, аккуратность и художественный вкус. Готовим работы к городским конкурсам детского творчества.", 
                MaxStudents = 10 
            },
            new Course 
            { 
                Title = "Чтение и развитие речи", 
                Description = "Формирование навыков чтения и грамотной речи. Дети изучают буквы, учатся складывать слоги и читать слова. Отрабатываем правильное произношение звуков, развиваем дикцию через чистоговорки и скороговорки. Учимся пересказывать тексты, составлять рассказы по картинкам и вести диалог. Занятия включают логоритмику и дыхательную гимнастику.", 
                MaxStudents = 8 
            },
            new Course 
            { 
                Title = "Подготовка руки к письму", 
                Description = "Комплексная программа для развития графических навыков. Дети учатся правильно держать ручку, проводить линии по образцу, штриховать и раскрашивать в пределах контура. Выполняем упражнения на координацию 'глаз-рука', развиваем пространственное мышление. Готовим руку к письму в прописях через игры с песком, крупами и специальными тренажерами.", 
                MaxStudents = 10 
            }
        };

        await context.Courses.AddRangeAsync(courses);
        await context.SaveChangesAsync();

        var enrollments = new List<ChildCourse>
        {
            new ChildCourse { ChildId = 1, CourseId = 1, EnrollmentDate = new DateTime(2025, 9, 1) },
            new ChildCourse { ChildId = 1, CourseId = 2, EnrollmentDate = new DateTime(2025, 9, 1) },
            new ChildCourse { ChildId = 2, CourseId = 3, EnrollmentDate = new DateTime(2025, 9, 5) },
            new ChildCourse { ChildId = 3, CourseId = 1, EnrollmentDate = new DateTime(2025, 9, 10) },
            new ChildCourse { ChildId = 4, CourseId = 1, EnrollmentDate = new DateTime(2025, 9, 15) },
            new ChildCourse { ChildId = 4, CourseId = 2, EnrollmentDate = new DateTime(2025, 9, 15) },
            new ChildCourse { ChildId = 4, CourseId = 4, EnrollmentDate = new DateTime(2025, 9, 15) },
            new ChildCourse { ChildId = 1, CourseId = 5, EnrollmentDate = new DateTime(2025, 9, 20) }
        };

        await context.ChildCourses.AddRangeAsync(enrollments);
        await context.SaveChangesAsync();
    }
}