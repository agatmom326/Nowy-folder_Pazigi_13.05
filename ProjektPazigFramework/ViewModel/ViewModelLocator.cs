/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:ProjektPazigFramework"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
//using Microsoft.Practices.ServiceLocation;

namespace ProjektPazigFramework.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<WydatkiViewModel>();
            SimpleIoc.Default.Register<RozliczeniedlugowViewModel>();

            //SimpleIoc.Default.Register<ComboBoxViewModel>();




        }

        public MainViewModel Main
         {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
         }

        public WydatkiViewModel Wydatki
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WydatkiViewModel>();
            }
        }

        public RozliczeniedlugowViewModel Rozliczenie
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RozliczeniedlugowViewModel>();
            }
        }


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}