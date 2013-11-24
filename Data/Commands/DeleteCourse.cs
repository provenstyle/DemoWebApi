using System.Linq;
using Highway.Data;
using ProvenStyle.DemoWebApi.Entities;

// ReSharper disable CheckNamespace
namespace ProvenStyle.DemoWebApi.Data
{
   public class DeleteCourse : Command
   {
      public DeleteCourse(int id)
      {
         ContextQuery = c =>
            {
               var item = c.AsQueryable<Course>().FirstOrDefault(x => x.Id == id);
               if (item == null) return;
               c.Remove(item);
               c.Commit();
            };
      }
   }
}
