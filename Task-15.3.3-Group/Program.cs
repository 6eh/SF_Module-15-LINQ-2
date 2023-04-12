/* Задание 15.3.3
 * Дан список контактов.
 * Некоторые из них имеют реальный email-адрес, а некоторые — фейковый (те, которые в домене example).
 * Нам нужно разбить их на две группы: фейковые и реальные, и вывести результат в консоль.
 * Решите эту задачу с помощью группировки.
 */

var phoneBook = new List<Contact>();

// добавляем контакты
phoneBook.Add(new Contact("Игорь", 79990000001, "igor@example.com"));
phoneBook.Add(new Contact("Сергей", 79990000010, "serge@example.com"));
phoneBook.Add(new Contact("Анатолий", 79990000011, "anatoly@example.com"));
phoneBook.Add(new Contact("Валерий", 79990000012, "valera@example.com"));
phoneBook.Add(new Contact("Сергей", 799900000013, "serg@gmail.com"));
phoneBook.Add(new Contact("Иннокентий", 799900000013, "innokentii@example.com"));

//MySolution(phoneBook);
SFSolution(phoneBook);

Console.ReadKey();

static void MySolution(List<Contact> phoneBook)
{
    var contactsGroups = phoneBook
        .GroupBy(contact => !contact.Email.Contains("@example"))
        .Select(g => new
        {
            Name = g.Key,
            Count = g.Count(),
            Contacts = g.Select(c => c)
        });

    foreach (var group in contactsGroups)
    {
        Console.WriteLine($"{group.Name} ({group.Count}):");

        foreach (var contact in group.Contacts)
            Console.WriteLine($" {contact.Name} ({contact.Email})");
        Console.WriteLine();
    }
}

static void SFSolution(List<Contact> phoneBook)
{
    //  в качестве критерия группировки передаем домен адреса электронной почты
    var grouped = phoneBook.GroupBy(c => c.Email.Split("@").Last());

    // обрабатываем получившиеся группы
    foreach (var group in grouped)
    {
        // если ключ содержит example, значит, это фейк
        if (group.Key.Contains("example"))
        {
            Console.WriteLine("Фейковые адреса: ");

            foreach (var contact in group)
                Console.WriteLine(contact.Name + " " + contact.Email);

        }
        else
        {
            Console.WriteLine("Реальные адреса: ");
            foreach (var contact in group)
                Console.WriteLine(contact.Name + " " + contact.Email);
        }

        Console.WriteLine();
    }
}

public class Contact
{
    public string Name { get; set; }
    public long Phone { get; set; }
    public string Email { get; set; }
    public Contact(string name, long phone, string email)
    {
        Name = name;
        Phone = phone;
        Email = email;
    }
}