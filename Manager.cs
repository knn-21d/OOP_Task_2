using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp2
{
    internal class Manager : Employee
    {
        private int bonus;
        public override int Salary
        {
            get => salary + bonus;
            set => salary = value;
        }
        public int Bonus
        {
            get => bonus;
            set => bonus = value;
        }
        internal Manager(string name, int salary) : base(name, salary) {}
        internal Manager(string name, int salary, int bonus) : base(name, salary)
        {
            this.bonus = bonus;
        }
        internal Manager(string name, int salary, int day, int month, int year) : base(name, salary, day, month, year) {}
        internal Manager(string name, int salary, int bonus, int day, int month, int year) : base(name, salary, day, month, year)
        {
            this.bonus = bonus;
        }
        

        public override string ToString()
        {
            return $"Manager ID: {Id} Name: {Name} Salary: {Salary}({Bonus}) Experience: {Experience}";
        }
    }
}
