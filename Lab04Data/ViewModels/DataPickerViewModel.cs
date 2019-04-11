using System;
using System.Threading.Tasks;
using System.Windows;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Models;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools.Exceptions;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools.Managers;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.ViewModels
{
    internal enum DataPickerMode
    {
        Add,
        Edit
    }

    internal class DataPickerViewModel : BaseNotifyProperty
    {
        #region Fields
        private string _name;
        private string _surname;
        private string _email;
        private DateTime? _dateOfBirth;
        private readonly Window _view;
        private readonly DataPickerMode _mode;

        #region Commands
        private RelayCommand<object> _proceedCommand;
        private RelayCommand<object> _cancelCommand;
        #endregion
        #endregion

        #region Properties
        public Person Person { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime? DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        #region Commands

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand = new RelayCommand<object>(
                           ProceedImplementation, o => CanExecuteCommand()));
            }
        }

        public RelayCommand<object> CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand<object>(o => _view.Close()));
            }
        }
        #endregion
        #endregion

        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(Surname) &&
                   !string.IsNullOrWhiteSpace(Email) && 
                   DateOfBirth.HasValue;
        }

        internal DataPickerViewModel(Window window, DataPickerMode mode)
        {
            _view = window;
            _mode = mode;
        }

        internal DataPickerViewModel(Window window, Person person, DataPickerMode mode)
        {
            _view = window;
            Name = person.Name;
            Surname = person.Surname;
            Email = person.Email;
            DateOfBirth = person.DateOfBirth;
            _mode = mode;
        }

        private async void ProceedImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            bool success = true;
            await Task.Run(() =>
            {
                try
                {
                    Person = new Person(Name, Surname, Email, DateOfBirth.Value);
                }
                catch (BirthDateInTheFutureException e)
                {
                    MessageBox.Show("Birth date is in the future: " + e.DateOfBirth.ToShortDateString());
                    success = false;
                    return;
                }
                catch (BirthDateTooFarInThePastException e)
                {
                    MessageBox.Show("Birth date is more than 135 years ago: " + e.DateOfBirth.ToShortDateString());
                    success = false;
                    return;
                }
                catch (InvalidEmailException e)
                {
                    MessageBox.Show(e.Message + ": " + e.Email);
                    success = false;
                    return;
                }
                catch (NameContainsNonLetterCharactersException e)
                {
                    MessageBox.Show(e.Message + ": " + e.Name);
                    success = false;
                    return;
                }
                catch (InvalidOperationException)
                {
                    // Shouldn't happen, but just in case.
                    MessageBox.Show("Please, enter your birth date.");
                    success = false;
                    return;
                }

                if (_mode == DataPickerMode.Add)
                {
                    MenuStripManager.Instance.AddPerson(Person);
                }
                else
                {
                    MenuStripManager.Instance.EditPerson(Person);
                }
            });
            if (success)
            {
                _view.Close();
            }
            LoaderManager.Instance.HideLoader();
        }
    }
}