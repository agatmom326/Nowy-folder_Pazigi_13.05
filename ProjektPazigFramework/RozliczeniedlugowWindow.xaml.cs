using MahApps.Metro.Controls;
using ProjektPazigFramework.ViewModel;
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
using System.Windows.Shapes;

namespace ProjektPazigFramework
{
    /// <summary>
    /// Logika interakcji dla klasy Rozliczeniedlugow.xaml
    /// </summary>
    public partial class Rozliczeniedlugow : MetroWindow
    {
        public Rozliczeniedlugow()
        {
            InitializeComponent();
            this.DataContext = new RozliczeniedlugowViewModel();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OknowyboruWindow a = new OknowyboruWindow();
            a.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WydatkiWindow a = new WydatkiWindow();
            a.Show();
            this.Close();
        }
    }
}
