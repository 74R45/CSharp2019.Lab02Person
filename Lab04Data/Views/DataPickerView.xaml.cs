using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Models;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools.Navigation;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.ViewModels;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Views
{
    /// <summary>
    /// Interaction logic for DatePickerView.xaml
    /// </summary>
    public partial class DataPickerView : INavigatable
    {
        public DataPickerView()
        {
            InitializeComponent();
            DataContext = new DataPickerViewModel(this, DataPickerMode.Add);
        }

        internal DataPickerView(Person person, DataPickerMode mode = DataPickerMode.Add)
        {
            InitializeComponent();
            DataContext = new DataPickerViewModel(this, person, mode);
        }
    }
}