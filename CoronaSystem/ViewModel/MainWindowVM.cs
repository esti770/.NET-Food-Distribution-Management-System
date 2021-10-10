using CoronaSystem.Commands;
using CoronaSystem.Model;
using CoronaSystem.View;
using CoronaSystem.View.add;
using CoronaSystem.ViewModel;
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
    class MainWindowVM:DependencyObject
    {
        MainWindowModel mainWindowModel;
        public static readonly DependencyProperty _UserControl = DependencyProperty.Register("UserControlProperty", typeof(UserControl), typeof(MainWindowVM));
        public UserControl UserControlProperty
        {
            get { return (UserControl)GetValue(_UserControl); }
            set { SetValue(_UserControl, value); }      
        }

        private void initLogIn()
        {
            UserControlProperty = new enterUserControl(); //EmployeeListUserControl();
            (UserControlProperty as enterUserControl).enterUserControlVM.PropertyChangedEnter += isLogedInFunc;
         
           // (UserControlProperty as MenuUserControl).menuUserControlVM.PropertyChangedMenu += isLogedInFunc1;

        }
        public ICommand back { get; set; }
        
        public MainWindowVM()
        {
            mainWindowModel = new MainWindowModel();
            back = new backCommand();
            initLogIn();
        }
        

        private void isLogedInFunc(object sender, PropertyChangedEventArgs e)
        {
            
            UserControlProperty = new MenuUserControl();
            (UserControlProperty as MenuUserControl).menuUserControlVM.PropertyChangedMenu += isLogedInFunc1;
            (UserControlProperty as MenuUserControl).menuUserControlVM.PropertyChangedAddDiv += isLogedInFunc2;
            (UserControlProperty as MenuUserControl).menuUserControlVM.PropertyChangedAddEmployee += isLogedInFunc3;
            (UserControlProperty as MenuUserControl).menuUserControlVM.PropertyChangedDemandList += isLogedInFunc4;
            (UserControlProperty as MenuUserControl).menuUserControlVM.PropertyChangedEmployeeList += isLogedInFunc5;
            (UserControlProperty as MenuUserControl).menuUserControlVM.PropertyChangedGraphPie += isLogedInFunc6;
            (UserControlProperty as MenuUserControl).menuUserControlVM.PropertyChangedGraph += isLogedInFunc7;

            (UserControlProperty as MenuUserControl).menuUserControlVM.PropertyChangedListDivision += isLogedInFunc8;
            (UserControlProperty as MenuUserControl).menuUserControlVM.PropertyChangedMap += isLogedInFunc9;
            (UserControlProperty as MenuUserControl).menuUserControlVM.PropertyChangedUpdateUser += isLogedInFunc10;



        }
        private void isLogedInFunc1(object sender, PropertyChangedEventArgs e)
        {

            UserControlProperty = new AddDemandUserControl();
        }
        private void isLogedInFunc2(object sender, PropertyChangedEventArgs e)
        {

            UserControlProperty = new AddDivUserControl();
        }
        private void isLogedInFunc3(object sender, PropertyChangedEventArgs e)
        {

            UserControlProperty = new AddEmployeeUserControl();
        }
        private void isLogedInFunc4(object sender, PropertyChangedEventArgs e)
        {

            UserControlProperty = new DemandListUserControl();
        }
        private void isLogedInFunc5(object sender, PropertyChangedEventArgs e)
        {

            UserControlProperty = new EmployeeListUserControl();
        }

        private void isLogedInFunc6(object sender, PropertyChangedEventArgs e)
        {

            UserControlProperty = new GraphPieUserControl();
        }
        private void isLogedInFunc7(object sender, PropertyChangedEventArgs e)
        {

            UserControlProperty = new GraphUserControl();
        }

        private void isLogedInFunc8(object sender, PropertyChangedEventArgs e)
        {

            UserControlProperty = new ListDivisionUserControl();
        }

        private void isLogedInFunc9(object sender, PropertyChangedEventArgs e)
        {

            UserControlProperty = new MapUserControl();
        }
        private void isLogedInFunc10(object sender, PropertyChangedEventArgs e)
        {

            UserControlProperty = new UpdateUserControl();
        }
        public void backFunc()
        {

            UserControlProperty = new MenuUserControl();
            (UserControlProperty as MenuUserControl).menuUserControlVM.PropertyChangedMenu += isLogedInFunc1;
            (UserControlProperty as MenuUserControl).menuUserControlVM.PropertyChangedAddDiv += isLogedInFunc2;
            (UserControlProperty as MenuUserControl).menuUserControlVM.PropertyChangedAddEmployee += isLogedInFunc3;
            (UserControlProperty as MenuUserControl).menuUserControlVM.PropertyChangedDemandList += isLogedInFunc4;
            (UserControlProperty as MenuUserControl).menuUserControlVM.PropertyChangedEmployeeList += isLogedInFunc5;
            (UserControlProperty as MenuUserControl).menuUserControlVM.PropertyChangedGraphPie += isLogedInFunc6;
            (UserControlProperty as MenuUserControl).menuUserControlVM.PropertyChangedGraph += isLogedInFunc7;

            (UserControlProperty as MenuUserControl).menuUserControlVM.PropertyChangedListDivision += isLogedInFunc8;
            (UserControlProperty as MenuUserControl).menuUserControlVM.PropertyChangedMap += isLogedInFunc9;
            (UserControlProperty as MenuUserControl).menuUserControlVM.PropertyChangedUpdateUser += isLogedInFunc10;


        }

        // INotifyPropertyChanged implementaion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }


}