using AttendanceAPI.Entities;
using AttendanceAPI.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceAPI.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AttendanceRecordViewModel, AttendanceRecord>();
        }
    }
}
