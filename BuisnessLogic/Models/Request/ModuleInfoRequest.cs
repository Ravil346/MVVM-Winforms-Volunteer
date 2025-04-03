using AutoMapper;
using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuisnessLogic.Models.Request
{
    public class ModuleInfoRequest :ModuleOnUserInfo
    {
        public int Id { get; set; }
        public List<Aim>? TestTasks { get; set; }
        public bool IsActive { get; set; }
        public List<Aim>? TheoreticalTasks { get; set; }
        public static implicit operator Module(ModuleInfoRequest module)
        {
            Module? model = null;
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<ModuleInfoRequest, Module>()
              .ForMember(nameof(model.TasksTheoretical), opt => opt.MapFrom(x => x.TheoreticalTasks))
              .ForMember(nameof(model.TasksTest), opt => opt.MapFrom(x => x.TestTasks))
              .ForMember(nameof(model.Name), opt => opt.MapFrom(x => x.Name))
              .ForMember(nameof(model.Id), opt => opt.MapFrom(x => x.Id))
              .ForMember(nameof(model.Type), opt => opt.MapFrom(x => x.TypeModule))
              .ForMember(nameof(model.IsActive), opt => opt.MapFrom(x => x.IsActive))
            ));
            model = mapper.Map<Module>(module);
            return model;
        }
    }
       
}
