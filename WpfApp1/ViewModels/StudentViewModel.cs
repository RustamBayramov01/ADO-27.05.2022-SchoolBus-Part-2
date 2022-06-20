using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Command;
using WpfApp1.Views;

namespace WpfApp1.ViewModels
{
    public class StudentViewModel : DependencyObject
    {

        public Page SelectedPage
        {
            get { return (Page)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }
        public static readonly DependencyProperty MyPropertyProperty =
        DependencyProperty.Register("SelectedPage", typeof(Page), typeof(StudentViewModel));

        public Page SelectedAddPage
        {
            get { return (Page)GetValue(other); }
            set { SetValue(other, value); }
        }
        public static readonly DependencyProperty other =
        DependencyProperty.Register("SelectedAddPage", typeof(Page), typeof(StudentViewModel));


        public RelayCommand Student { get; set; }

        public StudentViewModel()
        {
            Student = new RelayCommand(VStudent);
        }

        public void VStudent(object other)
        {
            SelectedPage = new NewStudentPage();
            SelectedAddPage = new NewStudentAddPage();
        }
    }
}
