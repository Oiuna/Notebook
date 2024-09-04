using AutoMapper;
using Notebook.Domain.Dto.User;
using Notebook.Domain.Entity;

namespace Notebook.Application.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}