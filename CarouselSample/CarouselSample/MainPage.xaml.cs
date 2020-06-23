using CarouselSample.ViewModel;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace CarouselSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new CarouselViewModel();
        }
    }

    public class CarouselModel
    {
        public CarouselModel(string imageString)
        {
            Image = imageString;
        }
        private string _image;

        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
    }

    public class CarouselViewModel : BaseView
    {
        public CarouselViewModel()
        {
            var imgcollection = new List<CarouselModel>();
            imgcollection.Add(new CarouselModel("carousel1.jpg"));
            imgcollection.Add(new CarouselModel("carousel2.jpg"));
            imgcollection.Add(new CarouselModel("carousel3.jpg"));
            imgcollection.Add(new CarouselModel("carousel4.jpg"));
            imgcollection.Add(new CarouselModel("carousel5.jpg"));
            this.ImageCollection = imgcollection;
            AutoSlide();
        }

        private List<CarouselModel> imageCollection;
        public List<CarouselModel> ImageCollection
        {
            get { return imageCollection; }
            set
            {
                if (imageCollection == value) return;
                this.imageCollection = value;
                OnPropertyChanged(nameof(ImageCollection));
            }
        }

        private int _position;

        public int Position
        {
            get { return _position; }
            set
            {
                if (_position == value) return;
                _position = value;
                OnPropertyChanged(nameof(Position));
            }
        }
        public void AutoSlide()
        {
            Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
            {
                Position = (Position + 1) % ImageCollection.Count;
                return true;
            }));
        }
    }
}