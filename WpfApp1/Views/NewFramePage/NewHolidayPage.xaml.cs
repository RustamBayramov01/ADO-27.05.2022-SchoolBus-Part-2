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

namespace WpfApp1.Views.NewFramePage
{
    /// <summary>
    /// Interaction logic for NewHolidayPage.xaml
    /// </summary>
    public partial class NewHolidayPage : Page
    {

        int other = 0;

        public NewHolidayPage()
        {
            InitializeComponent();
            DataContext = this;
            Refresh();
        }


        public void Refresh()
        {
            var context = SbDbContext.GetInstace();

            if (context.Holidays != null)
            {
                foreach (var item in context.Holidays)
                {
                    Calendar.SelectedDates.Add((DateTime.Parse(item.Date.ToString())));
                }
            }
            other = 1;
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (other == 1)
            {
                var context = SbDbContext.GetInstace();
                context.Holidays.Add(new Holiday() { Date = Calendar.SelectedDates.Last() });
                context.SaveChanges();
                var context1 = SbDbContext.GetInstace();
                foreach (var item in context1.Holidays) { Calendar.SelectedDates.Add((DateTime.Parse(item.Date.ToString()))); }


                NewCreatedRide newCreated = new();
                newCreated.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                newCreated.ShowDialog();
            }
        }
    }
}
