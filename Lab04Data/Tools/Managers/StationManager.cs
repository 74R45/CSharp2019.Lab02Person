using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools.DataStorage;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools.Managers
{
    internal static class StationManager
    {
        internal static SerializedDataStorage DataStorage { get; private set; }

        internal static void Initialize(SerializedDataStorage dataStorage)
        {
            DataStorage = dataStorage;
        }
    }
}
