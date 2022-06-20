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

namespace WpfApp1.Views.NewFramePage
{
    /// <summary>
    /// Interaction logic for NewHomePage.xaml
    /// </summary>
    public partial class NewHomePage : Page
    {

        int other = 0;
        SbDbContext sbdbcontext = new SbDbContext();
        List<Student> students = new List<Student>();


        public NewHomePage()
        {
            InitializeComponent();
            DataContext = this;
            Refresh();
        }

        public void Refresh()
        {
            var context = SbDbContext.GetInstace();

            if (context.Holidays != null)
            {
                foreach (var item in context.Holidays)
                {
                    Calendar.SelectedDates.Add((DateTime.Parse(item.Date.ToString())));
                }
            }
            other = 1;
        }

    }
}
