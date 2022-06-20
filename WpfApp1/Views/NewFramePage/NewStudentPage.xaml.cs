using Microsoft.EntityFrameworkCore;
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
using WpfApp1.Views.UpdateWindows;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for NewStudentPage.xaml
    /// </summary>
    public partial class NewStudentPage : Page
    {


        SbDbContext sbdbcontext = SbDbContext.GetInstace();
        List<Student> students = new();


        public NewStudentPage()
        {
            InitializeComponent();
            DataContext = this;
            Refresh();
        }


        public void Refresh()
        {
            students = sbdbcontext.Students.Include("Parent").Include("Group").ToList();
            myStudentView.ItemsSource = students;
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {

            UpdateStudent updateStudent = new UpdateStudent();

            updateStudent.FirstName.Text = (myStudentView.SelectedItem as Student).FirstName;
            updateStudent.LastName.Text = (myStudentView.SelectedItem as Student).LastName;
            updateStudent.HomeAddress.Text = (myStudentView.SelectedItem as Student).Home;
            updateStudent.OtherAddress.Text = (myStudentView.SelectedItem as Student).OtherAddress;

            foreach (var item in updateStudent.OutlinedComboBoxx.Items)
            {
                if((item as Parent).Id==(myStudentView.SelectedItem as Student).Parent.Id)
                {
                    updateStudent.OutlinedComboBoxx.SelectedItem = item;
                }
            }

            updateStudent.ShowDialog();

            if(updateStudent.DialogResult == true)
            {

                foreach (var item in students)
                {

                    if(item.Id == (myStudentView.SelectedItem as Student).Id)
                    {
                        item.FirstName = updateStudent.FirstName.Text;
                        item.LastName = updateStudent.LastName.Text;
                        item.Home = updateStudent.HomeAddress.Text;
                        item.HomeDescription = updateStudent.HomeAddress.Text;
                        item.OtherAddress = updateStudent.OtherAddress.Text;
                        item.OtherAddressDescription = updateStudent.OtherAddress.Text;

                        item.Parent = sbdbcontext.Parents.FirstOrDefault(testc => testc.Id == (updateStudent.OutlinedComboBoxx.SelectedItem as Parent).Id);
                        item.ParentId = item.Parent.Id;

                        sbdbcontext.Students.Update(item);

                    }

                }

                sbdbcontext.SaveChanges();

                students = sbdbcontext.Students.Include("Parent").Include("Group").ToList();
                myStudentView.ItemsSource = students;

            }

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var other = sbdbcontext.Students.FirstOrDefault(t => t.Id == (myStudentView.SelectedItem as Student).Id);
            sbdbcontext.Students.Remove(other);
            sbdbcontext.SaveChanges();
            students = sbdbcontext.Students.Include("Parent").Include("Group").ToList();
            myStudentView.ItemsSource = students;
        }

        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                foreach (var driver in myStudentView.Items)
                {
                    if ((driver as Student).FirstName.Contains(Search.Text))
                    {
                        myStudentView.SelectedItem = driver;
                    }
                }

            }
        }
    }
}
