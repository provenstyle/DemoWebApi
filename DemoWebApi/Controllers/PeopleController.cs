using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoWebApi.Controllers
{
    public class PeopleController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Person> Get()
        {
            return new List<Person>
                       {
                           new Person{Id = 1, First = "Brenna", Last = "Dudley"},
                           new Person{Id = 2, First = "Abigail", Last = "Dudley"},
                           new Person{Id = 3, First = "Emma", Last = "Dudley"}
                       };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string DoesThisCaseWell { get; set; }
    }
}