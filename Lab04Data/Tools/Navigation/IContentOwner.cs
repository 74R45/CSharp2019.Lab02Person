using System.Windows.Controls;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools.Navigation
{
    internal interface IContentOwner
    {
        ContentControl ContentControl { get; }
    }
}