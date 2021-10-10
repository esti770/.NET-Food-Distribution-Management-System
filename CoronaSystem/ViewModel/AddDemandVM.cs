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
using System.Windows.Input;

namespace CoronaSystem.ViewModel
{
    public class AddDemandVM : DependencyObject, INotifyPropertyChanged
    {
        // INotifyPropertyChanged implementaion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }

        AddDemandModel addDemandModel;
        public ICommand addDemandCommand { get; set; }
        Demand demand;
        AddDemandUserControl myaddDemandUserControl;



        public AddDemandVM(AddDemandUserControl addDemandUserControl)
        {
            addDemandModel = new AddDemandModel();
            addDemandCommand = new AddDemandCommand();
            myaddDemandUserControl = addDemandUserControl;



        }

        private bool _constDivide;
        public bool constDivide
        {
            get { return _constDivide; }
            set
            {
                _constDivide = value;
                OnPropertyChanged("constDivide");
            }
        }

        private bool _med;
        public bool Medicine
        {
            get { return _med; }
            set
            {
                _med = value;
                OnPropertyChanged("Medicine");
            }
        }

        private bool _foo;
        public bool Food
        {
            get { return _foo; }
            set
            {
                _foo = value;
                OnPropertyChanged("Food");
            }
        }
       

        private int _code;
        public int CodeDem
        {
            get { return _code; }
            set
            {
                _code = value;
                OnPropertyChanged("CodeDem");
            }
        }
        private string _city;
        public string CityAddress
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged("CityAddress");
            }
        }
        private string _streetAddress;
        public string StreetAddress
        {
            get { return _streetAddress; }
            set
            {
                _streetAddress = value;
                OnPropertyChanged("StreetAddress");
            }
        }

        private string _buildingAdress;
        public string BuildingAddress
        {
            get { return _buildingAdress; }
            set
            {
                _buildingAdress = value;
                OnPropertyChanged("BuildingAddress");
            }
        }
        private string _errorBox;
        public string ErrorBox
        {
            get { return _errorBox; }
            set
            {
                _errorBox = value;
                OnPropertyChanged("ErrorBox");
            }
        }


        public void addDemand()

        {
            typeDiv type = typeDiv.foodAndMedicine;



            if ( CityAddress == null || StreetAddress == null || BuildingAddress == null)
            {

                ErrorBox = "fill all values!";
            }
            else
            {

                if (Medicine == true)
                {
                    type = typeDiv.medicines;
                }
                if (Food == true)
                {
                    type = typeDiv.food;
                }
                if (Food == true && Medicine == true)
                {
                    type = typeDiv.foodAndMedicine;
                }

                demand = new Demand( CityAddress, StreetAddress, BuildingAddress, type, constDivide);
                bool b = addDemandModel.addDemand(demand);

                if (b == true)
                    ErrorBox = "fill it!";

            }


        }



    }
}
