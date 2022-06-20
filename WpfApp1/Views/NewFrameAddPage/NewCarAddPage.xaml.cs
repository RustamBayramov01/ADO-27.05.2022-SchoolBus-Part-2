using Microsoft.Data.SqlClient;
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
    /// Interaction logic for NewCarAddPage.xaml
    /// </summary>
    public partial class NewCarAddPage : Page
    {

        SbDbContext context = new SbDbContext();
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-DOJVHHJ; Initial Catalog=SbDb; Integrated Security=SSPI;");

        public NewCarAddPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SAVE_Click(object sender, RoutedEventArgs e)
        {
            context.Cars.Add(new Car() { Title = Title.Text, Number = Number.Text, SeatCount = int.Parse(SeatCountt.Text) });
            context.SaveChanges();

            Title.Text = null;
            Number.Text = null;
            SeatCountt.Text = null;

        }

        private void CLEAR_Click(object sender, RoutedEventArgs e)
        {
            Title.Text = null;
            Number.Text = null;
            SeatCountt.Text = null;
        }

        private void Title_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        
        private void SeatCountt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
