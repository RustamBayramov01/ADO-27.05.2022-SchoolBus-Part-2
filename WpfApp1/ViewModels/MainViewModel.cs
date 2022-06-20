using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Command;
using WpfApp1.Views.NewFramePage;

namespace WpfApp1.ViewModels
{
    public class MainViewModel : DependencyObject
    {
        public RelayCommand Home { get; set; }
        public RelayCommand CreateRide { get; set; }
        public RelayCommand Rides { get; set; }
        public RelayCommand Group { get; set; }
        public RelayCommand Student { get; set; }
        public RelayCommand Parents { get; set; }
        public RelayCommand Car { get; set; }
        public RelayCommand Holidays { get; set; }
        public RelayCommand Exit { get; set; }

        public MainViewModel()
        {
            Home = new RelayCommand(VHome);
            CreateRide = new RelayCommand(VCreate);
            Rides = new RelayCommand(VRides);
            Group = new RelayCommand(VClass);
            Student = new RelayCommand(VStudent);
            Parents = new RelayCommand(VParetns);
            Car = new RelayCommand(VCar);
            Holidays = new RelayCommand(VHolidays);
            Exit = new RelayCommand(VExit);
        }

        public void VHome(object other) { }
        public void VCreate(object other) { }
        public void VRides(object other) { }
        public void VClass(object other) { }
        public void VStudent(object other) { }
        public void VParetns(object other) { }
        public void VCar(object other) { }
        public void VHolidays(object other) { }
        public void VExit(object other) { }

    }
}
