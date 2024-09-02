using AutoMapper;
using Notebook.Domain.Dto.Report;
using Notebook.Domain.Entity;

namespace Notebook.Application.Mapping
{
    public class ReportMapping : Profile
    {
        public ReportMapping()
        {
            CreateMap<Report, ReportDto>().ReverseMap();
        }
    }
}