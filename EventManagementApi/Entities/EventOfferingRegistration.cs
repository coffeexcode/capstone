using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Entities
{
    public class EventOfferingRegistration
    {
        public string Id { get; set; }

        public EventOffering EventOffering { get; set; }

        public string EventOfferingId { get; set; }

        public string UserId { get; set; }
    }
}
