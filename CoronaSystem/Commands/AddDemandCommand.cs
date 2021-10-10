﻿using CoronaSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoronaSystem.Commands
{
    class AddDemandCommand : ICommand
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
                ((AddDemandVM)parameter).addDemand();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
