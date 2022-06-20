using Microsoft.EntityFrameworkCore;
using Sclbus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Views.NewCreated;
using WpfApp1.Views.NewWarning;

namespace WpfApp1.Views.NewFramePage
{
    /// <summary>
    /// Interaction logic for NewCreateRidePage.xaml
    /// </summary>
    public partial class NewCreateRidePage : Page
    {

        SbDbContext context = SbDbContext.GetInstace();
        List<Driver> drivers = new List<Driver>();
        List<Student> students = new List<Student>();
        Ride Ride;
        int size = 0;

        public NewCreateRidePage()
        {
            InitializeComponent();
            DataContext = this;
            Refresh();
        }


        public void Refresh()
        {
            Ride = new Ride();
            drivers = context.Drivers.Include("Car").ToList();
            Car_OutlinedComboBoxx.ItemsSource = drivers;
            students = context.Students.Include("Parent").Include("Group").ToList();
            myCreateRideAdd.ItemsSource = students.Where(t => t.Ride == null);
        }




        private void BtnCreateRidesStudentAdd(object sender, RoutedEventArgs e)
        {
            if(Car_OutlinedComboBoxx.SelectedIndex >= 0)
            {
                if (myCreateRideAdd.SelectedIndex >= 0)
                {
                    if (int.Parse(StudentAttend.Text) < int.Parse(MaxSeat.Text))
                    {
                        var std = (myCreateRideAdd.SelectedItem as Student);
                        std.RideId = Ride.Id;
                        std.Ride = Ride;
                        context.Students.Update(std);
                        students = context.Students.Include("Parent").Include("Group").ToList();
                        myCreateRideAdd.ItemsSource = students.Where(t => t.Ride == null);
                        myCreateRideRemove.ItemsSource = students.Where(t => t.RideId == Ride.Id);
                        size++;
                        StudentAttend.Text = size.ToString();
                    }
                    else
                    {
                        FullWarning fullWarning = new();
                        fullWarning.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                        fullWarning.ShowDialog();
                    }
                }
                else
                {
                    IndexWarning indexWarning = new();
                    indexWarning.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    indexWarning.ShowDialog();
                }
            }
            else
            {
                SchoolBusWarning schoolBusWarning = new();
                schoolBusWarning.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                schoolBusWarning.ShowDialog();
            }
        }

        private void BtnCreateRidesStudentRemove(object sender, RoutedEventArgs e)
        {

            if (myCreateRideRemove.SelectedIndex >= 0)
            {
                var std = (myCreateRideRemove.SelectedItem as Student);
                std.Ride = null;
                std.RideId = null;
                context.Students.Update(std);
                students = context.Students.Include("Parent").Include("Group").ToList();
                myCreateRideAdd.ItemsSource = students.Where(t => t.Ride == null);
                myCreateRideRemove.ItemsSource = students.Where(t => t.RideId == Ride.Id);
                size--;
                StudentAttend.Text = size.ToString();
            }
            else
            {
                IndexWarning indexWarning = new();
                indexWarning.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                indexWarning.ShowDialog();
            }
            

        }

        private void SAVE_Click(object sender, RoutedEventArgs e)
        {
            if (size != 0)
            {
                Ride.Driver = (Car_OutlinedComboBoxx.SelectedItem as Driver);
                Ride.DriverId = (Car_OutlinedComboBoxx.SelectedItem as Driver).Id;
                context.Rides.Add(Ride);
                context.SaveChanges();

                FirstName.Text = null;
                CarName.Text = null;
                CarNumber.Text = null;
                StudentAttend.Text = null;
                MaxSeat.Text = null;
                Car_OutlinedComboBoxx.Text = null;

                myCreateRideRemove.ItemsSource = null;
                drivers.Clear();
                students.Clear();
                
                size = 0;

                NewCreatedRide newCreated = new();
                newCreated.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                newCreated.ShowDialog();

                Refresh(); 
            }
            else
            {
                SchoolBusWarning schoolBusWarning = new();
                schoolBusWarning.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                schoolBusWarning.ShowDialog();
            }
        }

        private void Car_OutlinedComboBoxx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Car_OutlinedComboBoxx.SelectedItem != null)
            {
                FirstName.Text = (Car_OutlinedComboBoxx.SelectedItem as Driver).ToString();
                CarName.Text = (Car_OutlinedComboBoxx.SelectedItem as Driver).Car?.Title;
                CarNumber.Text = (Car_OutlinedComboBoxx.SelectedItem as Driver).Car?.Number;
                MaxSeat.Text = (Car_OutlinedComboBoxx.SelectedItem as Driver).Car.SeatCount.ToString();
                StudentAttend.Text = Ride.Students.Count.ToString();
                Ride.Type = (Car_OutlinedComboBoxx.SelectedItem as Driver).ToString();

            }
        }
    }
}
