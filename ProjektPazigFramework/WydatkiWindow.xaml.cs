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
using System.Windows.Navigation;
using MahApps.Metro.Controls;
using ProjektPazigFramework.ViewModel;

namespace ProjektPazigFramework
{
    /// <summary>
    /// Logika interakcji dla klasy WydatkiWindow.xaml
    /// </summary>
    public partial class WydatkiWindow : MetroWindow
    {
        public WydatkiWindow()
        {
            InitializeComponent();
            this.DataContext = new WydatkiViewModel();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OknowyboruWindow a = new OknowyboruWindow();
            a.Show();
            this.Close();
        }

        
    
    }
}
