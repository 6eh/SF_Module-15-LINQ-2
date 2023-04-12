/// 15.6.6. ПРАКТИЧЕСКОЕ ЗАДАНИЕ (HW-03)
/// Напишите метод, который соберет всех учеников всех классов в один список, используя LINQ.

var classes = new[]
           {
               new Classroom { Students = {"Evgeniy", "Sergey", "Andrew"}, },
               new Classroom { Students = {"Anna", "Viktor", "Vladimir"}, },
               new Classroom { Students = {"Bulat", "Alex", "Galina"}, }
           };

var allStudents = GetAllStudents(classes);

Console.WriteLine(string.Join(" ", allStudents));

Console.ReadKey();

static string[] GetAllStudents(Classroom[] classes)
{
    // Решение
    return classes.SelectMany(c => c.Students).ToArray();
}

public class Classroom
{
    public List<string> Students = new List<string>();
}