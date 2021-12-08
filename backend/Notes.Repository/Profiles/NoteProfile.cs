using AutoMapper;
using Notes.Domain.Models;
using Notes.Repository.Entities;
namespace Notes.Repository.Profiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<NoteEntity, Note>()
                .ForMember(dest => dest.Id, memberOptions: opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.Title, memberOptions: opt => opt.MapFrom(src => src.title))
                .ForMember(dest => dest.Body, memberOptions: opt => opt.MapFrom(src => src.body))
                .ForMember(dest => dest.CreatedDate, memberOptions: opt => opt.MapFrom(src => src.created_date)).ReverseMap();
        }
    }
}
