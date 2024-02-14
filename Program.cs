using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


abstract class Employees:IComparable<Employees>
{
    public string name { get; set; }
    public int age { get; set; }
    public int salary { get; set; }
    public Employees(string name, int age, int salary)
    {
        this.name = name;
        this.age = age;
        this.salary = salary;
    }

    public int CompareTo(Employees? other)
    {
    
        return salary.CompareTo(other.salary);
    }
}
class SelfEmployedWorker : Employees
{
    public SelfEmployedWorker(string name, int age, int salary): base(name, age, salary)
    {

    }
  
}
class PermanentWorker : Employees
{
    public PermanentWorker(string name, int age, int salary) : base(name, age, salary)
    {

    }
 
}
class UnemployedEmployee: Employees
{
    public UnemployedEmployee(string name, int age, int salary) : base(name, age, salary)
    {

    }
   
}
class Iterator : IEnumerable<Employees>
{
    private List<Employees> employeesList = null;

    public Iterator()
    {
        employeesList = new List<Employees>();
    }
 
    public IEnumerator<Employees> GetEnumerator()
    {
        employeesList.Sort();
        foreach (var employee in employeesList)
        {
            yield return employee;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void AddEmployee(Employees employee)
    {
        employeesList.Add(employee);
    }
/*    public void SortedEmployees()
    {
        var sorting = employeesList.OrderByDescending(e => e.salary)
                                   .ThenByDescending(e => e.age);
        foreach (var employee in sorting)
        {
            Console.WriteLine($"Sorted by salary {employee.salary} and age {employee.age}");
        }
    }
*/

}

class Program
{
    static void Main()
    {
        Iterator iterator = new Iterator();
        iterator.AddEmployee(new SelfEmployedWorker("John", 19, 30000));
        iterator.AddEmployee(new PermanentWorker("Michael", 26, 120000));
        iterator.AddEmployee(new UnemployedEmployee("Lisa", 23, 20000));

        /*iterator.SortedEmployees();*/
        foreach (var employee in iterator)
        {
            Console.WriteLine($"{employee.name} - {employee.age} - Salary: {employee.salary}");
        }



    }
}
