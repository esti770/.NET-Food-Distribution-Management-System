using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CoronaSystem.Model;
using Corona.BE;
using System.Windows.Input;
using CoronaSystem.Commands;
using System.Web.UI.WebControls;

namespace CoronaSystem.ViewModel
{
    class UpdateEmployeeVM : DependencyObject, INotifyPropertyChanged
    {
        UpdateEmployeeModel updateEmployeeModel;

        public ICommand updateEmployee { get; set; }
        public ICommand findEmployeeCommand { get; set; }

        public UpdateEmployeeVM()
        {
            updateEmployeeModel = new UpdateEmployeeModel();
            updateEmployee = new UpdateEmployeeCommand();
            findEmployeeCommand = new findEmployeeCommand();

        }

        #region attribute

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
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
        public string BuildingAdress
        {
            get { return _buildingAdress; }
            set
            {
                _buildingAdress = value;
                OnPropertyChanged("BuildingAdress");
            }
        }

        private string _mailAddress;
        public string MailAddress
        {
            get { return _mailAddress; }
            set
            {
                _mailAddress = value;
                OnPropertyChanged("MailAddress");
            }
        }

        private int _id;
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("ID");
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        private string _stateBox;
        public string StateBox
        {
            get { return _stateBox; }
            set
            {
                _stateBox = value;
                OnPropertyChanged("StateBox");
            }
        }

        private bool _IsEnabledProperty;
        public bool IsEnabledProperty
        {
            get { return _IsEnabledProperty; }
            set
            {
                _IsEnabledProperty = value;
                OnPropertyChanged("IsEnabledProperty");
            }
        }
        #endregion

        public void findEmp()
        {
            FirstName = "";
            LastName = "";
            PhoneNumber = "";
            MailAddress = "";
            CityAddress = "";
            StreetAddress = "";
            BuildingAdress = "";

            Employee emp =updateEmployeeModel.getEmployee(ID);
            if (emp != null)
            {
                IsEnabledProperty = true;
                FirstName = emp.firstName;
                LastName = emp.lastName;
                PhoneNumber = emp.numberPhone;
                MailAddress = emp.mail;
                CityAddress = emp.address.city;
                StreetAddress = emp.address.street;
                BuildingAdress = emp.address.numberOfBuilding;
            }
            else
            {
                StateBox = "there is no employee!";
            }


        }

          public void saveEmployee()
        {
            Employee employee = new Employee(ID, FirstName, LastName, PhoneNumber, MailAddress, CityAddress, StreetAddress, BuildingAdress);
            if (updateEmployeeModel.updateEmployee(employee))
                StateBox = "done update!";
            else
                StateBox = "can't update!";

            ID = 0;
            FirstName = "";
            LastName = "";
            PhoneNumber = "";
            MailAddress = "";
            CityAddress = "";
            StreetAddress = "";
            BuildingAdress = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}
