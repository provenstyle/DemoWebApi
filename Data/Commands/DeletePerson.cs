using System.Linq;
using Highway.Data;
using ProvenStyle.DemoWebApi.Entities;

// ReSharper disable CheckNamespace
namespace ProvenStyle.DemoWebApi.Data
{
   public class DeletePerson : Command
   {
      public DeletePerson(int id)
      {
         ContextQuery = c =>
            {
               var person = c.AsQueryable<Person>().FirstOrDefault(x => x.Id == id);
               if (person == null) return;
               c.Remove(person);
               c.Commit();
            };
      }
   }
}
