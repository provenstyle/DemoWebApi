// [[Highway.Onramp.MVC]]
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
using System.Web.Mvc;

namespace $rootnamespace$.Services
{
    public class IoCFilterProvider : IFilterProvider
    {
        private readonly IEnumerable<Func<ControllerContext, ActionDescriptor, Filter>> registeredFilters;

        public IoCFilterProvider(Func<ControllerContext, ActionDescriptor, Filter>[] registeredFilters)
        {
            this.registeredFilters = registeredFilters;
        }

        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            return registeredFilters.Select(m => m.Invoke(controllerContext, actionDescriptor)).Where(m => m != null);
        }
    }
}
