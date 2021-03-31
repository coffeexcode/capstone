using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Core.Exceptions
{
    public class AddEntityException : Exception
    {
        public AddEntityException(Type type, string id) :
            base($"Unable to add entity of type {type} with ID {id}")
        {

        }
    }
}
