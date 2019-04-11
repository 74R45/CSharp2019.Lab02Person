using System;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools.Exceptions
{
    [Serializable]
    public class BirthDateTooFarInThePastException : Exception
    {
        public DateTime DateOfBirth { get; }

        public BirthDateTooFarInThePastException() { }
        public BirthDateTooFarInThePastException(string message) : base(message) { }
        public BirthDateTooFarInThePastException(string message, Exception inner) : base(message, inner) { }
        protected BirthDateTooFarInThePastException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public BirthDateTooFarInThePastException(DateTime dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
        }

        public BirthDateTooFarInThePastException(string message, DateTime dateOfBirth) : base(message)
        {
            DateOfBirth = dateOfBirth;
        }

        public BirthDateTooFarInThePastException(string message, DateTime dateOfBirth, Exception inner) : base(message, inner)
        {
            DateOfBirth = dateOfBirth;
        }
    }
}
