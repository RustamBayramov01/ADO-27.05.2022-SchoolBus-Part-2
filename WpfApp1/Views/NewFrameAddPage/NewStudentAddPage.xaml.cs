using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for NewStudentAddPage.xaml
    /// </summary>
    public partial class NewStudentAddPage : Page
    {

        SbDbContext sbDbContext = new SbDbContext();
        List<Parent> parents = new List<Parent>();

        public NewStudentAddPage()
        {

            InitializeComponent();
            parents = sbDbContext.Parents.ToList();
            OutlinedComboBoxx.ItemsSource = parents;

        }

        private void SAVE_Click(object sender, RoutedEventArgs e)
        {
            sbDbContext.Students.Add(new Student()
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Home = HomeAddress1.Text,
                HomeDescription = HomeAddress1.Text,
                OtherAddress = HomeAddress2.Text,
                OtherAddressDescription = HomeAddress2.Text,
                Parent = (OutlinedComboBoxx.SelectedItem as Parent),
                ParentId = (OutlinedComboBoxx.SelectedItem as Parent).Id
            });


            sbDbContext.SaveChanges();


            FirstName.Text = null;
            LastName.Text = null;
            HomeAddress1.Text = null;
            HomeAddress2.Text = null;
            OutlinedComboBoxx.SelectedItem = null;

        }

        private void CANCEL_Click(object sender, RoutedEventArgs e)
        {
            FirstName.Text = null;
            LastName.Text = null;
            OutlinedComboBoxx.SelectedItem = null;
            HomeAddress1.Text = null;
            HomeAddress2.Text = null;
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

        private void HomeAddress1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void HomeAddress2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
