﻿using System.Data.Entity.Infrastructure;
using ProvenStyle.DemoWebApi.Data;

namespace ProvenStyle.DemoWebApi.DataMigrations
{
    public class DataContextFactory : IDbContextFactory<MigrationsDataContext>
    {
        public MigrationsDataContext Create()
        {
            var manager = new DatabaseManager("DataLayer");           
            var mappingConfigruation = new DataMappingConfiguration();
            var dataContext = new MigrationsDataContext(manager.ConnectionString, mappingConfigruation);
            return dataContext;
        }
    }
}
