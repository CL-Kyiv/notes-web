using AutoMapper;
using DM = Notes.Domain.Models;
using VM = Notes.WebAPI.Contracts;

namespace Notes.WebAPI.Profiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<VM.Note, DM.Note>().ReverseMap();

            CreateMap<VM.NoteUpdateRequest, DM.NoteUpdateRequest>().ReverseMap();

            CreateMap<VM.NoteCreateRequest, DM.NoteCreateRequest>().ReverseMap();
        }
    }
}
