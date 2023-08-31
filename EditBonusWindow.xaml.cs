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
    /// Interaction logic for EditBonusWindow.xaml
    /// </summary>
    public partial class EditBonusWindow : Window
    {
        private Manager obj;

        internal EditBonusWindow(Manager currentObj)
        {
            obj = currentObj;
            InitializeComponent();
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            obj.Bonus = Convert.ToInt32(bonusBox.Text);
            MessageBox.Show("Bonus changed successfully");
            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
