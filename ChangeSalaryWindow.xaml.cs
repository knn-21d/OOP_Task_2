using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ChangeSalaryWindow : Window
    {
        Employee? currentObj;
        public ChangeSalaryWindow(Employee obj)
        {
            InitializeComponent();
            currentObj = obj;
        }
        public ChangeSalaryWindow()
        {
            InitializeComponent();
        }


        private void Confirm(object sender, RoutedEventArgs e)
        {
            if(currentObj is not null)
            {
                currentObj.ChangeSalary(Convert.ToInt32(rateBox.Text));
            }
            else
            {
                Employee.ChangeSalaryGlobal(Convert.ToInt32(rateBox.Text));
            }
            MessageBox.Show("Salary changed successfully");
            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
