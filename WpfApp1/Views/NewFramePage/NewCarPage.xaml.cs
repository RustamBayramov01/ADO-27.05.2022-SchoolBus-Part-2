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
using WpfApp1.Views.NewWarning;
using WpfApp1.Views.NewWarning.UpdateWindows;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for NewCarPage.xaml
    /// </summary>
    public partial class NewCarPage : Page
    {

        SbDbContext sbdbcontext = new SbDbContext();
        List<Car> cars = new List<Car>();

        public NewCarPage()
        {
            InitializeComponent();
            DataContext = this;
            Refresh();
        }


        public void Refresh()
        {
            cars = sbdbcontext.Cars.Include("Driver").ToList();
            myCarView.ItemsSource = cars;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

            if (myCarView.SelectedIndex >= 0)
            {
                var context = SbDbContext.GetInstace();
                var car = context.Cars.FirstOrDefault(x => x.Id.Equals((myCarView.SelectedItem as Car).Id));
                context.Cars.Remove(car);
                context.SaveChanges();
                cars = sbdbcontext.Cars.ToList();
                myCarView.ItemsSource = cars;
            }
            else
            {
                IndexWarning indexWarning = new();
                indexWarning.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                indexWarning.ShowDialog();
            }
        }

        private void BtnCarUpdate_Click(object sender, RoutedEventArgs e)
        {
            if(myCarView.SelectedIndex >= 0)
            {
                UpdateCar updateCar = new UpdateCar();

                updateCar.Name.Text = (myCarView.SelectedItem as Car).Title.ToString();
                updateCar.Number.Text = (myCarView.SelectedItem as Car).Number.ToString();
                updateCar.SeatCount.Text = (myCarView.SelectedItem as Car).SeatCount.ToString();

                updateCar.ShowDialog();

                if (updateCar.DialogResult == true)
                {

                    var other = new Car()
                    {
                        Id = (myCarView.SelectedItem as Car).Id,
                        Title = updateCar.Name.Text,
                        Number = updateCar.Number.Text,
                        SeatCount = int.Parse(updateCar.SeatCount.Text)
                    };

                    foreach (var item in cars)
                    {

                        if (item.Id == (myCarView.SelectedItem as Car).Id)
                        {
                            item.Title = updateCar.Name.Text;
                            item.Number = updateCar.Number.Text;
                            item.SeatCount = int.Parse(updateCar.SeatCount.Text);

                            sbdbcontext.Update(item);
                            sbdbcontext.Update(item.Driver);
                        }

                    }


                    sbdbcontext.SaveChanges();

                    cars = sbdbcontext.Cars.Include("Driver").ToList();
                    myCarView.ItemsSource = cars;

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
                foreach (var driver in myCarView.Items)
                {
                    if ((driver as Car).Title.Contains(Search.Text))
                    {
                        myCarView.SelectedItem = driver;
                    }
                }

            }
        }
    }
}
