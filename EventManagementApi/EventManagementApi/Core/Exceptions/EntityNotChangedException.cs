using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Core.Exceptions
{
    public class EntityNotChangedException : Exception
    {
        public EntityNotChangedException(Type type, string id) :
            base($"Entity state was not affected as expected when saving {type} with ID {id}")
        {

        }
    }
}
