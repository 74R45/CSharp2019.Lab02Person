using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Models;
using KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools.Managers;
using RandomNameGeneratorLibrary;

namespace KMA.ProgrammingInCSharp2019.Kreshchenko.Part2.Lab04Data.Tools.DataStorage
{
    internal class SerializedDataStorage
    {
        private readonly List<Person> _people;
        private readonly PersonNameGenerator _nameGen;
        private readonly Random _dateGen;

        internal SerializedDataStorage()
        {
            _nameGen = new PersonNameGenerator();
            _dateGen = new Random();
            try
            {
                _people = SerializationManager.Deserialize<List<Person>>(FileFolderHelper.StorageFilePath);
            }
            catch (FileNotFoundException)
            {
                _people = new List<Person>();
                InitializePeople();
            }
        }

        internal void AddPerson(Person person)
        {
            _people.Add(person);
            SaveChanges();
        }

        internal void AddRandomPerson()
        {
            _people.Add(GenerateRandomPerson());
            SaveChanges();
        }

        internal void SetPerson(Person person, int index)
        {
            _people[index] = person;
            SaveChanges();
        }

        internal void DeletePerson(Person person)
        {
            _people.Remove(person);
            SaveChanges();
        }

        internal void InitializePeople()
        {
            for (int i = 0; i < 50; i++)
            {
                try
                {
                    _people.Add(GenerateRandomPerson());
                }
                catch
                {
                    // I'm sure my random person generator is correct, but I don't trust myself,
                    // so in case of something going wrong, the program is just gonna skip
                    // this current generated Person and create a new one instead.
                    i--;
                }
            }
            SaveChanges();
        }

        private Person GenerateRandomPerson()
        {
            // Install RandomNameGeneratorLibrary namespace from NuGet to get this to work.
            string name = _nameGen.GenerateRandomFirstName();
            string surname = _nameGen.GenerateRandomLastName();
            string email = name.ToLower().Substring(0, 1) +
                           '.' + surname.ToLower() + "@gmail.com";
            long minDate = DateTime.Now.Subtract(new DateTime(134, 12, 31)).Ticks;
            long maxDate = DateTime.Now.Ticks;
            DateTime dateOfBirth = new DateTime(LongRandom(minDate, maxDate, _dateGen));
            return new Person(name, surname, email, dateOfBirth);
        }

        private long LongRandom(long min, long max, Random rand)
        {
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % (max - min)) + min);
        }

        internal List<Person> PeopleList => _people.ToList();

        private void SaveChanges()
        {
            SerializationManager.Serialize(_people, FileFolderHelper.StorageFilePath);
        }
    }
}