namespace Collections.Models;

class Department
{
    private static int StaticId { get;set; }
    public int Id { get; }
    public List<Employee> Employees { get; set; }

    public Department()
    {
        StaticId++;
        Id = StaticId;
        Employees = new List<Employee>();
    }
    
    public void AddEmployee(Employee employee) => Employees.Add(employee);
    public Employee? GetEmployeeById(int id) => Employees.Find(e => e.Id == id);
    public void RemoveEmployee(int id) => Employees = Employees.FindAll(e => e.Id != id);
}
