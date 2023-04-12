

var classes = new[]
           {
               new Classroom { Students = {"Evgeniy", "Sergey", "Andrew"}, },
               new Classroom { Students = {"Anna", "Viktor", "Vladimir"}, },
               new Classroom { Students = {"Bulat", "Alex", "Galina"}, }
           };
var allStudents = GetAllStudents(classes);

Console.WriteLine(string.Join(" ", allStudents));
GetAllStudents(classes);

Console.ReadKey();

static string[] GetAllStudents(Classroom[] classes)
{
    return null;
}

public class Classroom
{
    public List<string> Students = new List<string>();
}