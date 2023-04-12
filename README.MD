<H1>LINQ Операции с множествами.</H1>

<b>Except() - Разность</b><br />
Исключает из одной коллекции то, что содержится в другой. <b>Важно!</b> Метод Except() возвращает только уникальные элементы.
```csharp
string[] drinks = { "Вода", "Кока-кола", "Лимонад" , "Вино"}; // Список напитков в продаже
string[] alcohol = { "Вино", "Пиво", "Сидр"}; // Алкогольные напитки
 
// Убираем алкоголь из ассортимента
var drinksForKids = drinks.Except(alcohol);
 
foreach (string drink in drinksForKids)
   Console.WriteLine(drink);

// Вывод: Вода Кока-кола Лимонад
```
<br />

<b>Intersect() - Пересечение</b><br />
Находит общие элементы коллекций.
```csharp
string[] cars = { "Волга", "Москвич", "Нива", "Газель" };
string[] buses = { "Газель", "Икарус", "ЛиАЗ"};
 
// поищем машины, которые можно считать микроавтобусами
var microBuses = cars.Intersect(buses);
 
foreach (string mb in microBuses)
   Console.WriteLine(mb);

// Вывод: Газель
```
<br />

<b>Union() - Объединение (с проверкой на уникальнось)</b><br />
Объединяет две коллекции. В результате получится коллекция с элементами из первой и второй, <b>но без повторений</b>.
```csharp
string[] cars = { "Волга", "Москвич", "Москвич", "Нива", "Газель" };
string[] buses = { "Газель", "Икарус", "ЛиАЗ"};
 
var vehicles = cars.Union(buses);
 
foreach (string v in vehicles)
   Console.WriteLine(v);

// Вывод: Волга Москвич Нива Газель Икарус ЛиАЗ
```
<br />

<b>Concat() - Соединение (без проверки на уникальность)</b><br />
Прибавляет данные одной коллекции к другой, не заботясь о дублировании.
```csharp
string[] cars = { "Волга", "Москвич" };
string[] buses = { "Газель", "Икарус" };

var vehicles = cars.Concat(buses);

foreach (string v in vehicles)
   Console.WriteLine(v);

// Вывод: Волга Москчвич Газель Икарус
```
<br />

<b>Distinct() - Проверка на дубликаты</b><br />
Проверяет коллекцию на наличие дубликатов и удалить их.
```csharp
string[] cars = { "Волга", "Москвич", "Москвич", "Нива", "Газель" };
 
// удалим дубликаты
var uniqueCars = cars.Distinct();
 
foreach (string v in uniqueCars)
   Console.WriteLine(v);

// Вывод: Волга Москвич Нива Газель
```
<br />
Последовательно вызвав cars.Concat(buses).Distinct(), мы получим результат, идентичный cars.Union(buses).
<br />
<hr>
<br />
<h1>LINQ. Операции агрегации.</h1>
<br />

<b>Aggregate()</b><br />
С помощью этого метода можно выполнить, к примеру, выполнение арифметического действия с элементами коллекции.
```csharp
int[] numbers = { 1, 2, 3, 4, 5};
int result = numbers.Aggregate((x,y)=> x - y);
 
// вычислит 1-2-3-4-5 = -13
Console.WriteLine(result);
```
Другие арифметические действия также возможны:
```csharp
int sum = numbers.Aggregate((x,y)=> x + y);
```
<br />

<b>Count()</b><br />
Метод Count() можно использовать, когда вы хотите не просто посчитать элементы, а  узнать, сколько из них удовлетворяют определенным критериям.
```csharp
// получим тех кто младше 25
var youngStudentsAmount =
   ( from student in students
   where student.Age < 25
   select student).Count();
 
// выведет 1
Console.WriteLine(youngStudentsAmount);
```
Есть другой способ — использовать перегрузку метода Count(), принимающую на вход лямбда-выражение:
```csharp
// получим тех, кто младше 25
var youngStudentsAmount = students.Count(s => s.Age < 25);
 
// тоже выведет 1
Console.WriteLine(youngStudentsAmount);
```
<br />

