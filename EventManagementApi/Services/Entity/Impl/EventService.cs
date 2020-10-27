using AutoMapper;
using EventManagementApi.Core.Exceptions;
using EventManagementApi.Entities;
using EventManagementApi.Repositories;
using EventManagementApi.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Services.Entity.Impl
{
    public class EventService : IEventService
    {
        private readonly ILogger<EventService> logger;
        private readonly EventManagementDbContext context;
        private readonly IEventRepository repository;
        private readonly IRoomRepository roomRepository;
        private readonly IMapper mapper;

        public EventService(
            ILogger<EventService> logger,
            EventManagementDbContext context,
            IEventRepository repository,
            IRoomRepository roomRepository,
            IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.repository = repository;
            this.roomRepository = roomRepository;
            this.mapper = mapper;
        }
        public async Task<Event> CreateEventAsync(EventViewModel model)
        {
            try
            {
                await CheckRoomExists(model.RoomId);

                var @event = mapper.Map<Event>(model);

                var created = await repository.CreateEventAsync(@event);

                return await SaveAndReturn(created);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task DeleteEventAsync(string eventId)
        {
            try
            {
                await repository.DeleteEventAsync(eventId);

                await SaveAndReturn(null);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Event> GetEventByIdAsync(string eventId)
        {
            try
            {
                var @event = await repository.GetEventByIdAsync(eventId);

                return @event;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IList<Event>> GetEventsAsync()
        {
            try
            {
                return await repository.GetEventsAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Event> UpdateEventAsync(string eventId, JsonPatchDocument<EventViewModel> patchDocument)
        {
            try
            {
                var toUpdate = await repository.GetEventByIdAsync(eventId);

                if (toUpdate == null)
                {
                    throw new EntityNotFoundException(typeof(Event), eventId);
                }

                var originalRoomId = toUpdate.RoomId;

                // Apply patch
                var updatedModel = mapper.Map<EventViewModel>(toUpdate);
                patchDocument.ApplyTo(updatedModel);

                // Check if the roomId changed
                // If so, check the new room exists
                if (updatedModel.RoomId != originalRoomId)
                {
                    await CheckRoomExists(updatedModel.RoomId);
                }

                var updatedEvent = mapper.Map<Event>(updatedModel);
                updatedEvent.Id = eventId;

                // Apply changes
                var updated = await repository.UpdateEventAsync(eventId, updatedEvent);

                return await SaveAndReturn(updated);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task<bool> CheckRoomExists(string roomId)
        {
            var exists = (await roomRepository.GetRoomByIdAsync(roomId)) != null;

            if (exists)
            {
                return true;
            }
            else throw new EntityNotFoundException(typeof(Location), roomId);
        }

        private async Task<Event> SaveAndReturn(Event @event)
        {
            await context.SaveChangesAsync();

            return @event;
        }
    }
}
