namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools.Navigation
{
    internal enum ViewType
    {
        List
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