<b>Sum()</b><br />
Суммирование элементов.
<br />Простое сложение:
```csharp
var simpleNumbers = new[] {3, 5, 7};
 
// Вернет 15
Console.WriteLine(simpleNumbers.Sum());
```
Сложный тип данных, сложение свойств:
```csharp
// Список студентов
var  students = new List<Student>
{
   new Student {Name="Андрей", Age=23 },
   new Student {Name="Сергей", Age=27 },
   new Student {Name="Дмитрий", Age=29 }
};
 
// сумма возрастов всех студентов
var totalAge = students.Sum(s => s.Age);
 
// Вернет 79
Console.WriteLine(totalAge);
```
<br />

<b>Мax(), Min(), Average()</b><br />
Поиск наибольшего, наименьшего и среднего числа в коллекции.
```csharp
var nums = new [] { 1, 7, 45, 23 };
 
int greatest = nums.Max();  // наибольшее - 45
int smallest = nums.Min();  // наименьшее - 1
double average = nums.Average();  // среднее - 19
```
Пример сложнее:
```csharp
var  students = new List<Student>
{
   new Student {Name="Андрей", Age=23 },
   new Student {Name="Сергей", Age=27 },
   new Student {Name="Дмитрий", Age=29 }
};
 
// найдем возраст самого старого студента ( 29 )
var oldest = students.Max(s => s.Age);
 
// самого молодого ( 23 )
var youngest = students.Min(s => s.Age);
 
//  и средний возраст ( 26,3 )
var average = students.Average(s => s.Age);
```
<br />
<hr>
<br />
<h1>LINQ. Группировка.</h1>
<br />

<b>GroupBy()</b><br />
Результатом оператора group является выборка, которая состоит из групп.
```csharp
// Список автомобилей: 
var cars = new List<Car>()
{
   new Car("Suzuki", "JP"),
   new Car("Toyota", "JP"),
   new Car("Opel", "DE"),
   new Car("Kamaz", "RUS"),
   new Car("Lada", "RUS"),
   new Car("Honda", "JP"),
};

// Сгруппируем их по стране-производителю (используя ключевое слово groupby):
// Группировка по стране - производителю
var carsByCountry1 = from car in cars
   group car by car.CountryCode;

// или через метод - расширение
var carsByCountry2 = cars.GroupBy(car => car.CountryCode);
 
// Пробежимся по группам
foreach (var grouping in carsByCountry2)
{
   Console.WriteLine(grouping.Key + ":");
  
   // внутри каждой группы пробежимся по элементам
   foreach (var car in grouping)
       Console.WriteLine(car.Manufacturer);
  
   Console.WriteLine();
}
/* Вывод:
 * JP:
 * Suzuki
 * Toyota
 * Honda
 *
 * DE:
 * Opel
 * 
 * RUS
 * Kamaz
 * Lada 
 */
```

При группировке мы можем использовать уже известную вам проекцию для создания объекта нового типа: 
```csharp
var carsByCountry = cars
   .GroupBy(car => car.CountryCode) // группируем по стране-производителю
   .Select(group => new
   { //  создаем новую сущность анонимного типа
       Name = group.Key,
       Amount = group.Count()
   });
```

И даже осуществлять вложенные запросы, используя ключевое слово into:
```csharp
var carsByCountry2 = from car in cars
   group car by car.CountryCode into grouping // выборка в локальную переменную для вложенного запроса
   select new
   {
       Name = grouping.Key,
       Count = grouping.Count(),
       Cars = from p in grouping select p //  выполним подзапрос, чтобы заполнить список машин внутри нашего нового типа
   };
 
// Выведем результат
foreach (var group in carsByCountry2)
{
   // Название группы и количество элементов
   Console.WriteLine($"{group.Name} : {group.Count} авто");
  
   foreach(Car car in group.Cars)
       Console.WriteLine(car.Manufacturer);
  
   Console.WriteLine();
}
```

Аналогичный запрос с помощью метода расширения, выглядит менее громоздким: 
```csharp
var carsByCountry2 = cars
   .GroupBy(car => car.CountryCode)
   .Select(g => new
   {
       Name = g.Key,
       Count = g.Count(),
       Cars = g.Select(c =>c)
   });
```
<br />
<hr>
<br />
<h1>LINQ. Соединение коллекций.</h1>

<br />Соединение в LINQ позволяет объединить разные наборы объектов в коллекциях по общим свойствам
<br /><b>Join()</b><br />

