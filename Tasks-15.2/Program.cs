//Task_15_2_2();
//Console.WriteLine(Average(new int[] { 15, 2, 3}));
Task_15_2_8();

Console.ReadKey();

/// Задание 15.2.1 Aggregate()
/// Факториал натурального числа n — это произведение всех натуральных целых
/// чисел от 1 до n включительно
static long Factorial(int number)
{
    // Коллекция для хранения чисел
    var numbers = new List<int>();

    // Добавляем все числа от 1 до n в коллекцию
    for (int i = 1; i <= number; i++)
        numbers.Add(i);

    // Выполняем агрегацию
    return numbers.Aggregate((x, y) => x * y);
}

/// Задание 15.2.2 Count()
/// Дан список контактов, посчитайте, у скольких из них неверные номера
/// телефонов (верный телефон содержит 11 цифр и начинается с семёрки).
static void Task_15_2_2()
{
    var contacts = new List<Contact>()
    {
       new Contact() { Name = "Андрей", Phone = 79994500508 },
       new Contact() { Name = "Сергей", Phone = 799990455 },
       new Contact() { Name = "Иван", Phone = 79999675334 },
       new Contact() { Name = "Игорь", Phone = 8884994 },
       new Contact() { Name = "Анна", Phone = 665565656 },
       new Contact() { Name = "Василий", Phone = 3434 }
    };

    var cont = contacts.Count(c => c.Phone.ToString().StartsWith("7") && c.Phone.ToString().Length == 11);

    Console.Write($"Верных номеров: {cont}");
}

/// Решение от Skill Factory
static void Task_15_2_2SF()
{
    var contacts = new List<Contact>()
    {
       new Contact() { Name = "Андрей", Phone = 79994500508 },
       new Contact() { Name = "Сергей", Phone = 799990455 },
       new Contact() { Name = "Иван", Phone = 79999675334 },
       new Contact() { Name = "Игорь", Phone = 8884994 },
       new Contact() { Name = "Анна", Phone = 665565656 },
       new Contact() { Name = "Василий", Phone = 3434 }
    };

    var invalidContacts =
       (from contact in contacts // пробегаемся по контактам
        let phoneString = contact.Phone.ToString() // сохраняем в промежуточную переменную строку номера телефона
        where !phoneString.StartsWith('7') || phoneString.Length != 11 // выполняем выборку по условиям
        select contact) // добавляем объект в выборку
       .Count(); // считаем количество объектов в выборке

    Console.Write($"Верных номеров: {invalidContacts}");
}

/// Задание 15.2.3
/// Напишите метод, возвращающий среднее арифметическое числовых объектов коллекции.
static double Average(int[] numbers)
{
    return numbers.Sum() / (double)numbers.Length;
}

/// Задание 15.2.8
/// 
///
static void Task_15_2_8()
{
    List<int> list = new();
    
    while(true)
    {
        Console.Write("Введите число: ");

        var input = Console.ReadLine();

        var isInteger = Int32.TryParse(input, out int inputNum);

        if (!isInteger)
            Console.WriteLine("Вы ввели не число!");
        else
        { 

            list.Add(inputNum);
            Console.WriteLine($"В списке чисел: {list.Count()}");
            Console.WriteLine($"Сумма чисел: {list.Sum()}");
            Console.WriteLine($"Наименьшее: {list.Min()}");
            Console.WriteLine($"Наибольшее: {list.Max()}");
            Console.WriteLine($"Среднее значение: {(double)list.Average()}");
        }
    }
}

public class Contact
{
    public string Name { get; set; }
    public long Phone { get; set; }
}