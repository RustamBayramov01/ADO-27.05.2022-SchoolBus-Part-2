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
    public class CreateRidesViewModel : DependencyObject
    {

        public Page SelectedPage
        {
            get { return (Page)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }
        public static readonly DependencyProperty MyPropertyProperty =
        DependencyProperty.Register("SelectedPage", typeof(Page), typeof(CreateRidesViewModel));




        public RelayCommand CreateRide { get; set; }


        public CreateRidesViewModel()
        {
            CreateRide = new RelayCommand(VCreate);

        }


        public void VCreate(object other)
        {
            SelectedPage = new NewCreateRidePage();
        }


    }
}