Эту операцию можно применять к двум наборам коллекций, имеющим общий критерий.
```csharp
// Модель автомобиля
public class Car
{
   public string Model { get; set; }
   public string Manufacturer { get; set; }
}
 
// Завод - изготовитель
public class Manufacturer
{
   public string Name { get; set; }
   public string Country { get; set; }
}
```
В данном случае  свойство Manufacturer у Car и Name у класса Manufacturer будут общим ключом, по которому можно соединить эти две сущности.
Создадим набор данных:
```csharp
// Список моделей
var cars = new List<Car>()
{
   new Car() { Model  = "SX4", Manufacturer = "Suzuki"},
   new Car() { Model  = "Grand Vitara", Manufacturer = "Suzuki"},
   new Car() { Model  = "Jimny", Manufacturer = "Suzuki"},
   new Car() { Model  = "Land Cruiser Prado", Manufacturer = "Toyota"},
   new Car() { Model  = "Camry", Manufacturer = "Toyota"},
   new Car() { Model  = "Polo", Manufacturer = "Volkswagen"},
   new Car() { Model  = "Passat", Manufacturer = "Volkswagen"},
};
 
// Список автопроизводителей
var manufacturers = new List<Manufacturer>()
{
   new Manufacturer() { Country = "Japan", Name = "Suzuki" },
   new Manufacturer() { Country = "Japan", Name = "Toyota" },
   new Manufacturer() { Country = "Germany", Name = "Volkswagen" },
};
```
Соединим и сопоставим коллекции:
```csharp
var result = from car in cars // выберем машины
               join m in manufacturers on car.Manufacturer equals m.Name // соединим по общему ключу (имя производителя) с производителями
               select new //   спроецируем выборку в новую анонимную сущность
               {
                   Name = car.Model,
                   Manufacturer = m.Name,
                   Country = m.Country
               };
 
// выведем результаты
foreach (var item in result)
   Console.WriteLine($"{item.Name} - {item.Manufacturer} ({item.Country})");
```
В результате получим модели автомобилей с информацией о марке и стране-изготовителе:
```csharp
SX4 - Suzuki (Japan)
Grand Vitara - Suzuki (Japan)
Jimny - Suzuki (Japan)
Land Cruiser Prado - Toyota (Japan)
Camry - Toyota (Japan)
Polo - Volkswagen (Germany)
Passat - Volkswagen (Germany)
```
Второй вариант, через метор - расширение:
```csharp
var result2 = cars.Join(manufacturers, // передаем в качестве параметра вторую коллекцию
   car => car.Manufacturer, // указываем общее свойство для первой коллекции
   m => m.Name, // указываем общее свойство для второй коллекции
   (car, m) =>
       new // проекция в новый тип
       {
           Name = car.Model,
           Manufacturer = m.Name,
           Country = m.Country
       });
```
<br />
<b>GroupJoin()</b><br />
Позволяет одновременно соединением последовательностей произвести группировку.
```csharp
// Выборка + группировка
var result2 =  manufacturers.GroupJoin(
   cars, // первый набор данных
   m => m.Name, // общее свойство второго набора
   car  => car.Manufacturer, // общее свойство первого набора
   (m, crs ) => new  // результат выборки
   {
       Name = m.Name,
       Country = m.Country,
       Cars = crs.Select(c=>c.Model)
   });
 
// Вывод:
foreach (var team in result2)
{
   Console.WriteLine(team.Name + ":");
  
   foreach (string car in team.Cars)
       Console.WriteLine(car);
  
   Console.WriteLine();
}
```
Результат:
```csharp
Suzuki:
SX4
Grand Vitara
Jimny

Toyota:
Land Cruiser Prado
Camry

Volkswagen:
Polo
Passat
```
<br />
<b>Zip()</b><br />

Данный метод позволяет попарно соединять последовательности. 
<br />При необходимости можно на ходу выполнить дополнительные операции:

```csharp
//  объявляем две коллекции
var letters= new string[] { "A", "B", "C", "D", "E" };
var numbers= new int[] { 1, 2, 3 };
 
// проводим "упаковку" элементов, сопоставляя попарно
var q = letters.Zip(numbers, (l, n) => l + n.ToString());
 
// вывод
foreach (var s in q)
   Console.WriteLine(s);
// Вывод: A1 B2 C3
```