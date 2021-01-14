using AutoMapper;
using EventManagementApi.Entities;
using EventManagementApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementApi.Core.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Location
            CreateMap<LocationViewModel, Location>()
                .ForMember(vm => vm.Id, action => action.Ignore());
            CreateMap<Location, LocationViewModel>();

            // Room
            CreateMap<RoomViewModel, Room>()
                .ForMember(vm => vm.Id, action => action.Ignore());
            CreateMap<Room, RoomViewModel>();

            // Instructor
            CreateMap<InstructorViewModel, Instructor>()
                .ForMember(vm => vm.Id, action => action.Ignore());
            CreateMap<Instructor, InstructorViewModel>();

            // Course
            CreateMap<CourseViewModel, Course>()
                .ForMember(vm => vm.Id, action => action.Ignore());
            CreateMap<Course, CourseViewModel>();

            // Event
            CreateMap<EventViewModel, Event>()
                .ForMember(vm => vm.Id, action => action.Ignore());
            CreateMap<Event, EventViewModel>();

            // Sponsor
            CreateMap<SponsorViewModel, Sponsor>()
                .ForMember(vm => vm.Id, action => action.Ignore());
            CreateMap<Sponsor, SponsorViewModel>();

            // Timeslot
            CreateMap<TimeslotViewModel, Timeslot>()
                .ForMember(vm => vm.Id, action => action.Ignore());
            CreateMap<Timeslot, TimeslotViewModel>();
        }
    }
}
