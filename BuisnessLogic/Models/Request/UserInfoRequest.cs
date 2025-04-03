using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace BuisnessLogic.Models.Request
{
    public class UserInfoRequest 
    {
        public int Id { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Patronymic { get; set; }
        public string? Name { get; set; }
        public string? Salt { get; set; }
        public string? PasswordHash { get; set; }
        public string? ScoutGroup { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Institute { get; set; }
        public bool? IsAdmin { get; set; }
        public static implicit operator User(UserInfoRequest user)
        {
            User? model = null;
            var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<UserInfoRequest, User>()
              .ForMember(nameof(model.Email), opt => opt.MapFrom(x => x.Email))
              .ForMember(nameof(model.Name), opt => opt.MapFrom(x => x.Name))
              .ForMember(nameof(model.PasswordHash), opt => opt.MapFrom(x => x.PasswordHash))
              .ForMember(nameof(model.Salt), opt => opt.MapFrom(x => x.Salt))
              .ForMember(nameof(model.Surname), opt => opt.MapFrom(x => x.Surname))
              .ForMember(nameof(model.Patronymic), opt => opt.MapFrom(x => x.Patronymic))
              .ForMember(nameof(model.Id), opt => opt.MapFrom(x => x.Id))
              .ForMember(nameof(model.ScoutGroup), opt => opt.MapFrom(x => x.ScoutGroup))
              .ForMember(nameof(model.PhoneNumber), opt => opt.MapFrom(x => x.PhoneNumber))
              .ForMember(nameof(model.Institute), opt => opt.MapFrom(x => x.Institute))
            ));
            model = mapper.Map<User>(user);
            return model;
        }
    }
}
