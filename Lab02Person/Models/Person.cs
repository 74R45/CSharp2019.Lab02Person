using System;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab02Person.Tools;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab02Person.Models
{
    internal class Person : BaseNotifyProperty
    {
        #region Fields
        private string _name;
        private string _surname;
        private string _email;
        private DateTime? _dateOfBirth;
        #endregion

        #region Properties
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
        #endregion

        #region Constructors
        public Person(string name, string surname, string email, DateTime dateOfBirth)
        {
            Name = name;
            Surname = surname;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        public Person(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public Person(string name, string surname, DateTime dateOfBirth)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
        }
        #endregion

        #region Readonly Properties
        public int Age => !DateOfBirth.HasValue ? -1 : Years(DateOfBirth.Value, DateTime.Now);

        public bool IsAdult => Age >= 18;

        public string SunSign
        {
            get
            {
                if (!DateOfBirth.HasValue)
                {
                    return "Error";
                }
                
                int leap = DateTime.IsLeapYear(DateOfBirth.Value.Year) ? 1 : 0;
                switch (DateOfBirth.Value.DayOfYear)
                {
                    case var n when n >= 21 && n <= 50:
                        return "Aquarius";
                    case var n when n >= 51 && n <= 79 + leap:
                        return "Pisces";
                    case var n when n >= 80 + leap && n <= 110 + leap:
                        return "Aries";
                    case var n when n >= 111 + leap && n <= 141 + leap:
                        return "Taurus";
                    case var n when n >= 142 + leap && n <= 172 + leap:
                        return "Gemini";
                    case var n when n >= 173 + leap && n <= 203 + leap:
                        return "Cancer";
                    case var n when n >= 204 + leap && n <= 234 + leap:
                        return "Leo";
                    case var n when n >= 235 + leap && n <= 266 + leap:
                        return "Virgo";
                    case var n when n >= 267 + leap && n <= 296 + leap:
                        return "Libra";
                    case var n when n >= 297 + leap && n <= 326 + leap:
                        return "Scorpio";
                    case var n when n >= 327 + leap && n <= 355 + leap:
                        return "Sagittarius";
                    case var n when n >= 355 + leap || n <= 20:
                        return "Capricorn";
                    default:
                        return "Error";
                }
            }
        }

        public string ChineseSign
        {
            get
            {
                if (!DateOfBirth.HasValue)
                {
                    return "Error";
                }

                string[] chineseZodiacs =
                    {"Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox",
                     "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat"};
                return chineseZodiacs[DateOfBirth.Value.Year % 12];
            }
        }

        public bool IsBirthday =>
            DateOfBirth.HasValue && DateOfBirth.Value.Day == DateTime.Now.Day &&
            DateOfBirth.Value.Month == DateTime.Now.Month;
        #endregion

        private static int Years(DateTime start, DateTime end)
        {
            return (end.Year - start.Year - 1) +
                   (((end.Month > start.Month) ||
                     ((end.Month == start.Month) && (end.Day >= start.Day)))
                       ? 1
                       : 0);
        }
    }
}
