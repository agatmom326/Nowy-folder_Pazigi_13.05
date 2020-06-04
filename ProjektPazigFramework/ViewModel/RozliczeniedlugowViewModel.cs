using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProjektPazigFramework.Model;
using ProjektPazigFramework.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Controls;

namespace ProjektPazigFramework.ViewModel
{
    public class RozliczeniedlugowViewModel : ViewModelBase
    {
        ApplicationDb _db = new ApplicationDb();

        private ObservableCollection<Group> _listagrup;
        public ObservableCollection<Group> ListaGrup
        {
            get { return _listagrup; }
            private set
            {
                Set(() => ListaGrup, ref _listagrup, value);
            }

        }

        private ObservableCollection<Debet> _listadlugow;
        public ObservableCollection<Debet> ListaDlugow
        {
            get { return _listadlugow; }
            private set
            {
                Set(() => ListaDlugow, ref _listadlugow, value);
                RaisePropertyChanged();
                DeleteDebetsCommand.RaiseCanExecuteChanged();
            }

        }

        private Group _grupa;
        private const string TekstPropertyName = "Grupa";
        public Group Grupa
        {
            get { return _grupa; }
            set
            {
                Set(TekstPropertyName, ref _grupa, value);
                RaisePropertyChanged();
                ShowListDebetsCommand.RaiseCanExecuteChanged();

            }

        }

        public RelayCommand ShowListDebetsCommand { get; private set; }
        public void ShowListDebets()
        {
            Macierzdluznikow nowa = new Macierzdluznikow(Grupa.GroupId);
            _db.Debets.RemoveRange(_db.Debets.Where(x => x.GroupId == Grupa.GroupId).ToList());
            _db.SaveChanges();
            if (nowa.listawydatkowgrupy.Count != 0)
            {
                nowa.ObliczMacierz(nowa.graph);
                List<Debet> lista = _db.Debets.Where(x => x.GroupId == Grupa.GroupId).ToList();
                ListaDlugow = new ObservableCollection<Debet>(lista);

            }
            else
            {
                ListaDlugow = null;
                RaisePropertyChanged();
            }


        }
        public bool AddExpenseCanExecute()
        {
            return !(Grupa == null);

        }

        public RelayCommand DeleteDebetsCommand{ get; private set; }
        public void DeleteDebets()
        {
            _db.Debets.RemoveRange(_db.Debets.Where(x => x.GroupId == Grupa.GroupId).ToList());
            _db.Expenses.RemoveRange(_db.Expenses.Where(x => x.GroupId == Grupa.GroupId).ToList());
            _db.SaveChanges();
            ListaDlugow = null;
            RaisePropertyChanged();



        }
        public bool DeleteDebetsCanExecute()
        {
            return !(_listadlugow== null);

        }



        public RozliczeniedlugowViewModel()
        {
           AppDomain.CurrentDomain.SetData("DataDirectory",
           Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));

            List<Group> _lista = _db.Groups.ToList();
            _listagrup = new ObservableCollection<Group>(_lista);

            ShowListDebetsCommand = new RelayCommand(ShowListDebets, AddExpenseCanExecute);
            DeleteDebetsCommand = new RelayCommand(DeleteDebets, DeleteDebetsCanExecute);

        }

    }
}
