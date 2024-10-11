using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksManipulator.Application.DTO;
using TasksManipulator.Domain.Entities;

namespace TasksManipulator.Application.Mappings
{
    public class DTOMappingProfiles : Profile
    {
        public DTOMappingProfiles()
        {
            CreateMap<TasksDTO, Tasks>().ReverseMap();
        }
    }
}
