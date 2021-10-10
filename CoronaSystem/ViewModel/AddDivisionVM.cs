using Corona.BE;
using CoronaSystem.Commands;
using CoronaSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CoronaSystem.ViewModel
{



    public class AddDivisionVM : DependencyObject, INotifyPropertyChanged
    {
        AddDivisionModel addDivisionModel;
        public ICommand addDivCommand { get; set; }
        
        private List<Division> _listOfDivision;
        public List<Division> ListOfDivision
        {
            get { return _listOfDivision; }
            set
            {
                _listOfDivision = value;
                OnPropertyChanged("ListOfDivision");
            }
        }

        private Division _oneDiv;
        public Division OneDiv
        {
            get { return _oneDiv; }
            set
            {
                _oneDiv = value ;
                OnPropertyChanged("OneDiv");
                //DivChoose = DivChoose+OneDiv.ToString();
                
            }
        }
        private string _divChoose;
        public string DivChoose
        {
            get { return _divChoose; }
            set
            {
                _divChoose = value;
                OnPropertyChanged("DivChoose");
            }
        }



        private List<Employee> _listOfEmployee;
        public List<Employee> ListOfEmployee
        {
            get { return _listOfEmployee; }
            set
            {
                _listOfEmployee = value;
                OnPropertyChanged("ListOfEmployee");
            }
        }

        private Employee _oneEmp;
        public Employee OneEmp
        {
            get { return _oneEmp; }
            set
            {
                _oneEmp = value;
                OnPropertyChanged("OneEmp");
                //DivChoose = DivChoose+ OneEmp.ToString();
            }
        }

        private DateTime _dateChoose;
        public DateTime DateChoose
        {
            get { return _dateChoose; }
            set
            {
                _dateChoose = value;
                OnPropertyChanged("DateChoose");
                //DivChoose = DivChoose + DateChoose.ToString();
            }
        }


        public AddDivisionVM()
        {
            addDivisionModel = new AddDivisionModel();
            List<Division> div = new List<Division>();
            foreach(var a in addDivisionModel.getAllDivision())
            {
                if (a.divide == false&&a.empId==0)
                    div.Add(a);
                    
            }
            ListOfDivision = div;

            ListOfEmployee = addDivisionModel.getAllEmployee();
            addDivCommand = new AddDivCommand();
            DateChoose = new DateTime();
            DateChoose = DateTime.Today;



            




        }
        public void updateFunc()
        {
            OneDiv.dateDiv = new DateTime();
            OneDiv.dateDiv = DateChoose;
            OneDiv.empId = OneEmp.id;
            DivChoose = DateChoose.ToString() + OneEmp.ToString() + OneDiv.ToString();
            addDivisionModel.updateDivision(OneDiv);
        }

        // INotifyPropertyChanged implementaion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }

    }

}
