//Task_15_1_4();
//Task_15_1_5();
Task_15_1_6();
//Task_15_1_6SF();

Console.ReadKey();

// Задание 15.1.4
// Напишите метод для поиска общих букв в двух словах.
static void Task_15_1_4()
{
    string word1 = "Hello";
    string word2 = "Word";

    //char[] word1Char = word1.ToArray();
    //char[] word2Char = word2.ToArray();

    //var chars = word1Char.Intersect(word2Char);
    var chars = word1.Intersect(word2);

    foreach (var v in chars)
        Console.WriteLine(v);
}

// Задание 15.1.5
// Напишите недостающий код так, чтобы на выходе мы получили список всех IT-компаний без повторений.
static void Task_15_1_5()
{
    var softwareManufacturers = new List<string>() { "Microsoft", "Apple", "Oracle" };
    var hardwareManufacturers = new List<string>() { "Apple", "Samsung", "Intel" };

    var itCompanies = softwareManufacturers.Union(hardwareManufacturers);
    foreach (var v in itCompanies)
        Console.WriteLine(v);
}

///<summary>
///Задание 15.1.6
/// Напишите программу, которая будет принимать на вход строку текста с консоли
/// и выводить в ответ список содержащихся в строке уникальных символов
/// без пробелов и следующих знаков препинания: , . ; :  ? !.
///</summary>
// Мое решение:
static void Task_15_1_6()
{
    Console.Write("Напишите что-нибудь: ");
    string text = Console.ReadLine();

    // Удаляем пунктуацию
    var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
    noPunctuationText = noPunctuationText.Replace(" ", string.Empty);

    var uniqueArr = noPunctuationText.Union(noPunctuationText);

    foreach (var v in uniqueArr)
        Console.Write(v);
}

// Решение от SF:
static void Task_15_1_6SF()
{
    Console.WriteLine("Введите текст:");

    // читаем ввод
    var text = Console.ReadLine();

    // сохраняем список знаков препинания и символ пробела в коллекцию
    var punctuation = new List<char>() { ' ', ',', '.', ';', ':', '!', '?' };

    // валидация ввода
    if (string.IsNullOrEmpty(text))
    {
        Console.WriteLine("Вы ввели пустой текст");
        return;
    }

    Console.WriteLine();
    Console.WriteLine("Текст без знаков препинания: ");

    // так как строка - это массив char, мы можем вызвать метод  except  и удалить знаки препинания
    var noPunctuation = text.Except(punctuation).ToArray();

    // вывод
    Console.WriteLine(noPunctuation);
}