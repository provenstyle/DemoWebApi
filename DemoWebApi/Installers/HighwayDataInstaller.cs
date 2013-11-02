// [[Highway.Onramp.MVC.Data]]
// Copyright 2013 Timothy J. Rayburn
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using Highway.Data.EventManagement;
using Highway.Data;
using System.Data.Entity;
using ProvenStyle.DemoWebApi.Config;
using ProvenStyle.DemoWebApi.Data;

namespace ProvenStyle.DemoWebApi.Installers
{
    // TODO Change the connection string to match your environment.
    public class HighwayDataInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var manager = new DatabaseManager("DataLayer");

            container.Register(
                Component.For<IMappingConfiguration>().ImplementedBy<DataMappingConfiguration>().LifeStyle.Singleton,
                Component.For<IDataContext>().ImplementedBy<DataContext>().DependsOn(new { connectionString = manager.ConnectionString }).LifeStyle.PerWebRequest,
                Component.For<IRepository>().ImplementedBy<Repository>().LifeStyle.PerWebRequest,
                Component.For<IRepositoryFactory>().ImplementedBy<RepositoryFactory>(),


                Component.For<IEventManager>().ImplementedBy<EventManager>()
                    .LifestyleSingleton(),
                
                Component.For<IDatabaseInitializer<HighwayDataContext>>().ImplementedBy<HighwayDatabaseInitializer>()
                    .LifestyleSingleton(),
                Component.For<IContextConfiguration>().ImplementedBy<HighwayContextConfiguration>()
                    .LifestyleSingleton()
            );

        }
    }
}
