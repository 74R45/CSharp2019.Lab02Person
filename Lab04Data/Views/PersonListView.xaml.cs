using System.Windows.Controls;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Models;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools.Navigation;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.ViewModels;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Views
{
    /// <summary>
    /// Interaction logic for PersonListView.xaml
    /// </summary>
    public partial class PersonListView : INavigatable
    {
        private readonly PersonListViewModel _viewModel;

        public PersonListView()
        {
            InitializeComponent();
            _viewModel = new PersonListViewModel();
            DataContext = _viewModel;
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid grid = (DataGrid) sender;
            _viewModel.UpdateSelectedPeople((Person)grid.SelectedItem);
        }
    }
}
