using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Models;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools
{
    internal interface IMenuStripList
    {
        Person SelectedPerson { get; }
        void UpdatePeopleView();
    }
}
