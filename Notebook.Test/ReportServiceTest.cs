using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
using Notebook.Application.Services;
using Notebook.Domain.Dto.Report;
using Notebook.Test.Configurations;
using Xunit;

namespace Notebook.Test
{
    public class ReportServiceTest
    {
        [Fact]
        public async Task GetReport_ShouldBe_NotNull()
        {
            // Arrange
            var mockReportRepository = MockRepositoriesGetter.GetMockReportRepository();
            var mockDistributedCache = new Mock<IDistributedCache>();
            var reportService = new ReportService(mockReportRepository.Object, null, null, null, null, null, mockDistributedCache.Object);

            // Act
            var result = await reportService.GetReportByIdAsync(1);

            // Assert
            Assert.NotNull(result);
        }
        
        [Fact]
        public async Task CreateReport_ShouldBe_Return_NewReport()
        {
            // Arrange
            var mockReportRepository = MockRepositoriesGetter.GetMockReportRepository();
            var mockUserRepository = MockRepositoriesGetter.GetMockUserRepository();
            var mockDistributedCache = new Mock<IDistributedCache>();
            var mapper = MapperConfiguration.GetMapperConfiguration();

            var user = MockRepositoriesGetter.GetUsers().FirstOrDefaultAsync();
            var createReportDto = new CreateReportDto("Report #1", "Text for report #1", user.Id);
            var reportService = new ReportService(mockReportRepository.Object, mockUserRepository.Object, null, null, mapper, null, mockDistributedCache.Object);
                
            // Act
            var result = await reportService.CreateReportAsync(createReportDto);
            
            // Assert
            Assert.True(result.IsSuccess);
        }
        
        [Fact]
        public async Task DeleteReport_ShouldBe_Return_TrueSuccess()
        {
            // Arrange
            var mockReportRepository = MockRepositoriesGetter.GetMockReportRepository();
            var mockDistributedCache = new Mock<IDistributedCache>();
            var mapper = MapperConfiguration.GetMapperConfiguration();
            var report = MockRepositoriesGetter.GetReports().FirstOrDefaultAsync();
            var reportService = new ReportService(mockReportRepository.Object, null, null, null, mapper, null, mockDistributedCache.Object);
                
            // Act
            var result = await reportService.DeleteReportAsync(report.Id);
            
            // Assert
            Assert.True(result.IsSuccess);
        }
        
        [Fact]
        public async Task UpdateReport_ShouldBe_Return_NewData_For_Report()
        {
            // Arrange
            var mockReportRepository = MockRepositoriesGetter.GetMockReportRepository();
            var mapper = MapperConfiguration.GetMapperConfiguration();
            var mockDistributedCache = new Mock<IDistributedCache>();
            var report = MockRepositoriesGetter.GetReports().FirstOrDefaultAsync();
            var updateReportDto = new UpdateReportDto(report.Id, "UpdatedReport", "UpdatedDescription");
            
            var reportService = new ReportService(mockReportRepository.Object, null, null, null, mapper, null, mockDistributedCache.Object);
                
            // Act
            var result = await reportService.UpdateReportAsync(updateReportDto);
            
            // Assert
            Assert.True(result.IsSuccess);
        }
    }
}