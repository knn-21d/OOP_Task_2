using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            empDataGrid.ItemsSource = EmployeeStorage.JustEmployees;
            manDataGrid.ItemsSource = EmployeeStorage.ManagersList;
        }

        private Employee GetEmployeeFromContextClick (object sender)
        {
            var menuItem = (MenuItem)sender;
            var contextMenu = (ContextMenu)menuItem.Parent;
            var item = (DataGrid)contextMenu.PlacementTarget;
            return (Employee)item.SelectedCells[0].Item;
        }

        private void EditClick(object sender, EventArgs e)
        {
            Employee emp = GetEmployeeFromContextClick(sender);
            EditWindow edit = new EditWindow(emp);
            edit.ShowDialog();
            empDataGrid.Items.Refresh();
            manDataGrid.Items.Refresh();
        }

        private void ChangeSalary(object sender, EventArgs e)
        {
            Employee emp = GetEmployeeFromContextClick(sender);
            ChangeSalaryWindow change = new ChangeSalaryWindow(emp);
            change.ShowDialog();
            empDataGrid.Items.Refresh();
            manDataGrid.Items.Refresh();
        }

        private void ChangeSalaryGlobal(object sender, EventArgs e)
        {
            ChangeSalaryWindow change = new ChangeSalaryWindow();
            change.ShowDialog();
            empDataGrid.Items.Refresh();
            manDataGrid.Items.Refresh();
        }

        private void ChangeBonus(object sender, EventArgs e)
        {
            Manager man = (Manager)GetEmployeeFromContextClick(sender);
            EditBonusWindow change = new EditBonusWindow(man);
            change.ShowDialog();
            manDataGrid.Items.Refresh();
        }


        private void ManagerChecked(object sender, RoutedEventArgs e)
        {
            bonusLabel.Visibility = bonusLabel.IsVisible ? Visibility.Hidden : Visibility.Visible;
            bonusBox.Visibility = bonusBox.IsVisible ? Visibility.Hidden : Visibility.Visible;
            bonusBox.Text = Convert.ToBoolean(managerCheck.IsChecked) ? "0" : String.Empty;
            bonusBox.IsEnabled = !bonusBox.IsEnabled;
        }

        private byte ConstructorArgs() // возвращает численную сумму условий на множестве {0, 2, 3, 4, 6, 7}
        {
            bool x = Convert.ToBoolean(dateCheck.IsChecked); // ввод даты
            bool y = Convert.ToBoolean(managerCheck.IsChecked); // менеджер
            bool z = Int32.TryParse(bonusBox.Text, out int res); // есть ли премия
            
            return (byte)(Convert.ToInt32(x)*4 + Convert.ToInt32(y)*2 + Convert.ToInt32(z));
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            switch (ConstructorArgs()) // выбор конструктора через сумму условий
            {
                case 0: // 000
                    new Employee(nameBox.Text, Convert.ToInt32(salaryBox.Text));
                    break;
                case 2: // 010
                    new Manager(nameBox.Text, Convert.ToInt32(salaryBox.Text));
                    break;
                case 3: // 011
                    new Manager(nameBox.Text, Convert.ToInt32(salaryBox.Text), Convert.ToInt32(bonusBox.Text));
                    break;
                case 4: // 100
                    new Employee(nameBox.Text, Convert.ToInt32(salaryBox.Text), dateInput.DisplayDate.Day, dateInput.DisplayDate.Month, dateInput.DisplayDate.Year);
                    break;
                case 6: // 110
                    new Manager(nameBox.Text, Convert.ToInt32(salaryBox.Text), dateInput.DisplayDate.Day, dateInput.DisplayDate.Month, dateInput.DisplayDate.Year);
                    break;
                case 7: // 111
                    new Manager(nameBox.Text, Convert.ToInt32(salaryBox.Text), Convert.ToInt32(bonusBox.Text), dateInput.DisplayDate.Day, dateInput.DisplayDate.Month, dateInput.DisplayDate.Year);
                    break;
            }
            empDataGrid.Items.Refresh();
            manDataGrid.Items.Refresh();
            MessageBox.Show("Added successfully");
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        private void GetArray(object sender, RoutedEventArgs e)
        {
            ViewArrayWindow w = new ViewArrayWindow();
            w.ShowDialog();
        }
    }
}
