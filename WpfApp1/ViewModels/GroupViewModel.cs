using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Command;
using WpfApp1.Views.NewFrameAddPage;
using WpfApp1.Views.NewFramePage;

namespace WpfApp1.ViewModels
{
    public class GroupViewModel : DependencyObject
    {

        public Page SelectedPage
        {
            get { return (Page)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }
        public static readonly DependencyProperty MyPropertyProperty =
        DependencyProperty.Register("SelectedPage", typeof(Page), typeof(GroupViewModel));

        public Page SelectedAddPage
        {
            get { return (Page)GetValue(other); }
            set { SetValue(other, value); }
        }
        public static readonly DependencyProperty other =
        DependencyProperty.Register("SelectedAddPage", typeof(Page), typeof(GroupViewModel));



        public RelayCommand Group { get; set; }


        public GroupViewModel()
        {
            Group = new RelayCommand(VGroup);
        }

        public void VGroup(object other)
        {
            SelectedPage = new NewGroupPage();
            SelectedAddPage = new NewGroupAddPage();
        }


    }
}
