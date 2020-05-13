using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ProjektPazigFramework.Model;
using ProjektPazigFramework.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProjektPazigFramework.ViewModel
{
   
    public class MainViewModel: ViewModelBase
    {
        private string _nazwa;
        private const string NazwaPropertyName = "Groupname";
        public string Nazwa
        {
            get { return _nazwa; }
            set
            {
                Set(NazwaPropertyName, ref _nazwa, value);
                RaisePropertyChanged();
                AddGroupCommand.RaiseCanExecuteChanged();
            }
        }

        private string _imie;
        private const string ImiePropertyName = "Personname";
        public string Imie
        {
            get { return _imie; }
            set
            {
                Set(ImiePropertyName, ref _imie, value);
                RaisePropertyChanged();
                AddPersonCommand.RaiseCanExecuteChanged();

            }
        }


        private IList<Person> _personList;
        public IList<Person> PersonList
        {
            get { return _personList; }
            private set
            {
                Set(() => PersonList, ref _personList, value);
            }
        }

        //private RelayCommand<Group> _pokazOsoby;
        //public RelayCommand<Group> PokazOsoby
        //{
        //    get
        //    {
        //        return _pokazOsoby
        //            ?? (_pokazOsoby = new RelayCommand<Group>(
        //            (item) =>
        //            {
        //                    IList<Person> _personList = item.PeopleInGroup.ToList();                        
        //           }));
        //    }
        //}


        private ObservableCollection<Group> _listagrup;

        public ObservableCollection<Group> ListaGrup
        {
            get { return _listagrup; }
            private set
            {
                Set(() => ListaGrup, ref _listagrup, value);
            }

        }
        ApplicationDb _db = new ApplicationDb();

        public RelayCommand AddGroupCommand { get;  private set; }
        public void AddGroup()
        {
                        Group g = new Group() { GroupName = Nazwa, PeopleInGroup= null };
                        _db.Groups.Add(g);
                        _db.SaveChanges();
                        
                        List<Group>_lista = _db.Groups.ToList();
                        ListaGrup = new ObservableCollection<Group>(_lista);
        }

        public bool AddPersonCanExecute()
        {
            return !(Imie == "");
        }
        public bool AddGroupCanExecute()
        {
            return !(Nazwa == "" || Nazwa== null);
        }

        //MainWindow a = new MainWindow();
        //OknowyboruWindow b = new OknowyboruWindow();
        //public RelayCommand OpenNewWindowCommand { get; private set; }
        //public void OpenNewWindow()
        //{
        //    a.Close();
        //    b.Show();

        //}

        private RelayCommand<Group> _addPersonCommand;
        public RelayCommand<Group> AddPersonCommand
        {
            get
            {
                return _addPersonCommand
                    ?? (_addPersonCommand = new RelayCommand<Group>(
                    (item) =>
                    {
                        if (item != null)
                        {
                            if (Imie != "" && Imie !=null)
                            {
                                int ileosob;
                                if (item.PeopleInGroup == null)
                                {
                                    ileosob = 0;
                                }
                                else
                                {
                                    ileosob = item.PeopleInGroup.Count;
                                }

                                Person p = new Person() { Name = Imie, GroupId = item.GroupId, Group = item, NrIndexInGroup = ileosob + 1 };
                                _db.People.Add(p);
                                item.PeopleInGroup.Add(p);
                                _db.SaveChanges();

                                List<Group> _lista = _db.Groups.ToList();
                                ListaGrup = new ObservableCollection<Group>(_lista);
                                RaisePropertyChanged();


                            }
                        }


                    }, AddPersonCanExecute()));
            }
        }

        private RelayCommand<Group> _deleteProductCommand;
        public RelayCommand<Group> DeleteProductCommand
        {
            get
            {
                return _deleteProductCommand
                    ?? (_deleteProductCommand = new RelayCommand<Group>(
                    (item) =>
                    {
                        if (item != null)
                        {
                            _db.Groups.Remove(item);
                            _db.SaveChanges();

                            List<Group> _lista = _db.Groups.ToList();
                            ListaGrup = new ObservableCollection<Group>(_lista);
                        }
                        
                    }));
            }
        }

        public MainViewModel()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory",
            Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));

            //_personList = _db.People.ToList();
            List<Group> _lista = _db.Groups.ToList();
            _listagrup = new ObservableCollection<Group>(_lista);

            AddGroupCommand = new RelayCommand(AddGroup, AddGroupCanExecute);


        }
    }
}