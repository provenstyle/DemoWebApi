using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using ProvenStyle.DemoWebApi.Data;
using ProvenStyle.DemoWebApi.Entities;

namespace ProvenStyle.DemoWebApi.Controllers
{
    public class PeopleController : ApiController
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public PeopleController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public IEnumerable<Person> Get()
        {
            List<Person> people = null;
            _repositoryFactory.WithRepository(r =>
            {
                people = r.Find(new AllPeople()).ToList();
            });

            
            return people;
        }

        public Person Get(int id)
        {
            Person person = null;
            
            _repositoryFactory.WithRepository(r =>
                {
                    person = r.Find(new PersonById(id));
                });

            if (person == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return person;
        }

        public int Post([FromBody]Person person)
        {
            _repositoryFactory.WithRepository(r =>
                {
                    r.Context.Add(person);
                    r.Context.Commit();
                });

            return person.Id;
        }

        public void Put(int id, [FromBody]Person person)
        {
            _repositoryFactory.WithRepository(r =>
                {
                    var current = r.Find(new PersonById(id));
                    if(current == null)
                        throw new HttpResponseException(HttpStatusCode.BadRequest);
                    current.First = person.First;
                    current.Last = person.Last;
                    r.Context.Commit();
                });
        }

        public void Delete(int id)
        {
            _repositoryFactory.WithRepository(r=>r.Execute(new DeletePerson(id)));
        }
    }    
}