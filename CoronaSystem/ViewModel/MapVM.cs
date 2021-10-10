using Corona.BE;
using CoronaSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CoronaSystem.ViewModel
{
    public class MapVM : DependencyObject, INotifyPropertyChanged
    {
        MapModel mapModel;
        private ImageSource _sourceImage;
        public ImageSource SourceImage
        {
            get { return _sourceImage; }
            set
            {
                _sourceImage = value;
                OnPropertyChanged("SourceImage");
            }
        }

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
                _oneDiv = value;
                OnPropertyChanged("OneDiv");
                myFunc();

            }
        }

        public MapVM()
        {

            mapModel = new MapModel();
            ListOfDivision = mapModel.getAllDivision();
            



            //List<Address> ad = new List<Address>();
            //ad.Add(new Address("Lod", "David", "14"));
            //ad.Add(new Address("jerusalem", "David", "14"));
            //string urlMap=mapModel.MapImageUrl(ad);
            //var converter = new ImageSourceConverter();

            //SourceImage = (ImageSource)converter.ConvertFromString(urlMap);


        }
        public void myFunc()
        {
            List<Demand> dem = mapModel.getAllDemand();
            List<Address> ad = new List<Address>();
            foreach(var a in dem)
            {
                if(a.codeDiv==OneDiv.codeDiv)
                {
                    ad.Add(a.address);
                }
            }
            string urlMap = mapModel.MapImageUrl(ad);
            var converter = new ImageSourceConverter();

            SourceImage = (ImageSource)converter.ConvertFromString(urlMap);

        }


        // INotifyPropertyChanged implementaion
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }

    }
}
