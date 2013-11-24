using System.Linq;
using Highway.Data;
using ProvenStyle.DemoWebApi.Entities;

// ReSharper disable CheckNamespace
namespace ProvenStyle.DemoWebApi.Data
{
   public class DeleteInstructor : Command
   {
      public DeleteInstructor(int id)
      {
         ContextQuery = c =>
            {
               var item = c.AsQueryable<Instructor>().FirstOrDefault(x => x.Id == id);
               if (item == null) return;
               c.Remove(item);
               c.Commit();
            };
      }
   }
}
