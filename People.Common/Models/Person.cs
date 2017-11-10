using System;
using System.Collections.Generic;
using System.Text;

namespace People.Common.Models
{
    public class Person
    {
        public Person()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }

        public string FullName { get { return $"{this.FirstName} {this.LastName}"; }  }
        public string FullNameReverse { get { return $"{this.LastName}, {this.FirstName}"; }  }

    }
}
