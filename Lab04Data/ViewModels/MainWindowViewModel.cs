using System;
using System.Windows;
using System.Windows.Input;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools.Managers;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Views;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.ViewModels
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

        #region Commands
        #region Fields
        private ICommand _createPersonCommand;
        private ICommand _createRandomCommand;
        private ICommand _editCommand;
        private ICommand _deleteCommand;
        private ICommand _exitCommand;
        #endregion

        #region Properties
        public ICommand CreatePersonCommand =>
            _createPersonCommand ?? (_createPersonCommand = new RelayCommand<object>(CreatePersonImplementation));

        public ICommand CreateRandomCommand =>
            _createRandomCommand ?? (_createRandomCommand = new RelayCommand<object>(CreateRandomImplementation));

        public ICommand EditCommand =>
            _editCommand ?? (_editCommand = new RelayCommand<object>(EditImplementation, IsPersonSelected));

        public ICommand DeleteCommand =>
            _deleteCommand ?? (_deleteCommand = new RelayCommand<object>(DeleteImplementation, IsPersonSelected));

        public ICommand ExitCommand =>
            _exitCommand ?? (_exitCommand = new RelayCommand<object>(ExitImplementation));
        #endregion

        private bool IsPersonSelected(object obj)
        {
            return true;
        }

        #region Implementations
        private void CreatePersonImplementation(object obj)
        {
            DataPickerView picker = new DataPickerView();
            picker.Show();
        }

        private void CreateRandomImplementation(object obj)
        {
            MenuStripManager.Instance.AddRandomPerson();
        }

        private void EditImplementation(object obj)
        {
            MenuStripManager.Instance.EditPerson();
        }

        private void DeleteImplementation(object obj)
        {
            MenuStripManager.Instance.DeletePerson();
        }

        private void ExitImplementation(object obj)
        {
            Environment.Exit(0);
        }
        #endregion
        #endregion
    }
}
