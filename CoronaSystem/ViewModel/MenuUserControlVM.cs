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
   
    public class MenuUserControlVM : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChangedMenu;
        private void NotifyPropertyChanged(String propertyName)
        {
            var handler = PropertyChangedMenu;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChangedAddDiv;
        private void NotifyPropertyChanged1(String propertyName)
        {
            var handler = PropertyChangedAddDiv;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChangedAddEmployee;
        private void NotifyPropertyChanged2(String propertyName)
        {
            var handler = PropertyChangedAddEmployee;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }


        public event PropertyChangedEventHandler PropertyChangedDemandList;
        private void NotifyPropertyChanged3(String propertyName)
        {
            var handler = PropertyChangedDemandList;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }


        public event PropertyChangedEventHandler PropertyChangedEmployeeList;
        private void NotifyPropertyChanged4(String propertyName)
        {
            var handler = PropertyChangedEmployeeList;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChangedGraphPie;
        private void NotifyPropertyChanged5(String propertyName)
        {
            var handler = PropertyChangedGraphPie;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChangedGraph;
        private void NotifyPropertyChanged6(String propertyName)
        {
            var handler = PropertyChangedGraph;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChangedListDivision;
        private void NotifyPropertyChanged7(String propertyName)
        {
            var handler = PropertyChangedListDivision;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChangedMap;
        private void NotifyPropertyChanged8(String propertyName)
        {
            var handler = PropertyChangedMap;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChangedUpdateUser;
        private void NotifyPropertyChanged9(String propertyName)
        {
            var handler = PropertyChangedUpdateUser;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }


        public MenuModel menuModel { get; set; }
        
        public ICommand demandListButton { get; set; }
        public ICommand addEmployeeButton { get; set; }
        public ICommand EmployeeListButton { get; set; }
        public ICommand addDemandButton { get; set; }
        public ICommand ContinueCMD { get; set; }
        public ICommand GraphPieButton { get; set; }
        public ICommand GraphButton { get; set; }

        public ICommand ListDivisionButton { get; set; }
        public ICommand MapButton { get; set; }
        public ICommand UpdateUserButton { get; set; }




        public MenuUserControlVM()
        {
            menuModel = new MenuModel();
            ContinueCMD = new ContinueCMD();
            addDemandButton = new addDemandButtonCommand();
            addEmployeeButton = new addEmployeeButtonCommand();
            demandListButton = new demandListButtonCommand();
            EmployeeListButton = new EmployeeListButtonCommand();
            GraphPieButton = new GraphPieButtonCommand();
            GraphButton = new GraphButtonCommand();
            ListDivisionButton = new ListDivisionButtonCommand();
            MapButton = new MapButtonCommand();
            UpdateUserButton = new UpdateUserButtonCommand();




        }
        public void ContinueUserControl()
        {
            NotifyPropertyChanged("connected1");
        }
        public void OpenAddDemand()
        {
            NotifyPropertyChanged1("connected1");
        }
        public void OpenAddmployeeButton()
        {
            NotifyPropertyChanged2("connected1");
        }
        public void OpenDemandListButton()
        {
            NotifyPropertyChanged3("connected1");
        }
        public void OpenEmployeeListButton()
        {
            NotifyPropertyChanged4("connected1");
        }
        public void GraphPieOpen()
        {
            NotifyPropertyChanged5("connected1");
        }
        public void GraphOpen()
        {
            NotifyPropertyChanged6("connected1");
        }


        public void OpenListDivisionButton()
        {
            NotifyPropertyChanged7("connected1");
        }
        public void OpenMapButton()
        {
            NotifyPropertyChanged8("connected1");
        }
        public void OpenUpdateUserButton()
        {
            NotifyPropertyChanged9("connected1");
        }





        // INotifyPropertyChanged implementaion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }


    }
}
