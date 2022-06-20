using Sclbus.Models;
using System;
using System.Collections.Generic;
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
namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for NewParentAddPage.xaml
    /// </summary>
    public partial class NewParentAddPage : Page
    {
        SbDbContext sbDbContext = SbDbContext.GetInstace();
        List<Parent> parents = new();

        public NewParentAddPage()
        {
            InitializeComponent();
        }

        private void SAVE_Click(object sender, RoutedEventArgs e)
        {

            sbDbContext.Parents.Add(new Parent()
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Phone = Phone.Text,
                UserName = Username.Text,
                Password = Password.Text
            });

            sbDbContext.SaveChanges();

            FirstName.Text = null;
            LastName.Text = null;
            Phone.Text = null;
            Username.Text = null;
            Password.Text = null;

        }

        private void CLEAR_Click(object sender, RoutedEventArgs e)
        {
            FirstName.Text = null;
            LastName.Text = null;
            Phone.Text = null;
            Username.Text = null;
            Password.Text = null;
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

        private void Username_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
