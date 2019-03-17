using System;
using System.Threading.Tasks;
using System.Windows;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab02Person.Models;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab02Person.Tools;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab02Person.ViewModels
{
    internal class DataPickerViewModel : BaseNotifyProperty
    {
        #region Fields
        private string _shownText;

        #region Commands
        private RelayCommand<object> _proceedCommand;
        private RelayCommand<object> _cancelCommand;
        #endregion
        #endregion

        #region Properties
        public Person Person { get; set; } = new Person("", "", "");

        public string ShownText
        {
            get => _shownText;
            set
            {
                _shownText = value;
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
            return !string.IsNullOrWhiteSpace(Person.Name) &&
                   !string.IsNullOrWhiteSpace(Person.Surname) &&
                   !string.IsNullOrWhiteSpace(Person.Email) && 
                   Person.DateOfBirth.HasValue;
        }

        private async void ProceedImplementation(object obj)
        {

            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                int age = Person.Age;
                if (!Person.DateOfBirth.HasValue || age < 0 || age > 135)
                {
                    MessageBox.Show("The entered date is not valid.");
                    return;
                }

                if (Person.IsBirthday)
                {
                    MessageBox.Show("Happy birthday! :D");
                }

                ShownText = $"Your name: {Person.Name}.\n" +
                            $"Your surname: {Person.Surname}.\n" +
                            $"Your email address: {Person.Email}.\n" +
                            $"Your date of birth: {Person.DateOfBirth.Value.ToShortDateString()}.\n" +
                            (Person.IsAdult ? "You are an adult.\n" : "You're not an adult.\n") +
                            (Person.IsBirthday ? "It's your birthday!\n" : "It's not your birthday.\n") +
                            $"Your Sun Sign: {Person.SunSign}.\n" +
                            $"Your Chinese Sign: {Person.ChineseSign}.";
            });
            LoaderManager.Instance.HideLoader();
        }
    }
}
