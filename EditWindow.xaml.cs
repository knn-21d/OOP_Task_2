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
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        Employee currentObj;
        public EditWindow(Employee obj)
        {
            InitializeComponent();
            currentObj = obj;
            nameBox.Text = obj.Name;
            salaryBox.Text = obj.Salary.ToString();
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            bool edited = false;
            if (currentObj.Name != nameBox.Text)
            {
                currentObj.Name = nameBox.Text;
                edited = true;
            }
            if (currentObj.Salary != Convert.ToInt32(salaryBox.Text))
            {
                currentObj.Salary = Convert.ToInt32(salaryBox.Text);
                edited = true;
            }
            if (edited)
            {
                MessageBox.Show("Edited successfully");
                this.Close();
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            EmployeeStorage.Delete(currentObj);
            MessageBox.Show("Deleted successfully");
            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
