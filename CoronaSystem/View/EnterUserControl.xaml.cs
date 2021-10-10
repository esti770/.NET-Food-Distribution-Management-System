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
    /// Interaction logic for MainUserControl.xaml
    /// </summary>
    public partial class enterUserControl : UserControl
    {
        public EnterUserControlVM enterUserControlVM { get; set; }
            
        public enterUserControl()
        {
            InitializeComponent();
            enterUserControlVM = new EnterUserControlVM(this);
            this.DataContext = enterUserControlVM;
        }
    }
}
