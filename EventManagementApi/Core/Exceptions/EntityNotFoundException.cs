using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Core.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Type t, string id):
            base($"An entity of {t} was not found with ID: {id}")
        {

        }
    }
}
