using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProjektPazigFramework.Model;
using ProjektPazigFramework.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.Collections.Specialized;
//using System.ComponentModel;
//using System.Data.Entity;
using System.Linq;
//using System.Windows.Controls;

namespace ProjektPazigFramework.ViewModel
{
    public class WydatkiViewModel : ViewModelBase
    {
        ApplicationDb _db = new ApplicationDb();

        private ObservableCollection<Group> _listagrup;
        public ObservableCollection<Group> LListaGrup
        {
            get { return _listagrup; }
            private set
            {
                Set(() => LListaGrup, ref _listagrup, value);

            }

        }


        private string _txt;
        private const string TekstPropertyName = "Expensename";
        public string Txt
        {
            get { return _txt; }
            set
            {
                Set(TekstPropertyName, ref _txt, value);
                RaisePropertyChanged();
                AddExpenseCommand.RaiseCanExecuteChanged();

            }
        }

        //private Group _nazwagr;
        //public Group Nazwagr
        //{
        //    get { return _nazwagr; }
        //    private set
        //    {
        //        Set(() => Nazwagr, ref _nazwagr, value);
        //    }
            
        //}

        private Group _grupa;
        private const string TxtPropertyName = "Grupa";
        public Group Grupa
        {
            get { return _grupa; }
            set
            {
                Set(TxtPropertyName, ref _grupa, value);

                List<Expense> _lista2 = _db.Expenses.Where(x => x.GroupId == Grupa.GroupId).ToList();
                Listawydatkow = new ObservableCollection<Expense>(_lista2);
                RaisePropertyChanged();
            }

        }


        private ObservableCollection<Expense> _listawydatkow;
        public ObservableCollection<Expense> Listawydatkow
        {
            get { return _listawydatkow; }
            private set
            {
                Set(() => Listawydatkow, ref _listawydatkow, value);
                RaisePropertyChanged();

            }

        }

       

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

            string[] imiona = Txt.Split(',');
            IEnumerable<Person> osoby = _db.People.Where(x => x.GroupId == Platnik.GroupId).Select(x => x);
            List<Person> osoby2 = osoby.ToList();

            var exid = _db.Expenses.ToList().OrderBy(x => x.ExpenseId).Last();
            for (int i = 0; i < osoby2.Count; i++)
            {
                foreach (var imie in imiona)
                {
                    if (imie == osoby2[i].Name)
                    {
                       Debtor d = new Debtor() { ExpenseId = exid.ExpenseId, PersonId = osoby2[i].PersonId };
                        _db.Debtors.Add(d);
                    }
                }
            }
            _db.SaveChanges();

            List<Group> _lista2 = _db.Groups.ToList();
            LListaGrup = new ObservableCollection<Group>(_lista2);
            List<Expense> _lista = _db.Expenses.Where(x => x.GroupId == Grupa.GroupId).ToList();
            Listawydatkow = new ObservableCollection<Expense>(_lista);
            RaisePropertyChanged();

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

                            List<Expense> _lista = _db.Expenses.Where(x=> x.GroupId== item.GroupId).ToList();
                            Listawydatkow = new ObservableCollection<Expense>(_lista);
                            RaisePropertyChanged();
                        }

                    }));
            }
        }
     


        public WydatkiViewModel()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory",
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));

            List<Group> _lista = _db.Groups.ToList();
            _listagrup = new ObservableCollection<Group>(_lista);

            //List<Expense> _lista2 = _db.Expenses.ToList();
            //_listawydatkow = new ObservableCollection<Expense>(_lista2);

            AddExpenseCommand = new RelayCommand(AddExpense, AddExpenseCanExecute);


        }


    }

   
}
