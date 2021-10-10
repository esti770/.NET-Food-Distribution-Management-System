using Corona.BE;
using CoronaSystem.Commands;
using CoronaSystem.Model;
using CoronaSystem.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CoronaSystem.ViewModel
{
    public class ListOfDivisionVM : DependencyObject, INotifyPropertyChanged
    {
        ListOfDivisionModel listOfDivisionModel;
        public List<Division> DivisionCheck { get; set; }

        public ICommand ClickDivision { get; set; }
        public CheckDivisionCommand checkDivision { get { return new CheckDivisionCommand(this); } set { checkDivision = value; } }


        private ObservableCollection<Division> _listOfDivision;
        public ObservableCollection<Division> ListOfDivision
        {
            get { return _listOfDivision; }
            set
            {
                _listOfDivision = value;
                OnPropertyChanged("ListOfDivision");
            }
        }

        public ListOfDivisionVM()
        {
            listOfDivisionModel = new ListOfDivisionModel();
            DivisionCheck = new List<Division>();

            ListOfDivision = new ObservableCollection<Division>();

            foreach (var a in listOfDivisionModel.getAllDivision())
            {
                if (a.divide == false)
                {
                    ListOfDivision.Add(a);
                }
            }
        }

        public void SelectedDivision(int codeDiv)
        {
            Division d = listOfDivisionModel.getDivision(codeDiv);
            if(d.divide==true)
            {
                d.divide = false;

            }
            else
            {
                d.divide = true;
            }
            listOfDivisionModel.updateDivision(d);

        }

        // INotifyPropertyChanged implementaion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}