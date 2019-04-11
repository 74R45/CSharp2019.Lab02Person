using System;
using System.Linq;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools.Exceptions;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Models
{
    [Serializable]
    internal class Person
    {
        #region Fields
        private Guid _guid;
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _dateOfBirth;

        private int _age;
        private bool _isAdult;
        private string _sunSign;
        private string _chineseSign;
        private bool _isBirthday;
        #endregion

        #region Properties

        public Guid Guid
        {
            get => _guid;
            private set => _guid = value;
        }

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public string Surname
        {
            get => _surname;
            private set => _surname = value;
        }

        public string Email
        {
            get => _email;
            private set => _email = value;
        }

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            private set
            {
                _dateOfBirth = value;
                UpdateDateProperties();
            }
        }

        public int Age
        {
            get => _age;
            private set => _age = value;
        }

        public bool IsAdult
        {
            get => _isAdult;
            private set => _isAdult = value;
        }

        public string SunSign
        {
            get => _sunSign;
            private set => _sunSign = value;
        }

        public string ChineseSign
        {
            get => _chineseSign;
            private set => _chineseSign = value;
        }

        public bool IsBirthday
        {
            get => _isBirthday;
            private set => _isBirthday = value;
        }
        #endregion

        #region Constructors
        public Person(string name, string surname, string email, DateTime dateOfBirth)
        {
            _guid = Guid.NewGuid();
            VerifyName(name, "Input name is invalid");
            VerifyName(surname, "Input surname is invalid");
            VerifyEmail(email, "Input email is invalid");
            VerifyDate(dateOfBirth);
            Name = name;
            Surname = surname;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        public Person(string name, string surname, string email)
        {
            _guid = Guid.NewGuid();
            VerifyName(name, "Input name is invalid.");
            VerifyName(surname, "Input surname is invalid.");
            VerifyEmail(email, "Input email is invalid.");
            Name = name;
            Surname = surname;
            Email = email;
            DateOfBirth = DateTime.Today;
        }

        public Person(string name, string surname, DateTime dateOfBirth)
        {
            _guid = Guid.NewGuid();
            VerifyName(name, "Input name is invalid.");
            VerifyName(surname, "Input surname is invalid.");
            VerifyDate(dateOfBirth);
            Name = name;
            Surname = surname;
            Email = "";
            DateOfBirth = dateOfBirth;
        }
        #endregion

        private void UpdateDateProperties()
        {
            Age = YearsDifference(DateOfBirth, DateTime.Now);
            IsAdult = Age >= 18;

            int leap = DateTime.IsLeapYear(DateOfBirth.Year) ? 1 : 0;
            switch (DateOfBirth.DayOfYear)
            {
                case var n when n >= 21 && n <= 50:
                    SunSign = "Aquarius";
                    break;
                case var n when n >= 51 && n <= 79 + leap:
                    SunSign = "Pisces";
                    break;
                case var n when n >= 80 + leap && n <= 110 + leap:
                    SunSign = "Aries";
                    break;
                case var n when n >= 111 + leap && n <= 141 + leap:
                    SunSign = "Taurus";
                    break;
                case var n when n >= 142 + leap && n <= 172 + leap:
                    SunSign = "Gemini";
                    break;
                case var n when n >= 173 + leap && n <= 203 + leap:
                    SunSign = "Cancer";
                    break;
                case var n when n >= 204 + leap && n <= 234 + leap:
                    SunSign = "Leo";
                    break;
                case var n when n >= 235 + leap && n <= 266 + leap:
                    SunSign = "Virgo";
                    break;
                case var n when n >= 267 + leap && n <= 296 + leap:
                    SunSign = "Libra";
                    break;
                case var n when n >= 297 + leap && n <= 326 + leap:
                    SunSign = "Scorpio";
                    break;
                case var n when n >= 327 + leap && n <= 355 + leap:
                    SunSign = "Sagittarius";
                    break;
                case var n when n >= 355 + leap || n <= 20:
                    SunSign = "Capricorn";
                    break;
                default:
                    SunSign = "Error";
                    break;
            }

            string[] chineseZodiacs =
            {"Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox",
                "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat"};
            ChineseSign = chineseZodiacs[DateOfBirth.Year % 12];

            IsBirthday = DateOfBirth.Day == DateTime.Now.Day &&
                         DateOfBirth.Month == DateTime.Now.Month;
        }

        private static int YearsDifference(DateTime start, DateTime end)
        {
            return (end.Year - start.Year - 1) +
                   (((end.Month > start.Month) ||
                    ((end.Month == start.Month) && (end.Day >= start.Day)))
                       ? 1
                       : 0);
        }

        private static void VerifyName(string name, string errorMessage)
        {
            if (!name.All(char.IsLetter))
            {
                throw new NameContainsNonLetterCharactersException(errorMessage, name);
            }
        }

        private static void VerifyEmail(string email, string errorMessage)
        {
            try
            {
                new System.Net.Mail.MailAddress(email);
            }
            catch (FormatException)
            {
                throw new InvalidEmailException(errorMessage, email);
            }
        }

        private static void VerifyDate(DateTime date, string errorMessage = "")
        {
            int age = YearsDifference(date, DateTime.Now);
            if (age < 0)
            {
                if (string.IsNullOrEmpty(errorMessage))
                {
                    throw new BirthDateInTheFutureException(date);
                }
                throw new BirthDateInTheFutureException(errorMessage, date);
            }

            if (age > 135)
            {
                if (string.IsNullOrEmpty(errorMessage))
                {
                    throw new BirthDateTooFarInThePastException(date);
                }
                throw new BirthDateTooFarInThePastException(errorMessage, date);
            }
        }
    }
}