using AutoMapper;
using DM = Notes.Domain.Models;
using VM = Notes.WebAPI.Contracts;

namespace Notes.WebAPI.Profiles
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<VM.Note, DM.Note>();

            CreateMap<VM.NoteUpdateRequest, DM.NoteUpdateData>();

            CreateMap<VM.NoteCreateRequest, DM.NoteCreateData>();
        }
    }
}
