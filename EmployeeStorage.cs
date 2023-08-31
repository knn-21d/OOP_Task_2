using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Navigation;

namespace WpfApp2
{
    internal static class EmployeeStorage
    {
        internal static List<Employee> EmployeesList { get; }
        internal static List<Manager> ManagersList { get; }
        internal static List<Employee> JustEmployees { get; }
        internal static Employee[] Array { get => EmployeesList.ToArray(); }

        static EmployeeStorage() 
        {
            EmployeesList = new List<Employee>();
            ManagersList = new List<Manager>();
            JustEmployees = new List<Employee>();
        }

        internal static void Write(Employee emp)
        {
            EmployeesList.Add(emp);
            if (emp is Manager) ManagersList.Add((Manager)emp); else JustEmployees.Add(emp);
        }

        internal static void Delete(Employee emp)
        {
            EmployeesList.Remove(emp);
            if (emp is Manager) ManagersList.Remove((Manager)emp); else JustEmployees.Remove(emp);
        }
    }
}
