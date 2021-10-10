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
    public class DemandListVM : DependencyObject, INotifyPropertyChanged
    {
        DemandListModel demandListModel;
        public List<Demand> DemandsCheck { get; set; }
        
        public ICommand ClickDemand { get; set; }
        public ICommand CheckCity { get; set; }
        public CheckCommand CheckDemand { get { return new CheckCommand(this); } set { CheckDemand = value; } }
        

        private int _numDiv;
        public int NumDiv
        {
            get { return _numDiv; }
            set
            {
                _numDiv = value;
                OnPropertyChanged("NumDiv");
            }
        }
        private string _cityDiv;
        public string CityDiv
        {
            get { return _cityDiv; }
            set
            {
                _cityDiv = value;
                OnPropertyChanged("CityDiv");
            }
        }

        

        bool _constDivide;
        public bool constDivide
        {
            get { return _constDivide; }
            set
            {
                _constDivide = value;
                OnPropertyChanged("constDivide");
            }
        }

        private ObservableCollection<Demand> _listOfDemand;
        public ObservableCollection<Demand> ListOfDemand
        {
            get { return _listOfDemand; }
            set
            {
                _listOfDemand = value;
                OnPropertyChanged("ListOfDemand");
            }
        }

       
        
        private int _codeDem;
        public int codeDem
        {
            get { return _codeDem; }
            set
            {
                _codeDem = value;
                OnPropertyChanged("codeDem");
            }
        }


      




        public DemandListVM()
        {
           
            demandListModel = new DemandListModel();
                DemandsCheck = new List<Demand>();


            ClickDemand = new DemandCheckedCommand();//command
            CheckCity = new CheckCityCommand();

            ListOfDemand = new ObservableCollection<Demand>();
            foreach (var a in demandListModel.getAllDemand())
            {

                if (a.constDivide )
                {
                    DemandsCheck.Add(a);

                }
              
                
                ListOfDemand.Add(a);
                
            }



        }
        
        public void CheckCityFunc()
        {
            ListOfDemand= new ObservableCollection<Demand>();
            foreach (var a in demandListModel.getAllDemand())
            {

                if (a.constDivide)
                {
                    DemandsCheck.Add(a);

                }

                if (a.address.city == CityDiv)
                {
                    ListOfDemand.Add(a);
                }

            }
        }
        public void SelectedDemand(int codeDem)
        {




            bool b = false;
            foreach (var d in DemandsCheck)
            {
                if (codeDem == d.codeDem)
                {
                    b = true;
                }
            }
            if (b == false)

            {
                DemandsCheck.Add(demandListModel.getDemand(codeDem));
            }
            else
            {
                DemandsCheck.Remove(demandListModel.getDemand(codeDem));
            }
        }

        public void end()
        {
            



            demandListModel.createDivision(NumDiv, DemandsCheck);




        }
        // INotifyPropertyChanged implementaion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }

    }
}


                        