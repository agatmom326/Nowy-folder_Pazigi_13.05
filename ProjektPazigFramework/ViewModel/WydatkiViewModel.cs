using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProjektPazigFramework.Model;
using ProjektPazigFramework.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;

namespace ProjektPazigFramework.ViewModel
{
    public class WydatkiViewModel : ViewModelBase
    {
        private ObservableCollection<Group> _listagrup;
        public ObservableCollection<Group> ListaGrup
        {
            get { return _listagrup; }
            private set
            {
                Set(() => ListaGrup, ref _listagrup, value);
            }

        }

        private ObservableCollection<Expense> _listawydatkow;
        public ObservableCollection<Expense> Listawydatkow
        {
            get { return _listawydatkow; }
            private set
            {
                Set(() => Listawydatkow, ref _listawydatkow, value);
            }

        }

        //private ObservableCollection<Person> _osobychecked;
        //public ObservableCollection<Person> Osobychecked
        //{
        //    get { return _osobychecked; }
        //    private set
        //    {
        //        Set(() => Osobychecked, ref _osobychecked, value);
        //        RaisePropertyChanged();
        //    }

        //}

        //private RelayCommand<Person> _changeBoxCommand;
        //public RelayCommand<Person> ChangeBoxCommand
        //{
        //    get
        //    {
        //        return _changeBoxCommand
        //        ?? (_changeBoxCommand = new RelayCommand<Person>(
        //        (item) =>
        //        {
        //            _osobychecked.Add(item);

        //        }));
        //    }
        //}

        private string _nazwawydatku;
        private const string NazwawydatkuPropertyName = "Expensename";
        public string Nazwawydatku
        {
            get { return _nazwawydatku; }
            set
            {
                Set(NazwawydatkuPropertyName, ref _nazwawydatku, value);
                RaisePropertyChanged();
                AddExpenseCommand.RaiseCanExecuteChanged();
            }
        }
        private int _kwota;
        private const string KwotaPropertyName = "Value";
        public int Kwota
        {
            get { return _kwota; }
            set
            {
                Set(KwotaPropertyName, ref _kwota, value);
                RaisePropertyChanged();
                AddExpenseCommand.RaiseCanExecuteChanged();
            }
        }

        private Person _platnik;
        public Person Platnik
        {
            get { return _platnik; }
            set
            {
                Set(() => Platnik, ref _platnik, value);
                RaisePropertyChanged();
                AddExpenseCommand.RaiseCanExecuteChanged();

            }

        }
        public RelayCommand AddExpenseCommand { get; private set; }
        public void AddExpense()
        {
            Expense g = new Expense() { Name = Nazwawydatku, Amount = Kwota, PersonId= Platnik.PersonId, GroupId= Platnik.GroupId};
            _db.Expenses.Add(g);
            _db.SaveChanges();

            List<Expense> _lista = _db.Expenses.ToList();
            List<Group> _lista2 = _db.Groups.ToList();
            Listawydatkow = new ObservableCollection<Expense>(_lista);
            ListaGrup = new ObservableCollection<Group>(_lista2);
        }
        public bool AddExpenseCanExecute()
        {
            return !(Nazwawydatku == "" || Nazwawydatku == null || Kwota == 0 || Platnik== null);

        }

        private RelayCommand<Expense> _deleteExpenseCommand;
        public RelayCommand<Expense> DeleteExpenseCommand
        {
            get
            {
                return _deleteExpenseCommand
                    ?? (_deleteExpenseCommand = new RelayCommand<Expense>(
                    (item) =>
                    {
                        if (item != null)
                        {
                            _db.Expenses.Remove(item);
                            _db.SaveChanges();

                            List<Expense> _lista = _db.Expenses.ToList();
                            Listawydatkow = new ObservableCollection<Expense>(_lista);
                        }

                    }));
            }
        }
            //private HashSet<Person> mCheckedItems;
            //private ObservableCollection<Person> mItems;
            //public IEnumerable<Person> Items { get { return mItems; } }

            //private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            //{
            //    if (e.OldItems != null)
            //    {
            //        foreach (Person item in e.OldItems)
            //        {
            //            item.PropertyChanged -= Item_PropertyChanged;
            //            mCheckedItems.Remove(item);
            //        }
            //    }
            //    if (e.NewItems != null)
            //    {
            //        foreach (Person item in e.NewItems)
            //        {
            //            item.PropertyChanged += Item_PropertyChanged;
            //            if (item.IsChecked) mCheckedItems.Add(item);
            //        }
            //    }
            //}

            //private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
            //{
            //    if (e.PropertyName == "IsChecked")
            //    {
            //        Person item = (Person)sender;
            //        if (item.IsChecked)
            //        {
            //            mCheckedItems.Add(item);
            //        }
            //        else
            //        {
            //            mCheckedItems.Remove(item);
            //        }
            //    }
            //}


            ApplicationDb _db = new ApplicationDb();

        public WydatkiViewModel()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory",
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));

            List<Group> _lista = _db.Groups.ToList();
            _listagrup = new ObservableCollection<Group>(_lista);

            List<Expense> _lista2 = _db.Expenses.ToList();
            _listawydatkow = new ObservableCollection<Expense>(_lista2);

            AddExpenseCommand = new RelayCommand(AddExpense, AddExpenseCanExecute);



            //List<Person> _lista2 = _db.People.ToList();
            //mItems = new ObservableCollection<Person>(_lista2);

            //mCheckedItems = new HashSet<Person>();
            //mItems.CollectionChanged += Items_CollectionChanged;

        }

    }

   
}
