using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab03Exceptions.ViewModels;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab03Exceptions.Views
{
    /// <summary>
    /// Interaction logic for DatePickerControl.xaml
    /// </summary>
    public partial class DataPickerControl
    {
        public DataPickerControl()
        {
            InitializeComponent();
            DataContext = new DataPickerViewModel();
        }
    }
}