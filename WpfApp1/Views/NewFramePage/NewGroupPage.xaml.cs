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

namespace WpfApp1.Views.NewFramePage
{
    /// <summary>
    /// Interaction logic for NewGroupPage.xaml
    /// </summary>
    public partial class NewGroupPage : Page
    {


        SbDbContext sbdbcontext = new SbDbContext();
        List<Group> groups = new List<Group>();


        public NewGroupPage()
        {
            InitializeComponent();
            DataContext = this;
            Refresh();
        }



        public void Refresh()
        {
            groups = sbdbcontext.Groups.ToList();
            myGroupView.ItemsSource = groups;
        }

        private void BtnCarUpdate_Click(object sender, RoutedEventArgs e)
        {

            if (myGroupView.SelectedIndex >= 0)
            {

                UpdateGroup updateGroup = new UpdateGroup();
                updateGroup.ClassName.Text = (myGroupView.SelectedItem as Group).Title;

                updateGroup.ShowDialog();

                if (updateGroup.DialogResult == true)
                {
                    foreach (var item in groups)
                    {
                        if (item.Id == (myGroupView.SelectedItem as Group).Id)
                        {
                            item.Title = updateGroup.ClassName.Text;
                            sbdbcontext.Groups.Update(item);
                        }
                    }

                    sbdbcontext.SaveChanges();

                    groups = sbdbcontext.Groups.ToList();
                    myGroupView.ItemsSource = groups;
                }


            }
            else
            {
                IndexWarning indexWarning = new();
                indexWarning.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                indexWarning.ShowDialog();
            }


        }

        private void BtnCarDelete_Click(object sender, RoutedEventArgs e)
        {
            if (myGroupView.SelectedIndex >= 0)
            {
                var other = sbdbcontext.Groups.FirstOrDefault(t => t.Id == (myGroupView.SelectedItem as Group).Id);
                sbdbcontext.Groups.Remove(other);
                sbdbcontext.SaveChanges();

                groups = sbdbcontext.Groups.ToList();
                myGroupView.ItemsSource = groups;
            }
            else
            {
                IndexWarning indexWarning = new();
                indexWarning.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                indexWarning.ShowDialog();
            }

            
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                foreach (var driver in myGroupView.Items)
                {
                    if ((driver as Group).Title.Contains(Search.Text))
                    {
                        myGroupView.SelectedItem = driver;
                    }
                }

            }
        }
    }
}
