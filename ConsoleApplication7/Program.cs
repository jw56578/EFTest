using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFD.Data;
using EFD.Entity;
using HibernatingRhinos.Profiler.Appender.EntityFramework;

namespace ConsoleApplication7
{
    class Program
    {
        //install entity framework power tools so that you can right click on any class file and create a model schema from it
        //when any EF code gets run as in GetPeople, it will automatically create the database and tables
        //to find the DB in the explorer of visual studio:
        //click Add Sql Server and enter (localdb)\mssqllocaldb
        //thee database will be named by default as the namespace of your context class, Whatever.Whatever1.SomethingContext
        //there may be several random databases and instances so don't get confused
        static void Main(string[] args)
        {
           //EntityFrameworkProfiler.Initialize();
            var emp = new Employee();
            //InsertPerson();
            //UpdatePerson();
            //GetPeople();
           // CreateObjectGraph();
            GetParentObjectOnlyByFind();
            Console.ReadLine();
        }

        public static void GetParentObjectOnlyByWhere()
        {
            using (var context = new EFDContext())
            {
                var people = context.People.Find(6);

            }
        }


        //get a parent object with Find. This object should have a child object property that we don't want retrieved
        //I don't see anything in sql profiler retrieving anything about the Address collection
        public static void GetParentObjectOnlyByFind()
        {
            using (var context = new EFDContext())
            {
                var people = context.People.Find(6);

            }
        }

        //create new parent object and new children objects
        public static void CreateObjectGraph()
        {
            using (var context = new EFDContext())
            {
                var p = new Person() {FirstName = "Bob", LastName = "Rogden"};
                p.Addresses.Add((new Address(){Street = "main street"}));
                //do you have to specify the person id or Person peroperty on the address or will it just work?
                //COOL, it just works
                context.People.Add(p);
                context.SaveChanges();
            }

        }

        public static void UpdatePerson()
        {
            using (var context = new EFDContext())
            {
                var per = context.People.FirstOrDefault();
                per.LastName = DateTime.Now.ToString();
                context.SaveChanges();
            }

        }
        public static void InsertPerson()
        {
            using (var context = new EFDContext())
            {
                context.People.Add(new Person() {FirstName = "Bob", LastName = "Rogden"});
                context.SaveChanges();
            }

        }

        public static void GetPeople()
        {
            using (var context = new EFDContext())
            {
                var people = context.People.ToList();
                foreach (var person in people)
                {
                    Console.WriteLine(person.FirstName + " " + person.LastName);
                }
            }
        }
    }
}
