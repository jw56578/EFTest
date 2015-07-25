using EFD.Data;
using EFD.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    /// <summary>
    /// I don't know why I am not seeing the select statements for the address in sql profiler but the data is being retrieved because it exist at runtime
    /// in the address collection
    /// I cannot find any way to make the actual query not retrieve any Child type collections if you use the exact parent type
    /// but if you convert it into a DTO or anonymouse type then it only retrieves only the stuff you want, but i can't see the profiler so i'm not sure
    /// </summary>
    public partial class Program
    {
        
        public static void GetParentObjectOnlyByWhere()
        {
            using (var context = new EFDContext())
            {
                var people = context.People.Where((p => p.LastName == "Rogden"));
                var theactualthings = people.Select(x=>new {FirstName= x.FirstName}).ToList();

            }
        }


        //get a parent object with Find. This object should have a child object property that we don't want retrieved
        //I don't see anything in sql profiler retrieving anything about the Address collection
        public static void GetParentObjectOnlyByFind()
        {
            using (var context = new EFDContext())
            {
                var people = context.People.Find(7);

            }
        }

    }
}
