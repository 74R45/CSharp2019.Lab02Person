using System;
using System.Threading.Tasks;
using System.Windows;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab03Exceptions.Models;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab03Exceptions.Tools;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab03Exceptions.Tools.Exceptions;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab03Exceptions.ViewModels
{
    internal class DataPickerViewModel : BaseNotifyProperty
    {
        #region Fields
        private string _name;
        private string _surname;
        private string _email;
        private DateTime? _dateOfBirth;
        private string _shownText;

        #region Commands
        private RelayCommand<object> _proceedCommand;
        private RelayCommand<object> _cancelCommand;
        #endregion
        #endregion

        #region Properties
        public Person Person { get; set; }

        public string ShownText
        {
            get => _shownText;
            set
            {
                _shownText = value;
                OnPropertyChanged();
            }
        }

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
                return _cancelCommand ?? (_cancelCommand = new RelayCommand<object>(o => Environment.Exit(0)));
            }
        }
        #endregion
        #endregion

        public bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(Surname) &&
                   !string.IsNullOrWhiteSpace(Email) && 
                   DateOfBirth.HasValue;
        }

        private async void ProceedImplementation(object obj)
        {

            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                try
                {
                    Person = new Person(Name, Surname, Email, DateOfBirth.Value);
                }
                catch (BirthDateInTheFutureException e)
                {
                    MessageBox.Show("Birth date is in the future: " + e.DateOfBirth.ToShortDateString());
                    return;
                }
                catch (BirthDateTooFarInThePastException e)
                {
                    MessageBox.Show("Birth date is more than 135 years ago: " + e.DateOfBirth.ToShortDateString());
                    return;
                }
                catch (InvalidEmailException e)
                {
                    MessageBox.Show(e.Message + ": " + e.Email);
                    return;
                }
                catch (NameContainsNonLetterCharactersException e)
                {
                    MessageBox.Show(e.Message + ": " + e.Name);
                    return;
                }
                catch (InvalidOperationException)
                {
                    // Shouldn't happen, but just in case.
                    MessageBox.Show("Please, enter your birth date.");
                    return;
                }

                if (Person.IsBirthday)
                {
                    MessageBox.Show("Happy birthday! :D");
                }

                ShownText = $"Your name: {Person.Name}.\n" +
                            $"Your surname: {Person.Surname}.\n" +
                            $"Your email address: {Person.Email}.\n" +
                            $"Your date of birth: {Person.DateOfBirth.ToShortDateString()}.\n" +
                            (Person.IsAdult ? "You are an adult.\n" : "You're not an adult.\n") +
                            (Person.IsBirthday ? "It's your birthday!\n" : "It's not your birthday.\n") +
                            $"Your Sun Sign: {Person.SunSign}.\n" +
                            $"Your Chinese Sign: {Person.ChineseSign}.";
            });
            LoaderManager.Instance.HideLoader();
        }
    }
}