using AutoMapper;
using Library.Domain.Entities;
using Library.Services.Models;

namespace Library.Services.Profiles
{
    internal class AuthorProfiles : Profile
    {
        public AuthorProfiles()
        {
            CreateMap<AuthorForCreationDTO, Author>();
            CreateMap<Author, AuthorForPresentationDTO>()
                .ForMember(obj => obj.FullName, obj => obj.MapFrom((s) => $"{s.Firstname} {s.Lastname}"))
                .ForMember(obj => obj.Age, obj => obj.MapFrom(s => new DateTime((DateTime.Now - s.DateBorn).Ticks).Year - 1));
        }
    }
}
