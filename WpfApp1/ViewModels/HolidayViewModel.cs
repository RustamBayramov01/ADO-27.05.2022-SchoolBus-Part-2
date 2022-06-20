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
    public class HolidayViewModel : DependencyObject
    {

        public Page SelectedPage
        {
            get { return (Page)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }
        public static readonly DependencyProperty MyPropertyProperty =
        DependencyProperty.Register("SelectedPage", typeof(Page), typeof(HolidayViewModel));




        public RelayCommand Holidays { get; set; }


        public HolidayViewModel()
        {
            Holidays = new RelayCommand(VHolidays);

        }


        public void VHolidays(object other)
        {
            SelectedPage = new NewHolidayPage();
        }


    }
}
