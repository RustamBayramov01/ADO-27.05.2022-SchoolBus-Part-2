using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Sclbus.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using WpfApp1.Command;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for NewDriverAddPage.xaml
    /// </summary>
    public partial class NewDriverAddPage : Page
    {

        SbDbContext sbdbcontext = new SbDbContext();

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-DOJVHHJ; Initial Catalog=SbDb; Integrated Security=SSPI;");
        List<Car> cars = new List<Car>();

        public NewDriverAddPage()
        {
            InitializeComponent();
            DataContext = this;

            cars = sbdbcontext.Cars.ToList();
            OutlinedComboBox.ItemsSource = cars;
            OutlinedComboBox.DisplayMemberPath = "Title";
        }


        private void SAVE_Click(object sender, RoutedEventArgs e)
        {
            Car? car = (OutlinedComboBox.SelectedItem as Car);

            Driver driver;

            if(car != null)
            {

                driver = new Driver()
                {
                    FirstName = FirstName.Text,
                    LastName = LastName.Text,
                    Phone = Phone.Text,
                    UserName = UserName.Text,
                    Password = Password.Text,
                    License = Licence.Text,
                    CarId = car.Id,
                    Cars = new List<Car>() { car }
                };

                sbdbcontext.Drivers.Add(driver);
                sbdbcontext.Cars.Update(car);
                

            }
            else
            {

                driver = new Driver()
                {
                    FirstName = FirstName.Text,
                    LastName = LastName.Text,
                    Phone = Phone.Text,
                    UserName = UserName.Text,
                    Password = Password.Text,
                    License = Licence.Text
                };

                sbdbcontext.Drivers.Add(driver);

            }


            FirstName.Text = null;
            LastName.Text = null;
            Phone.Text = null;
            UserName.Text = null;
            Password.Text = null;
            Licence.Text = null;
            OutlinedComboBox.SelectedItem = null;

            sbdbcontext.SaveChanges();



        }

        private void FirstName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void LastName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
            
        }

        private void Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void UserName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);

        }

        private void Licence_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void CANCEL_Click(object sender, RoutedEventArgs e)
        {
            FirstName.Text = null;
            LastName.Text = null;
            Phone.Text = null;
            UserName.Text = null;
            Password.Text = null;
            Licence.Text = null;
            HomeAddress.Text = null;
            OutlinedComboBox.SelectedItem = null;
        }
    }
}
