using CoronaSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoronaSystem.Commands
{
  
        public class UpdateUserButtonCommand : ICommand


        {
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                try
                {
                    ((MenuUserControlVM)parameter).OpenUpdateUserButton();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

        }
    }



