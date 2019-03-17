using System.Windows;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab03Exceptions.ViewModels;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab03Exceptions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
