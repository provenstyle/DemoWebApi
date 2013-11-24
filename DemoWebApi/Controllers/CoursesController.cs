using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using ProvenStyle.DemoWebApi.Data;
using ProvenStyle.DemoWebApi.Entities;
using Highway.Data.PrebuiltQueries;

namespace ProvenStyle.DemoWebApi.Controllers
{
    public class CoursesController : ApiController
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public CoursesController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public IEnumerable<Course> Get()
        {
            List<Course> courses = null;
            _repositoryFactory.WithRepository(r =>
            {
                courses = r.Find(new FindAll<Course>())
                    .OrderBy(x=>x.Name)
                    .ToList();
            });

            return courses;
        }

        public Course Get(int id)
        {
            Course course = null;

            _repositoryFactory.WithRepository(r =>
            {
                course = r.Find(new GetById<int, Course>(id));
            });

            if (course == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return course;
        }

        public int Post([FromBody]Course course)
        {
            _repositoryFactory.WithRepository(r =>
            {
                r.Context.Add(course);
                r.Context.Commit();
            });

            return course.Id;
        }

        public void Put(int id, [FromBody]Course course)
        {
            _repositoryFactory.WithRepository(r =>
            {
                var current = r.Find(new GetById<int, Course>(course.Id));
                if (current == null)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                current.Name = course.Name;
                current.Description = course.Description;
                r.Context.Commit();
            });
        }

        public void Delete(int id)
        {
            _repositoryFactory.WithRepository(r => r.Execute(new DeleteCourse(id)));
        }
    }
}