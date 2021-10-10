using Corona.BE;
using CoronaSystem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CoronaSystem.ViewModel
{
    public class GraphVM : DependencyObject, INotifyPropertyChanged
    {
        public GraphModel graphModel;
        private string _key;
        public string Key
        {
            get { return _key; }
            set
            {
                _key = value;
                OnPropertyChanged("Key");
            }
        }
        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged("Value");
            }
        }

        private List<string> _time;
        public List<string> Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged("Time");
            }
        }

        private ObservableCollection<KeyValuePair<string, int>> _divisionGraph;
        public ObservableCollection<KeyValuePair<string, int>> DivisionGraph
        {
            get { return _divisionGraph; }
            set
            {
                _divisionGraph = value;
                OnPropertyChanged("DivisionGraph");
            }
        }

        private string _selectedTime;
        public string SelectedTime
        {
            get { return _selectedTime; }
            set
            {
                _selectedTime = value;
                OnPropertyChanged("SelectedTime");
                func(value);
            }
        }

        public GraphVM()
        {
            //    (int empId)
            //{
            //        return myDal.getDivisionByPredicate((Division x) => x.empId == empId);
            //    }
            Time = new List<string>() { "today", "week", "month" };
            graphModel = new GraphModel();

        }

        public void func(string time)
        {
            List<Division> doneList = new List<Division>(graphModel.getAllDivision());
            DivisionGraph = new ObservableCollection<KeyValuePair<string, int>>();

            switch (time)
            {
                case "today":

                    var queryDivision =
                            from a in graphModel.getAllDivision()
                            where a.dateDiv == DateTime.Today
                            group a by a.empId into newGroup
                            select newGroup;
                    foreach (var s in queryDivision)
                    {
                        DivisionGraph.Add(new KeyValuePair<string, int>("ID " + s.Key, s.Count()));
                        foreach (var d in s)
                            if (d.divide)
                                doneList.Add(d);
                        DivisionGraph.Add(new KeyValuePair<string, int>("ID " + s.Key + " Done", doneList.Count));
                    }
                    break;
                case "week":
                    var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
                    var diff = DateTime.Today.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
                    if (diff < 0)
                        diff += 7;

                    DateTime StartDateOfWeek = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day - diff);

                    var queryDivision2 =
                          from a in graphModel.getAllDivision()
                          where a.dateDiv >= StartDateOfWeek && a.dateDiv <= StartDateOfWeek.AddDays(7)
                          group a by a.empId into newGroup
                          select newGroup;
                    foreach (var s in queryDivision2)
                    {
                        DivisionGraph.Add(new KeyValuePair<string, int>("ID " + s.Key, s.Count()));
                        foreach (var d in s)
                            if (d.divide)
                                doneList.Add(d);
                        DivisionGraph.Add(new KeyValuePair<string, int>("ID " + s.Key + " Done", doneList.Count));
                    }

                    break;
                case "month":
                    var queryDivision3 =
                          from a in graphModel.getAllDivision()
                          where a.dateDiv.Month == DateTime.Today.Month
                          group a by a.empId into newGroup
                          select newGroup;
                    foreach (var s in queryDivision3)
                    {
                        DivisionGraph.Add(new KeyValuePair<string, int>("ID " + s.Key, s.Count()));
                        foreach (var d in s)
                            if (d.divide)
                                doneList.Add(d);
                        DivisionGraph.Add(new KeyValuePair<string, int>("ID " + s.Key + " Done", doneList.Count));
                    }
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }

}

/*private void LoadBarChartData()    
{    
    ((BarSeries)mcChart.Series[0]).ItemsSource =    
        new KeyValuePair<string, int>[]{    
            new KeyValuePair<string, int>("Project Manager", 12),    
            new KeyValuePair<string, int>("CEO", 25),    
            new KeyValuePair<string, int>("Software Engg.", 5),    
            new KeyValuePair<string, int>("Team Leader", 6),    
            new KeyValuePair<string, int>("Project Leader", 10),    
            new KeyValuePair<string, int>("Developer", 4) };    
}   */
// xmlns:DVC="System.Window.Controls.DataVisualization"
