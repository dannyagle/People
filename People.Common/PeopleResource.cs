using Newtonsoft.Json;
using People.Common.Interfaces;
using People.Common.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace People.Common
{
    public class PeopleResource : IPeopleResource
    {
        private List<FamilyName> _familyNames = new List<FamilyName>();
        private List<GivenName> _maleNames = new List<GivenName>();
        private List<GivenName> _femaleNames = new List<GivenName>();

        private TextInfo _textInfo = null;
        private static readonly Random _random = new Random();

        public PeopleResource()
        {
            LoadData();
            _textInfo = new CultureInfo("en-US").TextInfo;
        }

        public Person GetPerson(Gender gender, string familyName)
        {
            var person = new Person();

            if (gender == Gender.Any || gender == Gender.Unknown)
                gender = (Gender)_random.Next(0, 2) + 1;

            person.LastName = !string.IsNullOrEmpty(familyName) 
                ? familyName 
                : GetFamilyName();

            switch (gender)
            {
                case Gender.Female:
                    person.FirstName = GetFemaleName();
                    person.Gender = Gender.Female;
                    break;

                case Gender.Male:
                    person.FirstName = GetMaleName();
                    person.Gender = Gender.Male;
                    break;

                default:
                    break;
            }

            return person;
        }

        private void LoadData()
        {
            using (StreamReader reader = new StreamReader(new FileStream("family.json", FileMode.Open)))
            {
                string json = reader.ReadToEnd();
                _familyNames = JsonConvert.DeserializeObject<List<FamilyName>>(json);
            }

            using (StreamReader reader = new StreamReader(new FileStream("female.json", FileMode.Open)))
            {
                string json = reader.ReadToEnd();
                _femaleNames = JsonConvert.DeserializeObject<List<GivenName>>(json);
            }

            using (StreamReader reader = new StreamReader(new FileStream("male.json", FileMode.Open)))
            {
                string json = reader.ReadToEnd();
                _maleNames = JsonConvert.DeserializeObject<List<GivenName>>(json);
            }
        }

        private string GetFemaleName()
        {
            return _textInfo.ToTitleCase(_femaleNames[_random.Next(1, _femaleNames.Count) - 1].Name.ToLower());
        }

        private string GetMaleName()
        {
            return _textInfo.ToTitleCase(_maleNames[_random.Next(1, _maleNames.Count) - 1].Name.ToLower());
        }

        private string GetFamilyName()
        {
            return _textInfo.ToTitleCase(_familyNames[_random.Next(1, _familyNames.Count) - 1].Name.ToLower());
        }

    }
}
