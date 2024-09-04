using AutoMapper;
using Notebook.Domain.Dto.Report;
using Notebook.Domain.Entity;

namespace Notebook.Application.Mapping
{
    public class ReportMapping : Profile
    {
        public ReportMapping()
        {
            CreateMap<Report, ReportDto>()
                .ForCtorParam(ctorParamName:"Id", m=>m.MapFrom(s=>s.Id))
                .ForCtorParam(ctorParamName:"Title", m=>m.MapFrom(s=>s.Title))
                .ForCtorParam(ctorParamName:"Description", m=>m.MapFrom(s=>s.Description))
                .ForCtorParam(ctorParamName:"DateCreated", m=>m.MapFrom(s=>s.CreatedAt))
                .ReverseMap();
        }
    }
}