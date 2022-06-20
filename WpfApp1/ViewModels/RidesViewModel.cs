using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Command;
using WpfApp1.Views.NewFrameAddPage;
using WpfApp1.Views.NewFramePage;

namespace WpfApp1.ViewModels
{
    public class RidesViewModel : DependencyObject
    {
        public Page SelectedPage
        {
            get { return (Page)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }
        public static readonly DependencyProperty MyPropertyProperty =
        DependencyProperty.Register("SelectedPage", typeof(Page), typeof(RidesViewModel));



        public RelayCommand Rides { get; set; }


        public RidesViewModel()
        {
            Rides = new RelayCommand(VRides);
        }


        public void VRides(object other)
        {
            SelectedPage = new NewRidesPage();
        }

    }
}
