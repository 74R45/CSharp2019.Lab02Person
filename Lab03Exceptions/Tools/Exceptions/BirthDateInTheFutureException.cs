using System;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab03Exceptions.Tools.Exceptions
{
    [Serializable]
    public class BirthDateInTheFutureException : Exception
    {
        public DateTime DateOfBirth { get; }

        public BirthDateInTheFutureException() { }
        public BirthDateInTheFutureException(string message) : base(message) { }
        public BirthDateInTheFutureException(string message, Exception inner) : base(message, inner) { }
        protected BirthDateInTheFutureException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public BirthDateInTheFutureException(DateTime dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
        }

        public BirthDateInTheFutureException(string message, DateTime dateOfBirth) : base(message)
        {
            DateOfBirth = dateOfBirth;
        }

        public BirthDateInTheFutureException(string message, DateTime dateOfBirth, Exception inner) : base(message, inner)
        {
            DateOfBirth = dateOfBirth;
        }
    }
}