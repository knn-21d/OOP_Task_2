using System;
using System.Windows.Media;
using WpfApp2;

public class Employee
{
    protected string name;
	protected int salary;
    protected DateTime date;
	private int id;
	private static int nextId;

	static Employee()
	{
		nextId = EmployeeStorage.EmployeesList.Count + 1;
	}

	public Employee()
	{
		this.name = String.Empty;
		this.salary = 0;
		this.date = DateTime.Now;
		this.id = NextId;
        EmployeeStorage.Write(this);
    }

	public Employee(string name, int salary, int day, int month, int year)
	{
		this.name = name;
		this.salary = salary;
		this.date = new DateTime(year, month, day);
		this.id = NextId;
		EmployeeStorage.Write(this);
	}

    public Employee(string name, int salary)
    {
        this.name = name;
        this.salary = salary;
        this.date = DateTime.Now;
        this.id = NextId;
        EmployeeStorage.Write(this);
    }
	
    public string Name
	{
		get => name;
		set => name = value;
	}
	public virtual int Salary
	{
		get => salary;
		set => salary = value; 
	}
    public int Experience
    {
        get => DateTime.Now.Year - this.date.Year;
    }
	public int Id
	{
		get => id;
		set => id = value;
	}
	private static int NextId
	{
		get => nextId++;
	}

    public void ChangeSalary (int rate)
	{
		double _rate = rate;
		double _salary = salary;
		salary = Convert.ToInt32(_salary * (1.00 + _rate/100.00));
	}

	public static void ChangeSalaryGlobal (int rate)
	{
		EmployeeStorage.EmployeesList.ForEach(e =>
		{
			double _rate = rate;
			double _salary = e.salary;
			e.salary = Convert.ToInt32(_salary * (1.00 + _rate / 100.00));
		});
	}

	public override string ToString()
	{
        return $"Employee ID: {Id} Name: {Name} Salary: {Salary} Experience: {Experience}";
    }
}
