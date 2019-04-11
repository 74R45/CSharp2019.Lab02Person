using System.Collections.ObjectModel;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Models;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools.Managers;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.ViewModels
{
    class PersonListViewModel : BaseNotifyProperty, IMenuStripList
    {
        private ObservableCollection<Person> _people;

        public ObservableCollection<Person> People
        {
            get => _people;
            private set
            {
                _people = value;
                OnPropertyChanged();
            }
        }

        public Person SelectedPerson { get; private set; }

        internal PersonListViewModel()
        {
            People = new ObservableCollection<Person>(StationManager.DataStorage.PeopleList);
            MenuStripManager.Instance.InitializeList(this);
        }

        public void UpdatePeopleView()
        {
            People = new ObservableCollection<Person>(StationManager.DataStorage.PeopleList);
        }

        internal void UpdateSelectedPeople(Person person)
        {
            SelectedPerson = person;
        }
    }
}