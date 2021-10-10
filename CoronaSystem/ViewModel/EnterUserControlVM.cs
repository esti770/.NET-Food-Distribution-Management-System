using Corona.BE;
using CoronaSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CoronaSystem.Commands;
using CoronaSystem.View;
using System.ComponentModel;
using System.Windows.Controls;

namespace CoronaSystem.ViewModel
{
    public class EnterUserControlVM : DependencyObject, INotifyPropertyChanged
    {

        public EnterUserControlModel myModel { get; set; }

        public ICommand viPassword { get; set; }

        public EnterUserControlVM(enterUserControl enterUserControl)
        {
            myModel = new EnterUserControlModel();
            viPassword = new MyCommandViPassword();
        }


        // INotifyPropertyChanged implementaion
       public event PropertyChangedEventHandler PropertyChangedEnter;
        private void NotifyPropertyChanged(String propertyName)
        {
            var handler = PropertyChangedEnter;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        Boolean isConnected;
        public Boolean IsConnectedProperty
        {
            get { return isConnected; }
            set { isConnected = value; if (value == true) NotifyPropertyChanged("connected"); }
        }

        
        private string _passwordtextBox;

        public string PasswordtextBox
        {
            get { return _passwordtextBox; }
            set
            {
                _passwordtextBox = value;
                OnPropertyChanged("PasswordtextBox");
            }
        }

        private string _massagePassword;
        public string MassagePassword
        {
            get { return _massagePassword; }
            set
            {
                _massagePassword = value;
                OnPropertyChanged("MassagePassword");
            }
        }
        public void checkLogIn()
        {
            Admin admin = myModel.getAdmin();
            if (PasswordtextBox.ToString() == admin.code && PasswordtextBox.ToString()!=null)
            {
                IsConnectedProperty = true;
            }
            else
            {
                PasswordtextBox = "";
                MassagePassword = "please try again!";
            }


        }
        // INotifyPropertyChanged implementaion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}
