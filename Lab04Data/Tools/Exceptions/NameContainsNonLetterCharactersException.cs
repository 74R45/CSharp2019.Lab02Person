using System;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools.Exceptions
{
    [Serializable]
    public class NameContainsNonLetterCharactersException : Exception
    {
        public string Name { get; }

        public NameContainsNonLetterCharactersException() { }
        public NameContainsNonLetterCharactersException(string message) : base(message) { }
        public NameContainsNonLetterCharactersException(string message, Exception inner) : base(message, inner) { }
        protected NameContainsNonLetterCharactersException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public NameContainsNonLetterCharactersException(string message, string name) : base(message)
        {
            Name = name;
        }

        public NameContainsNonLetterCharactersException(string message, string name, Exception inner) : base(message, inner)
        {
            Name = name;
        }
    }
}
