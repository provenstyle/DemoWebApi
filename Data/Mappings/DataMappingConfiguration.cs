﻿using System.Data.Entity;
using ProvenStyle.DemoWebApi.Entities;

// ReSharper disable CheckNamespace
namespace ProvenStyle.DemoWebApi.Data
{
    public class DataMappingConfiguration : Highway.Data.IMappingConfiguration
    {
        public void ConfigureModelBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonMapping());
            modelBuilder.Entity<Course>();
        }
    }
}
