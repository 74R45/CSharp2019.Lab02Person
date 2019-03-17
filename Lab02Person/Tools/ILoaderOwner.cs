using System.ComponentModel;
using System.Windows;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab02Person.Tools
{
    internal interface ILoaderOwner : INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsControlEnabled { get; set; }
    }
}
