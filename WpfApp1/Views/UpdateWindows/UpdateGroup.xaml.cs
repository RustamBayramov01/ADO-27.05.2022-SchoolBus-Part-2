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
using System.Windows.Shapes;

namespace WpfApp1.Views.UpdateWindows
{
    /// <summary>
    /// Interaction logic for UpdateGroup.xaml
    /// </summary>
    public partial class UpdateGroup : Window
    {


        public UpdateGroup()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try { DragMove(); }
            catch (Exception) { throw; }
        }

        private void SAVE_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CLEAR_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void ClassName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
