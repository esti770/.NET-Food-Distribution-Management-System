using CoronaSystem.ViewModel;
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

namespace CoronaSystem.View
{
    /// <summary>
    /// Interaction logic for MenuWindoww.xaml
    /// </summary>
    public partial class MenuUserControl : UserControl
    {
        public MenuUserControlVM menuUserControlVM { get; set; }

        public MenuUserControl()
        {
            InitializeComponent();
            menuUserControlVM = new MenuUserControlVM();
            this.DataContext = menuUserControlVM;
        }

    }
    }

