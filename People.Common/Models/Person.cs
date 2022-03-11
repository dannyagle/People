using System;

namespace People.Common.Models;

public record Person(Guid Id, string FirstName, string LastName, Gender Gender);
//public class Person
//{
//    public Person()
//    {
//        Id = Guid.NewGuid();
//    }

//    public Guid Id { get; set; }
//    public string FirstName { get; set; }
//    public string LastName { get; set; }
//    public Gender Gender { get; set; }

//    public string FullName { get { return $"{this.FirstName} {this.LastName}"; }  }
//    public string FullNameReverse { get { return $"{this.LastName}, {this.FirstName}"; }  }

//}
