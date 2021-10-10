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
    public class GraphPieVM : DependencyObject, INotifyPropertyChanged
    {
        GraphPieModel graphPieModel;
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

        private int _empIDGraph;
        public int EmpIDGraph
        {
            get { return _empIDGraph; }
            set
            {
                _empIDGraph = value;
                OnPropertyChanged("EmpIDGraph");
                if (value != 0 && SelectedTime != null)
                    EmpFunc(value, SelectedTime);
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
                if (value != null && EmpIDGraph != 0)
                    EmpFunc(EmpIDGraph, value);
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

        public GraphPieVM()
        {
            graphPieModel = new GraphPieModel();
            Time = new List<string>() { "today", "week", "month" };



            //List<Division> planList = new List<Division>(graphPieModel.getAllDivision());
            //DivisionGraph = new ObservableCollection<KeyValuePair<string, int>>();
            //DivisionGraph.Add(new KeyValuePair<string, int>("Plan", planList.Count));

            //List<Division> doneList = new List<Division>(graphPieModel.getAllDivision());
            //foreach (var d in graphPieModel.getAllDivision())
            //    if (d.divide)
            //        doneList.Add(d);
            //DivisionGraph.Add(new KeyValuePair<string, int>("Done", doneList.Count));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }

        public void EmpFunc(int empID, string time)
        {
            List<Division> doneList = new List<Division>();
            List<Division> doneList2 = new List<Division>();
            List<Division> doneList3 = new List<Division>();
            DivisionGraph = new ObservableCollection<KeyValuePair<string, int>>();
            switch (time)
            {
                case "today":
                    {
                        var queryDivision =
                                (from a in graphPieModel.getAllDivision()
                                 where a.empId == empID && a.dateDiv == DateTime.Today
                                 select a).ToList();
                        DivisionGraph.Add(new KeyValuePair<string, int>("ID " + empID, queryDivision.Count()));

                        foreach (var d in queryDivision)
                            if (d.divide)
                                doneList.Add(d);
                        DivisionGraph.Add(new KeyValuePair<string, int>("ID " + empID + " Done", doneList.Count));
                    }
                    break;
                case "week":
                    {
                        var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
                        var diff = DateTime.Today.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
                        if (diff < 0)
                            diff += 7;

                        DateTime StartDateOfWeek = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day - diff);

                        var queryDivision2 =
                              (from a in graphPieModel.getAllDivision()
                               where a.empId == empID && a.dateDiv >= StartDateOfWeek && a.dateDiv <= StartDateOfWeek.AddDays(7)
                               select a).ToList();
                        DivisionGraph.Add(new KeyValuePair<string, int>("ID " + empID, queryDivision2.Count()));

                        foreach (var d in queryDivision2)
                            if (d.divide)
                                doneList2.Add(d);
                        DivisionGraph.Add(new KeyValuePair<string, int>("ID " + empID + " Done", doneList2.Count));
                    }

                    break;
                case "month":
                    {
                        var queryDivision3 =
                              (from a in graphPieModel.getAllDivision()
                               where a.empId == empID && a.dateDiv.Month == DateTime.Today.Month
                               select a).ToList();
                        DivisionGraph.Add(new KeyValuePair<string, int>("ID " + empID, queryDivision3.Count()));
                        foreach (var d in queryDivision3)
                            if (d.divide)
                                doneList3.Add(d);
                        DivisionGraph.Add(new KeyValuePair<string, int>("ID " + empID + " Done", doneList3.Count));
                    }
                    break;
            }
        }
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
