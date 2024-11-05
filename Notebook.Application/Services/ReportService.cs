using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Notebook.Application.Resources;
using Notebook.Domain.Dto;
using Notebook.Domain.Dto.Report;
using Notebook.Domain.Entity;
using Notebook.Domain.Enum;
using Notebook.Domain.Extensions;
using Notebook.Domain.Interfaces.Repositories;
using Notebook.Domain.Interfaces.Services;
using Notebook.Domain.Interfaces.Validations;
using Notebook.Domain.Result;
using Notebook.Domain.Settings;
using Notebook.Producer.Interfaces;
using Serilog;

namespace Notebook.Application.Services
{
    public class ReportService: IReportService
    {
        private readonly IBaseRepository<Report> _reportRepository;
        private readonly IBaseRepository<User> _userRepository;
        private readonly IReportValidator _reportValidator;
        //private readonly IMessageProducer _messageProducer;
        private readonly IOptions<RabbitMqSettings> _rabbitMqOptions;
        private readonly IDistributedCache _distributedCache;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ReportService(IBaseRepository<Report> reportRepository, IBaseRepository<User> userRepository, ILogger logger, IReportValidator reportValidator, IMapper mapper, IOptions<RabbitMqSettings> rabbitMqOptions, IDistributedCache distributedCache)
        {
            _reportRepository = reportRepository;
            _userRepository = userRepository;
            _logger = logger;
            _reportValidator = reportValidator;
            _mapper = mapper;
            _rabbitMqOptions = rabbitMqOptions;
            _distributedCache = distributedCache;
        }

        /// <inheritdoc />
        public async Task<CollectionResult<ReportDto>> GetReportsAsync(long userId)
        {
            ReportDto[] reports;

            try
            {
                reports = await _reportRepository.GetAll()
                    .Where(r => r.UserId == userId)
                    .Select(x => new ReportDto(x.Id, x.Title, x.Description, x.CreatedAt.ToLongDateString()))
                    .ToArrayAsync();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new CollectionResult<ReportDto>()
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCodes.InternalServerError
                };
            }

            if (!reports.Any())
            {
                _logger.Warning(ErrorMessage.ReportsNotFound, reports.Length);
                return new CollectionResult<ReportDto>()
                {
                    ErrorMessage = ErrorMessage.ReportsNotFound,
                    ErrorCode = (int)ErrorCodes.ReportsNotFound
                };
            }

            return new CollectionResult<ReportDto>()
            {
                Data = reports,
                Count = reports.Length
            };
        }

        /// <inheritdoc />
        public async Task<BaseResult<ReportDto>> GetReportByIdAsync(long id)
        {
            ReportDto? report;
            try
            {
                report = await _reportRepository.GetAll()
                    .Where(r => r.Id == id)
                    .Select(r => new ReportDto(r.Id, r.Title, r.Description, r.CreatedAt.ToLongDateString()))
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return new BaseResult<ReportDto>()
                {
                    ErrorMessage = ErrorMessage.InternalServerError,
                    ErrorCode = (int)ErrorCodes.InternalServerError
                };
            }

            if (report == null)
            {
                _logger.Warning($"Отчет с {id} не найден", id);
                return new BaseResult<ReportDto>()
                {
                    ErrorMessage = ErrorMessage.ReportNotFound,
                    ErrorCode = (int)ErrorCodes.ReportNotFound
                };
            }
            
            _distributedCache.SetObject($"Report_{id}", report);
            
            return new BaseResult<ReportDto>()
            {
                Data = report
            };
        }

        /// <inheritdoc />
        public async Task<BaseResult<ReportDto>> CreateReportAsync(CreateReportDto dto)
        {
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(u => u.Id == dto.UserId);
            var report = await _reportRepository.GetAll().FirstOrDefaultAsync(r => r.Title == dto.Title);
            var result = _reportValidator.CreateValidator(report, user);
            if (!result.IsSuccess)
            {
                return new BaseResult<ReportDto>()
                {
                    ErrorMessage = result.ErrorMessage,
                    ErrorCode = result.ErrorCode
                };
            }

            report = new Report()
            {
                Title = dto.Title,
                Description = dto.Description,
                UserId = user.Id
            };
            await _reportRepository.CreateAsync(report);
            await _reportRepository.SaveChangesAsync();
            
            //_messageProducer.SendMessage(report, _rabbitMqOptions.Value.RoutingKey, _rabbitMqOptions.Value.ExchangeName);
            
            return new BaseResult<ReportDto>()
            {
                Data = _mapper.Map<ReportDto>(report)
            };
        }

        /// <inheritdoc />
        public async Task<BaseResult<ReportDto>> DeleteReportAsync(long id)
        {
            var report = await _reportRepository.GetAll().FirstOrDefaultAsync(r => r.Id == id);
            var result = _reportValidator.ValidateOnNull(report);
            if (!result.IsSuccess)
            {
                return new BaseResult<ReportDto>()
                {
                    ErrorMessage = result.ErrorMessage,
                    ErrorCode = result.ErrorCode
                };
            }

            _reportRepository.Remove(report);
            await _reportRepository.SaveChangesAsync();
                
            return new BaseResult<ReportDto>()
            {
                Data = _mapper.Map<ReportDto>(report)
            };
        }

        public async Task<BaseResult<ReportDto>> UpdateReportAsync(UpdateReportDto dto)
        {
            var report = await _reportRepository.GetAll().FirstOrDefaultAsync(r => r.Id == dto.Id);
            var result = _reportValidator.ValidateOnNull(report);
            if (!result.IsSuccess)
            {
                return new BaseResult<ReportDto>()
                {
                    ErrorMessage = result.ErrorMessage,
                    ErrorCode = result.ErrorCode
                };
            }

            report.Title = dto.Title;
            report.Description = dto.Description;

            var updatedReport = _reportRepository.Update(report);
            await _reportRepository.SaveChangesAsync();
                
            return new BaseResult<ReportDto>()
            {
                Data = _mapper.Map<ReportDto>(updatedReport)
            };
        }
    }
}