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


        private ObservableCollection<Person> _personList;
        public ObservableCollection<Person> PersonList
        {
            get { return _personList; }
            private set
            {
                Set(() => PersonList, ref _personList, value);
                RaisePropertyChanged();

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
                if (Grupa == null)
                {
                    PersonList = null;
                }
                else
                {
                    List<Person> _lista2 = _db.People.Where(x => x.GroupId == Grupa.GroupId).ToList();
                    PersonList = new ObservableCollection<Person>(_lista2);
                }
                RaisePropertyChanged();
            }

        }

        private ObservableCollection<Group> _listagrup;

        public ObservableCollection<Group> ListaGrup
        {
            get { return _listagrup; }
            private set
            {
                Set(() => ListaGrup, ref _listagrup, value);
                RaisePropertyChanged();

            }

        }
        ApplicationDb _db = new ApplicationDb();
        public RelayCommand AddGroupCommand { get; private set; }
        public void AddGroup()
        {
            Group g = new Group() { GroupName = Nazwa, PeopleInGroup = null };
            _db.Groups.Add(g);
            _db.SaveChanges();

            List<Group> _lista = _db.Groups.ToList();
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

                                List<Person> _lista2 = _db.People.Where(x => x.GroupId == Grupa.GroupId).ToList();
                                PersonList = new ObservableCollection<Person>(_lista2);

                                RaisePropertyChanged();


                            }
                        }


                    }, AddPersonCanExecute()));
            }
        }

        private RelayCommand<Group> _deleteGroupCommand;
        public RelayCommand<Group> DeleteGroupCommand
        {
            get
            {
                return _deleteGroupCommand
                    ?? (_deleteGroupCommand = new RelayCommand<Group>(
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

            List<Group> _lista = _db.Groups.ToList();
            _listagrup = new ObservableCollection<Group>(_lista);

            AddGroupCommand = new RelayCommand(AddGroup, AddGroupCanExecute);

        }
    }
}