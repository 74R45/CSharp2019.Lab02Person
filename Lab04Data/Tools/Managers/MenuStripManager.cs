using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Models;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.ViewModels;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Views;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools.Managers
{
    internal class MenuStripManager
    {
        private static readonly object Locker = new object();
        private static MenuStripManager _instance;

        internal static MenuStripManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                lock (Locker)
                {
                    return _instance ?? (_instance = new MenuStripManager());
                }
            }
        }

        private IMenuStripList _list;

        internal void InitializeList(IMenuStripList list)
        {
            _list = list;
        }

        internal void AddRandomPerson()
        {
            StationManager.DataStorage.AddRandomPerson();
            _list.UpdatePeopleView();
        }

        internal void EditPerson()
        {
            DataPickerView picker = new DataPickerView(_list.SelectedPerson, DataPickerMode.Edit);
            picker.Show();
        }

        internal void EditPerson(Person person)
        {
            int index = StationManager.DataStorage.PeopleList.IndexOf(_list.SelectedPerson);
            StationManager.DataStorage.SetPerson(person, index);
            _list.UpdatePeopleView();
        }

        internal void AddPerson(Person person)
        {
            StationManager.DataStorage.AddPerson(person);
            _list.UpdatePeopleView();
        }

        internal void DeletePerson()
        {
            StationManager.DataStorage.DeletePerson(_list.SelectedPerson);
            _list.UpdatePeopleView();
        }
    }
}
