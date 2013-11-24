using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using ProvenStyle.DemoWebApi.Data;
using ProvenStyle.DemoWebApi.Entities;
using Highway.Data.PrebuiltQueries;

namespace ProvenStyle.DemoWebApi.Controllers
{
    public class InstructorsController : ApiController
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public InstructorsController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public IEnumerable<Instructor> Get()
        {
            List<Instructor> items = null;
            _repositoryFactory.WithRepository(r =>
            {
                items = r.Find(new FindAll<Instructor>()).ToList();
            });

            
            return items;
        }

        public Instructor Get(int id)
        {
            Instructor item = null;
            
            _repositoryFactory.WithRepository(r =>
                {
                    item = r.Find(new GetById<int, Instructor>(id));
                });

            if (item == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return item;
        }

        public int Post([FromBody]Instructor instructor)
        {
            _repositoryFactory.WithRepository(r =>
                {
                    r.Context.Add(instructor);
                    r.Context.Commit();
                });

            return instructor.Id;
        }

        public void Put(int id, [FromBody]Instructor instructor)
        {
            _repositoryFactory.WithRepository(r =>
                {
                    var current = r.Find(new GetById<int, Instructor>(id));
                    if(current == null)
                        throw new HttpResponseException(HttpStatusCode.BadRequest);
                    current.First = instructor.First;
                    current.Last = instructor.Last;
                    current.Email = instructor.Email;
                    current.Phone = instructor.Phone;
                    r.Context.Commit();
                });
        }

        public void Delete(int id)
        {
            _repositoryFactory.WithRepository(r=>r.Execute(new DeleteInstructor(id)));
        }
    }    
}