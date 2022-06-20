using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Command;
using WpfApp1.Views;

namespace WpfApp1.ViewModels
{

    

    public class CarViewModel : DependencyObject
    {

        public Page SelectedPage
        {
            get { return (Page)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }
        public static readonly DependencyProperty MyPropertyProperty =
        DependencyProperty.Register("SelectedPage", typeof(Page), typeof(CarViewModel));


        public Page SelectedAddPage
        {
            get { return (Page)GetValue(other); }
            set { SetValue(other, value); }
        }
        public static readonly DependencyProperty other =
        DependencyProperty.Register("SelectedAddPage", typeof(Page), typeof(CarViewModel));


        public RelayCommand BCar { get; set; }


        public CarViewModel()
        {
            BCar = new RelayCommand(VCar);
            
        }


        public void VCar(object other)
        {
            SelectedPage = new NewCarPage();
            SelectedAddPage = new NewCarAddPage();
        }
    }

    
}
