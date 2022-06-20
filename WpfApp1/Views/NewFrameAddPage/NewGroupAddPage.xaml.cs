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

namespace WpfApp1.Views.NewFrameAddPage
{
    /// <summary>
    /// Interaction logic for NewGroupAddPage.xaml
    /// </summary>
    public partial class NewGroupAddPage : Page
    {

        SbDbContext context = SbDbContext.GetInstace();

        public NewGroupAddPage()
        {
            InitializeComponent();
        }

        private void SAVE_Click(object sender, RoutedEventArgs e)
        {
            context.Groups.Add(new Sclbus.Models.Group()
            {
                Title = ClassName.Text
            });

            context.SaveChanges();

            ClassName.Text = null;
        }

        private void CANCEL_Click(object sender, RoutedEventArgs e)
        {
            ClassName.Text = null;
        }

        private void ClassName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
