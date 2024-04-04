using Collections.Models;
using System.Text.Json;



string path = "C:\\Users\\mehem\\source\\repos\\Collections\\Collections\\Files\\database.json";

Department department = new();
List<Employee>? existingData = ReadData();
if (existingData != null) department.Employees = existingData;
bool isRunning = true;

while (isRunning)
{
    ShowMenu();
    int choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:
            Console.WriteLine("Employee Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Employee Salary: ");
            int salary = int.Parse(Console.ReadLine());
            Employee employee = new(name, salary);
            department.AddEmployee(employee);
            WriteData();
            break;
        case 2:
            Console.WriteLine("Enter employee Id: ");
            int id = int.Parse(Console.ReadLine());
            Employee? existingEmployee = department.Employees.Find(e => e.Id == id);
            if (existingEmployee != null) Console.WriteLine(existingEmployee.Name);
            else Console.WriteLine("Does not exist");
            break;
        case 3:
            Console.WriteLine("Enter employee Id: ");
            int idToRemove = int.Parse(Console.ReadLine());
            department.RemoveEmployee(idToRemove);
            WriteData();
            break;
        case 4:
            isRunning = false;
            break;
        default:
            Console.WriteLine("Wrong Input!");
            break;
    }
}

#region Show Menu
void ShowMenu()
{
    Console.WriteLine("1. Add Employee");
    Console.WriteLine("2. Get Employee");
    Console.WriteLine("3. Remove Employee");
    Console.WriteLine("4. Quit");
}
#endregion

#region Read data
List<Employee>? ReadData()
{
    using FileStream fileStream = new((path), FileMode.OpenOrCreate);
    using StreamReader reader = new StreamReader(fileStream);
    string rawData = reader.ReadToEnd();
    if (new FileInfo(path).Length != 0)
    {
        List<Employee>? employees = JsonSerializer.Deserialize<List<Employee>>(rawData);
        return employees;
    }
    return null;
}
#endregion

#region Write Data
void WriteData()
{
    //using FileStream fileStream = new(("C:\\Users\\mehem\\source\\repos\\Collections\\Collections\\Files\\database.json"), FileMode.OpenOrCreate);
    using StreamWriter writer = new StreamWriter(path, false);
    string data = JsonSerializer.Serialize(department.Employees);
    writer.Write(data);
}
#endregion