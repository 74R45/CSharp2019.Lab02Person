using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools.DataStorage;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools.Managers;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools.Navigation;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.ViewModels;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentOwner
    {
        public ContentControl ContentControl => _contentControl;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            InitializeApplication();
        }

        private async void InitializeApplication()
        {
            StationManager.Initialize(new SerializedDataStorage());
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            });
            LoaderManager.Instance.HideLoader();
            NavigationManager.Instance.Navigate(ViewType.List);
        }
    }
}
