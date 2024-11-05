using AutoMapper;
using Notebook.Domain.Dto.Role;
using Notebook.Domain.Entity;

namespace Notebook.Application.Mapping
{
    public class RoleMapping : Profile
    {
        public RoleMapping()
        {
            CreateMap<Role, RoleDto>().ReverseMap();
        }
    }
}