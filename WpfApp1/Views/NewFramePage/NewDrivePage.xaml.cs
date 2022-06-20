using Microsoft.Azure.Documents;
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
using WpfApp1.Command;
using WpfApp1.ViewModels;
using WpfApp1.Views;
using WpfApp1.Views.NewWarning;
using WpfApp1.Views.NewWarning.UpdateWindows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for NewDrivePage.xaml
    /// </summary>
    public partial class NewDrivePage : Page
    {


        SbDbContext sbdbcontext = SbDbContext.GetInstace();
        List<Driver> drivers = new List<Driver>();


        public NewDrivePage()
        {
            InitializeComponent();
            DataContext = this;
            Refresh();
            
        }

        

        public void Refresh()
        {
            drivers = sbdbcontext.Drivers.Include("Cars").ToList();
            myListView.ItemsSource = drivers;
        }
        


        private void BtnDelet(object sender, RoutedEventArgs e)
        {

            if(myListView.SelectedIndex >= 0)
            {
                var context = SbDbContext.GetInstace();
                var driver = context.Drivers.FirstOrDefault(x => x.Id.Equals((myListView.SelectedItem as Driver).Id));
                context.Drivers.Remove(driver);
                context.SaveChanges();
                drivers = sbdbcontext.Drivers.ToList();
                myListView.ItemsSource = drivers;
            }
            else
            {
                IndexWarning indexWarning = new();
                indexWarning.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                indexWarning.ShowDialog();
            }
        }




        private void BtnUpdatee(object sender, RoutedEventArgs e)
        {
            if(myListView.SelectedIndex >= 0)
            {
                var updateDriver = new UpdateDriver();

                updateDriver.FirstName.Text = (myListView.SelectedItem as Driver).FirstName;
                updateDriver.LastName.Text = (myListView.SelectedItem as Driver).LastName;
                updateDriver.Phone.Text = (myListView.SelectedItem as Driver).Phone;
                updateDriver.UserName.Text = (myListView.SelectedItem as Driver).UserName;
                updateDriver.Password.Text = (myListView.SelectedItem as Driver).Password;
                updateDriver.Licence.Text = (myListView.SelectedItem as Driver).License;

                foreach (var item in updateDriver.OutlinedComboBox.Items)
                {
                    if ((item as Car).Id == (myListView.SelectedItem as Driver).CarId)
                    {
                        updateDriver.OutlinedComboBox.SelectedItem = item;
                    }
                }

                updateDriver.ShowDialog();

                if (updateDriver.DialogResult == true)
                {
                    Car? car = (updateDriver.OutlinedComboBox.SelectedItem as Car);
                    Driver driver;

                    if (car != null)
                    {

                        var context = SbDbContext.GetInstace();
                        foreach (var item in drivers)
                        {
                            if ((myListView.SelectedItem as Driver).Id == item.Id)
                            {
                                item.FirstName = updateDriver.FirstName.Text;
                                item.LastName = updateDriver.LastName.Text;
                                item.Phone = updateDriver.Phone.Text;
                                item.UserName = updateDriver.UserName.Text;
                                item.Password = updateDriver.Password.Text;
                                item.License = updateDriver.Licence.Text;
                                item.CarId = car.Id;
                                item.Cars = new List<Car>() { car };
                                context.Drivers.Update(item);
                            }

                        }

                        sbdbcontext.Cars.Update(car);
                        context.SaveChanges();
                    }
                    else
                    {

                        driver = new Driver()
                        {
                            Id = (myListView.SelectedItem as Driver).Id,
                            FirstName = updateDriver.FirstName.Text,
                            LastName = updateDriver.LastName.Text,
                            Phone = updateDriver.Phone.Text,
                            UserName = updateDriver.UserName.Text,
                            Password = updateDriver.Password.Text,
                            License = updateDriver.Licence.Text
                        };

                        sbdbcontext.Drivers.Update(driver);
                    }

                    sbdbcontext.SaveChanges();


                    drivers = sbdbcontext.Drivers.Include("Cars").ToList();
                    myListView.ItemsSource = drivers;
                }
               
            }
            else
            {
                IndexWarning indexWarning = new();
                indexWarning.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                indexWarning.ShowDialog();
            }



        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                foreach (var driver in myListView.Items)
                {
                    if ((driver as Driver).FirstName.Contains(Search.Text))
                    {
                        myListView.SelectedItem = driver;
                    }
                }

            }
        }
    }
}
