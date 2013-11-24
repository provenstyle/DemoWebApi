using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProvenStyle.DemoWebApi.Entities;

namespace ProvenStyle.DemoWebApi.Data
{
    public class CourseMapping : EntityTypeConfiguration<Course>
    {
        public CourseMapping()
        {
            ToTable("Course");
            HasKey(x => x.Id);
        }
    }
}
