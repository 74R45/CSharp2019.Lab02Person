using System;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab03Exceptions.Tools.Exceptions
{
    [Serializable]
    public class InvalidEmailException : Exception
    {
        public string Email { get; }

        public InvalidEmailException() { }
        public InvalidEmailException(string message) : base(message) { }
        public InvalidEmailException(string message, Exception inner) : base(message, inner) { }
        protected InvalidEmailException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public InvalidEmailException(string message, string email) : base(message)
        {
            Email = email;
        }

        public InvalidEmailException(string message, string email, Exception inner) : base(message, inner)
        {
            Email = email;
        }
    }
}
