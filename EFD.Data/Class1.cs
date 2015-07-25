using EFD.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFD.Data
{
    //this is kinda like the concept of a database, but it doesn't have to be
    public class EFDContext:DbContext  
    {
        //this is kinda like the concept of a database table, but it doesn't have to be
        public DbSet<Person> People { get; set; }
    }
}
namespace EFD.Entity
{
    public class Person
    {
        public Person()
        {
            //its a decent thing to do, to initialize things in the contructor, but if its a virtual method problems can occur
            Addresses = new List<Address>();
        }

        //all entities need an Id field called "Id" or Type + "Id" or use the Key attribute
        [Key]
        public int Id { get; set; } // PersonId
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //virtual is used for something having to do with lazy loading
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual PersonDetail PersonDetail { get; set; }
    }

    public class Employee:Person
    {
        public readonly bool IsGood = false;
        public Employee()
        {
            IsGood = true;
        }

        //public override ICollection<Address> Addresses
        //{
        //    get { return null; }
        //    set
        //    {
        //        if(!IsGood)
        //            throw new Exception("whoops, virtual calls in contructors aren't good!!!");

        //    }
        //}
    }

    public class Address
    {
        public int Id { get; set; }
        public virtual Person Person { get; set; }
        public int PersonId { get; set; }
        public string Street { get; set; }
    }
    //this is a one to zero/one one relationsship, you have to define which is the parent object and where the foriegn key goes
    public class PersonDetail
    {
        [Key,ForeignKey("Person")] //this needs to be the name of the Property that has the parent object, which in this case is named the same as the Type
        public int PersonId
        {
            get; set;
            
        }
        public int Id { get; set; }
        public Person Person { get; set; }

    }


}
