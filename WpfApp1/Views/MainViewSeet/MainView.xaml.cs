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
using System.Windows.Threading;
using WpfApp1.ViewModels;
using WpfApp1.Views;
using WpfApp1.Views.NewFramePage;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DispatcherTimer dispatcherTimer1 = new DispatcherTimer();
        DispatcherTimer dispatcherTimer2 = new DispatcherTimer();
        DispatcherTimer dispatcherTimer3 = new DispatcherTimer();
        DispatcherTimer dispatcherTimer4 = new DispatcherTimer();

        int incerement = 199;
        int incerementt = 479;
        bool CatagoriBorderVerif = true;
        bool CatagoriBorderVerif2 = false;
         

        public MainWindow()
        {
            InitializeComponent();
            BorderSelection.Margin = new Thickness(185, 0, 5, 0);
            AddBorder.Margin = new Thickness(0, 0, 500, 0);
            AddNewDriver.Visibility = Visibility.Hidden;
             
            DataContext = new MainViewModel();

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try { DragMove(); }
            catch (Exception) { throw; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CatagoriBorderVerif == false)
            {
                dispatcherTimer1.Interval = TimeSpan.FromSeconds(0.0005);
                dispatcherTimer1.Tick += MarginnIncer;
                dispatcherTimer1.Start();

            }
            else
            {

                dispatcherTimer2.Interval = TimeSpan.FromSeconds(0.0005);
                dispatcherTimer2.Tick += MarginnDecr;
                dispatcherTimer2.Start();

            }
        }


        public void MarginnIncer(object sender, EventArgs e)
        {
            incerement++;
            if (incerement != 200) { BorderSelection.Margin = new Thickness(incerement, 0, 0, 0); }
            else
            {
                dispatcherTimer1.Stop();
                CatagoriBorderVerif = true;
                back.Source = new BitmapImage(new Uri("/Views/Icon/arrow.png", UriKind.Relative));
                BorderSelection.Margin = new Thickness(180, 0, 5, 0);
            }
        }

        public void MarginnDecr(object sender, EventArgs e)
        {
            incerement--;
            if (incerement != 0) { BorderSelection.Margin = new Thickness(incerement, 0, 0, 0); }
            else
            {
                dispatcherTimer2.Stop();
                CatagoriBorderVerif = false;
                back.Source = new BitmapImage(new Uri("/Views/Icon/burger-bar.png", UriKind.Relative));
                BorderSelection.Margin = new Thickness(0, 0, 5, 0);


            }
        }



        public void MarginnIncer2(object sender, EventArgs e)
        {
            incerementt++;
            if (incerementt != 480) { AddBorder.Margin = new Thickness(0, 0, incerementt, 0); }
            else
            {
                dispatcherTimer3.Stop();
                CatagoriBorderVerif2 = true;
                add.Source = new BitmapImage(new Uri("/Views/Icon/addition.png", UriKind.Relative));
            }
        }

        public void MarginnDecr2(object sender, EventArgs e)
        {
            incerementt--;
            if (incerementt != 0) { AddBorder.Margin = new Thickness(0, 0, incerementt, 0); }
            else
            {
                dispatcherTimer4.Stop();
                CatagoriBorderVerif2 = false;
                add.Source = new BitmapImage(new Uri("/Views/Icon/back-button.png", UriKind.Relative));
            }
        }


   

        private void DriverAddButton(object sender, RoutedEventArgs e)
        {
            //AddBorder.Margin = new Thickness(0, 0, 0, 0); 480
            if (CatagoriBorderVerif2 == false)
            {
                dispatcherTimer3.Interval = TimeSpan.FromSeconds(0.0005);
                dispatcherTimer3.Tick += MarginnIncer2;
                dispatcherTimer3.Start();

            }
            else
            {

                dispatcherTimer4.Interval = TimeSpan.FromSeconds(0.0005);
                dispatcherTimer4.Tick += MarginnDecr2;
                dispatcherTimer4.Start();

            }
        }

   

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            dispatcherTimer4.Interval = TimeSpan.FromSeconds(0.0001);
            dispatcherTimer4.Tick += MarginnDecr2;
            dispatcherTimer4.Start();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            if (CatagoriBorderVerif2 == false)
            {
                dispatcherTimer3.Interval = TimeSpan.FromSeconds(0.0005);
                dispatcherTimer3.Tick += MarginnIncer2;
                dispatcherTimer3.Start();

            }
            else
            {

                dispatcherTimer4.Interval = TimeSpan.FromSeconds(0.0005);
                dispatcherTimer4.Tick += MarginnDecr2;
                dispatcherTimer4.Start();

            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NewCar(object sender, RoutedEventArgs e)
        {
            AddNewDriver.Visibility = Visibility.Visible;
            DataContext = new CarViewModel();
            KeyName.Text = "NEW CAR";

            ColumnDefinitionn.Width = new GridLength(80);

        }

        private void NewDrive(object sender, RoutedEventArgs e)
        {
            AddNewDriver.Visibility = Visibility.Visible;
            DataContext = new DriverViewModel();
            KeyName.Text = "NEW DRIVER";

            ColumnDefinitionn.Width = new GridLength(80);

        }

        private void NewParent(object sender, RoutedEventArgs e)
        {
            AddNewDriver.Visibility = Visibility.Visible;
            DataContext = new ParentViewModel();
            KeyName.Text = "NEW PARENT";

            ColumnDefinitionn.Width = new GridLength(80);

        }

        private void NewStudent(object sender, RoutedEventArgs e)
        {
            AddNewDriver.Visibility = Visibility.Visible;
            DataContext = new StudentViewModel();
            KeyName.Text = "NEW STUDENT";

            ColumnDefinitionn.Width = new GridLength(80);

        }

        private void NewGroup(object sender, RoutedEventArgs e)
        {
            AddNewDriver.Visibility = Visibility.Visible;
            DataContext = new GroupViewModel();
            KeyName.Text = "NEW CLASS";

            ColumnDefinitionn.Width = new GridLength(80);

        }

        private void NewRides(object sender, RoutedEventArgs e)
        {
            AddNewDriver.Visibility = Visibility.Hidden;
            DataContext = new RidesViewModel();

            ColumnDefinitionn.Width = new GridLength(80);

            if (CatagoriBorderVerif2 == false) { DriverAddButton(sender, e); }

        }

        private void NewCrateides(object sender, RoutedEventArgs e)
        {

            AddNewDriver.Visibility = Visibility.Hidden;
            DataContext = new CreateRidesViewModel();

            ColumnDefinitionn.Width = new GridLength(80);

            if (CatagoriBorderVerif2 == false) { DriverAddButton(sender, e); }
        }

        private void NewHolidays(object sender, RoutedEventArgs e)
        {
            AddNewDriver.Visibility = Visibility.Hidden;
            DataContext = new HolidayViewModel();

            ColumnDefinitionn.Width = new GridLength(0);

            if (CatagoriBorderVerif2 == false) { DriverAddButton(sender, e); }
        }

        private void NewHome(object sender, RoutedEventArgs e)
        {
            AddNewDriver.Visibility = Visibility.Hidden;
            DataContext = new HomeViewModel();

            ColumnDefinitionn.Width = new GridLength(0);

            if (CatagoriBorderVerif2 == false) { DriverAddButton(sender, e); }

        }
    }
}
