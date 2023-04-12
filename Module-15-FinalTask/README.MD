<h1>Финальное задание</h1>
<br />
<b>Курс: C# от Skill Factory</b><br />
<b>Модуль: 15</b><br />
<b>Тема: LINQ ч.2</b><br />
<hr>
<br />
Есть список учеников школы с разбивкой по классам:
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
 
namespace Task1
{
   class Program
   {
       static void Main(string[] args)
       {
           var classes = new []
           {
               new Classroom { Students = {"Evgeniy", "Sergey", "Andrew"}, },
               new Classroom { Students = {"Anna", "Viktor", "Vladimir"}, },
               new Classroom { Students = {"Bulat", "Alex", "Galina"}, }
           };
           var allStudents = GetAllStudents(classes);
         
           Console.WriteLine(string.Join(" ", allStudents));
       }
 
       static string [] GetAllStudents( Classroom [] classes )
       {
           // ???
       }
      
       public class Classroom
       {
           public List<string> Students = new List<string>();
       }
   }
}
```
Напишите метод, который соберет всех учеников всех классов в один список, используя LINQ.