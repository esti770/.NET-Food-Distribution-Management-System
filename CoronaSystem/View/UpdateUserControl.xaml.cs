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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CoronaSystem.ViewModel;

namespace CoronaSystem.View
{
    /// <summary>
    /// Interaction logic for UpdateUserControl.xaml
    /// </summary>
    public partial class UpdateUserControl : UserControl
    {
        UpdateEmployeeVM updateEmployeeVM { get; set; }
        public UpdateUserControl()
        {
            InitializeComponent();
            updateEmployeeVM = new UpdateEmployeeVM();
            this.DataContext = updateEmployeeVM;
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}