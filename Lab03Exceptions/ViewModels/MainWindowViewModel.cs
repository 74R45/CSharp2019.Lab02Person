using System.Windows;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab03Exceptions.Tools;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab03Exceptions.ViewModels
{
    internal class MainWindowViewModel : BaseNotifyProperty, ILoaderOwner
    {
        #region Fields
        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;
        #endregion

        #region Properties
        public Visibility LoaderVisibility
        {
            get => _loaderVisibility;
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }
        public bool IsControlEnabled
        {
            get => _isControlEnabled;
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }
        #endregion

        internal MainWindowViewModel()
        {
            LoaderManager.Instance.Initialize(this);
        }
    }
}
