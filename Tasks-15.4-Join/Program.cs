// отделы
var departments = new List<Department>()
{
   new Department() {Id = 1, Name = "Программирование"},
   new Department() {Id = 2, Name = "Продажи"},
   new Department() {Id = 3, Name = "Администрирование"}
};

// люди
var employees = new List<Employee>()
{
   new Employee() { DepartmentId = 1, Name = "Инна", Id = 1},
   new Employee() { DepartmentId = 1, Name = "Андрей", Id = 2},
   new Employee() { DepartmentId = 2, Name = "Виктор ", Id = 3},
   new Employee() { DepartmentId = 3, Name = "Альберт ", Id = 4},
};

Console.WriteLine("Задание 15.4.1 start:");
MySolutionTask_15_4_1(departments, employees);
SFSolutionTask_15_4_1(departments, employees);
Console.WriteLine("Задание 15.4.1 finish.");

Console.WriteLine("\n\nЗадание 15.4.2 start:");
MySolutionTask_15_4_2(departments, employees);
Console.WriteLine("Задание 15.4.2 finish.");

Console.ReadKey();

/// Задание 15.4.1
/// Есть база данных с двумя коллекциями, одна содержит список отделов
/// Другая — список работающих в них людей
/// Соедините данные и выведите на экран, кто работает в каком отделе
static void MySolutionTask_15_4_1(List<Department> departments, List<Employee> employees)
{
    var result = employees.Join(departments,
    employee => employee.DepartmentId,
    dep => dep.Id,
    (employee, dep) =>
        new
        {
            DepartmentName = dep.Name,
            EmployeeName = employee.Name,
            EmployeeId = employee.Id
        });

    foreach (var department in result)
    {
        Console.WriteLine($"{department.DepartmentName} - " +
            $"{department.EmployeeName} (Id: {department.EmployeeId})");
    }
}

static void SFSolutionTask_15_4_1(List<Department> departments, List<Employee> employees)
{
    var employeeAndDep = from employee in employees
                         join dep in departments on employee.DepartmentId equals dep.Id //  соединяем коллекции по общему ключу
                         select new // выборка в новую сущность
                         {
                             EmployeeName = employee.Name,
                             DepartmentName = dep.Name
                         };

    foreach (var item in employeeAndDep)
        Console.WriteLine(item.EmployeeName + ", отдел: " + item.DepartmentName);
}

/// Задание 15.4.2
/// сгруппируйте сотрудников по отделам, выведя на экран последовательно сначала
/// название отдела, а затем список его сотрудников
static void MySolutionTask_15_4_2(List<Department> departments, List<Employee> employees)
{
    var result = departments.GroupJoin(
        employees, // первый набор данных
        d => d.Id, // общее свойство второго набора
        employee => employee.DepartmentId, // общее свойство первого набора
        (d, emp) => new // результат выборки
        {
            DepName = d.Name,
            Employees = emp.Select(e => e.Name)
        });

    // Перебор отделов
    foreach(var dep in result)
    {
        Console.WriteLine($"{dep.DepName}:");

        // Вывод сотрудников отдела
        foreach (var emp in dep.Employees)
            Console.WriteLine(" " + emp);
        Console.WriteLine();
    }
}

static void SFSolutionTask_15_4_2(List<Department> departments, List<Employee> employees)
{

}

internal class Department
{
    internal int Id { get; set; }
    internal string Name { get; set; }
}

internal class Employee
{
    internal int DepartmentId { get; set; }
    internal string Name { get; set; }
    internal int Id { get; set; }
}