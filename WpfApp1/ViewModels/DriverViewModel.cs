using Microsoft.Azure.Documents;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using WpfApp1.Command;
using WpfApp1.Views;

namespace WpfApp1.ViewModels
{
    public class DriverViewModel : DependencyObject
    {

        public Page SelectedPage
        {
            get { return (Page)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }
        public static readonly DependencyProperty MyPropertyProperty =
        DependencyProperty.Register("SelectedPage", typeof(Page), typeof(DriverViewModel));

        public Page SelectedAddPage
        {
            get { return (Page)GetValue(other); }
            set { SetValue(other, value); }
        }
        public static readonly DependencyProperty other =
        DependencyProperty.Register("SelectedAddPage", typeof(Page), typeof(DriverViewModel));



        public RelayCommand Driver { get; set; }



        public DriverViewModel()
        {
            Driver = new RelayCommand(VDriver);
        }




        public void VDriver(object other)
        {

            SelectedPage = new NewDrivePage();
            SelectedAddPage = new NewDriverAddPage();
            
        }


    }
}
