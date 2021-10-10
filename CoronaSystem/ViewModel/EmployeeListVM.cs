using Corona.BE;
using CoronaSystem.Commands;
using CoronaSystem.Model;
using CoronaSystem.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace CoronaSystem.ViewModel
{



    public class EmployeeListVM : DependencyObject, INotifyPropertyChanged
    {
        EmployeeListModel employeeListModel;
        //public ICommand searchCityCommand { get; set; }
        public ICommand toPdf { get; set; }
        EmployeeListUserControl myemployeeListUserControl;



        public EmployeeListVM(EmployeeListUserControl employeeListUserControl)
        {
            employeeListModel = new EmployeeListModel();
            myemployeeListUserControl = employeeListUserControl;
            toPdf = new PdfPrintCommand();
    
            AllEmployee = employeeListModel.getAllEmployee();
            

        }


        

            private List<Demand> _listOfDem;
        public List<Demand> ListOfDem
        {
            get { return _listOfDem; }
            set
            {
                _listOfDem = value;
                OnPropertyChanged("ListOfDem");
            }
        }

        private Employee _selectEmployee;
        public Employee SelectEmployee
        {
            get { return _selectEmployee; }
            set
            {
                _selectEmployee = value;
                OnPropertyChanged("SelectEmployee");
                getListDemandForEmp();

            }
        }
        private List<Employee> _allEmployee;
        public List<Employee> AllEmployee
        {
            get { return _allEmployee; }
            set
            {
                _allEmployee = value;
                OnPropertyChanged("AllEmployee");
            }
        }

        public void getListDemandForEmp()
        {
            List<Demand> dem = new List<Demand>();
            foreach(var a in employeeListModel.getAllDivision())
            {
                if (a.empId == SelectEmployee.id)
                {
                    foreach (var d in employeeListModel.getAllDemand())
                    {
                        if (a.codeDiv == d.codeDiv)
                        {
                            dem.Add(d);
                        }
                    }
                }
            }

            ListOfDem = dem;

        }

        
        public void FuncToPdf()
        {
            PrintDialog printDialog = new PrintDialog();
            if(printDialog.ShowDialog()==true)
            {
                printDialog.PrintVisual(myemployeeListUserControl.print, "myPrint");

            }

        }




        // INotifyPropertyChanged implementaion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }

    }
}

