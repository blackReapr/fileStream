namespace Collections.Models;

internal class Employee
{
    private static int StaticId { get; set; }
    public int Id { get; }
    public string Name { get; set; }
    public int Salary { get; set; }

    public Employee(string name, int salary)
    {
        StaticId++;
        Id = StaticId;
        Name = name;
        Salary = salary;
    }
    public override string ToString() =>$"Name: {Name}, Id: {Id}, Salary: {Salary}";
}
