using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace People.Manager
{
    public class PeopleResource : IPeopleResource
    {
        public List<Family> _family = new List<Family>();
        public List<Female> _female = new List<Female>();
        public List<Male> _male = new List<Male>();

        private TextInfo _textInfo = null;
        private static readonly Random _random = new Random();

        public PeopleResource()
        {
            this.Load();
            _textInfo = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo;
        }

        #region Interface Members

        public Person GetPerson()
        {
            return GetPerson(Gender.Unknown, string.Empty);
        }

        public Person GetPerson(string familyName)
        {
            return GetPerson(Gender.Unknown, familyName);
        }

        public Person GetPerson(Gender gender)
        {
            return GetPerson(gender, string.Empty);
        }

        public Person GetPerson(Gender gender, string familyName)
        {
            var retval = new Person();

            switch (gender)
            {
                case Gender.Female:
                    retval.IsMale = false;
                    retval.FirstName = GetFemaleName();
                    break;
                case Gender.Male:
                    retval.IsMale = true;
                    retval.FirstName = GetMaleName();
                    break;
                default:
                    retval.IsMale = _random.Next(0, 2) != 0;
                    retval.FirstName = retval.IsMale ? GetMaleName() : GetFemaleName();
                    break;
            }

            retval.LastName = !string.IsNullOrEmpty(familyName) ? familyName : GetFamilyName();

            return retval;
        }

        public List<Person> GetPersons(int quantity)
        {
            return GetPersons(quantity, Gender.Unknown, string.Empty);
        }

        public List<Person> GetPersons(int quantity, Gender gender)
        {
            return GetPersons(quantity, gender, string.Empty);
        }

        public List<Person> GetPersons(int quantity, Gender gender, string familyName)
        {
            var people = new ConcurrentBag<Person>();
            Parallel.For(0, quantity, p => 
            {
                people.Add(GetPerson(gender, familyName));
            });

            return people.ToList();
        }

        #endregion


        private void Load()
        {
            using (StreamReader readerFamily = new StreamReader("family.json"))
            {
                string jsonFamily = readerFamily.ReadToEnd();
                _family = JsonConvert.DeserializeObject<List<Family>>(jsonFamily);
            }

            using (StreamReader readerFemale = new StreamReader("female.json"))
            {
                string jsonFemale = readerFemale.ReadToEnd();
                _female = JsonConvert.DeserializeObject<List<Female>>(jsonFemale);
            }

            using (StreamReader readerMale = new StreamReader("male.json"))
            {
                string jsonMale = readerMale.ReadToEnd();
                _male = JsonConvert.DeserializeObject<List<Male>>(jsonMale);
            }

        }


        private string GetFemaleName()
        {
            return _textInfo.ToTitleCase(_female[_random.Next(1, _female.Count) - 1].Name.ToLower()).Trim();
        }

        private string GetMaleName()
        {
            return _textInfo.ToTitleCase(_male[_random.Next(1, _male.Count) - 1].Name.ToLower()).Trim();
        }

        private string GetFamilyName()
        {
            return _textInfo.ToTitleCase(_family[_random.Next(1, _family.Count) - 1].Name.ToLower()).Trim();
        }

    }
}
