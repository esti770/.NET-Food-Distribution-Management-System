using CoronaSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoronaSystem.Commands
{
    public class CheckCommand : ICommand
    {
        public DemandListVM VM { get; set; }
        public CheckCommand(DemandListVM vm)
        {
            VM = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                int x;
                int.TryParse(parameter.ToString(), out x);
                VM.SelectedDemand(x);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

