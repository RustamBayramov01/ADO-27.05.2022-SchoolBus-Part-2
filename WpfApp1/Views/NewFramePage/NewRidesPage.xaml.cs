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

namespace WpfApp1.Views.NewFramePage
{
    /// <summary>
    /// Interaction logic for NewRidesPage.xaml
    /// </summary>
    public partial class NewRidesPage : Page
    {

        SbDbContext context = SbDbContext.GetInstace();
        List<Ride> rides = new List<Ride>();


        public NewRidesPage()
        {
            InitializeComponent();
            DataContext = this;
            Refresh();
        }

        public void Refresh()
        {
            rides = context.Rides.ToList();
            myRidesView.ItemsSource = rides;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

            if (myRidesView.SelectedIndex >= 0)
            {
                foreach (var item in rides) { if (item.Id == (myRidesView.SelectedItem as Ride).Id) { context.Rides.Remove(item); } }

                context.SaveChanges();
                rides = context.Rides.ToList();
                myRidesView.ItemsSource = rides;
            }
            else
            {
                IndexWarning indexWarning = new();
                indexWarning.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                indexWarning.ShowDialog();
            }

        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSchool_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
