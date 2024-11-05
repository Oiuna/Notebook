using AutoMapper;
using Notebook.Application.Mapping;

namespace Notebook.Test.Configurations
{
    public static class MapperConfiguration
    {
        public static IMapper GetMapperConfiguration()
        {
            var mockMapper = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ReportMapping());
            });
            return mockMapper.CreateMapper();
        }
    }
}