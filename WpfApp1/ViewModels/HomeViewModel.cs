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
    public class HomeViewModel : DependencyObject
    {

        public Page SelectedPage
        {
            get { return (Page)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }
        public static readonly DependencyProperty MyPropertyProperty =
        DependencyProperty.Register("SelectedPage", typeof(Page), typeof(HomeViewModel));


        public RelayCommand Home { get; set; }


        public HomeViewModel()
        {
            Home = new RelayCommand(VHome);

        }


        public void VHome(object other)
        {
            SelectedPage = new NewHomePage();
        }


    }
}
