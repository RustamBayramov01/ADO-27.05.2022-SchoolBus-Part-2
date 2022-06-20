using Sclbus.Models;
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
using WpfApp1.Views.NewWarning;
using WpfApp1.Views.UpdateWindows;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for NewParentPage.xaml
    /// </summary>
    public partial class NewParentPage : Page
    {

        SbDbContext sbdbcontext = SbDbContext.GetInstace();
        List<Parent> parent = new List<Parent>();

        public NewParentPage()
        {
            InitializeComponent();
            DataContext = this;
            Refresh();
        }

        public void Refresh()
        {
            parent = sbdbcontext.Parents.ToList();
            myParentView.ItemsSource = parent;
        }


        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {

            if (myParentView.SelectedIndex >= 0)
            {
                UpdateParent updateParent = new UpdateParent();

                updateParent.FirstName.Text = (myParentView.SelectedItem as Parent).FirstName;
                updateParent.LastName.Text = (myParentView.SelectedItem as Parent).LastName;
                updateParent.UserName.Text = (myParentView.SelectedItem as Parent).UserName;
                updateParent.Password.Text = (myParentView.SelectedItem as Parent).Password;
                updateParent.Phone.Text = (myParentView.SelectedItem as Parent).Phone;

                updateParent.ShowDialog();

                if (updateParent.DialogResult == true)
                {
                    foreach (var item in parent)
                    {
                        if (item.Id == (myParentView.SelectedItem as Parent).Id)
                        {
                            item.FirstName = updateParent.FirstName.Text;
                            item.LastName = updateParent.LastName.Text;
                            item.Phone = updateParent.Phone.Text;
                            item.UserName = updateParent.UserName.Text;
                            item.Password = updateParent.Password.Text;

                            sbdbcontext.Parents.Update(item);
                        }
                    }

                    sbdbcontext.SaveChanges();

                    parent = sbdbcontext.Parents.ToList();
                    myParentView.ItemsSource = parent;
                }
            }
            else
            {
                IndexWarning indexWarning = new();
                indexWarning.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                indexWarning.ShowDialog();
            }

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (myParentView.SelectedIndex >= 0)
            {
                var context = SbDbContext.GetInstace();
                var parnet = context.Parents.FirstOrDefault(x => x.Id.Equals((myParentView.SelectedItem as Parent).Id));
                context.Parents.Remove(parnet);
                context.SaveChanges();

                parent = sbdbcontext.Parents.ToList();
                myParentView.ItemsSource = parent;
            }
            else
            {
                IndexWarning indexWarning = new();
                indexWarning.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                indexWarning.ShowDialog();
            }
        }

        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                foreach (var driver in myParentView.Items)
                {
                    if ((driver as Parent).FirstName.Contains(Search.Text))
                    {
                        myParentView.SelectedItem = driver;
                    }
                }

            }
        }
    }
}
