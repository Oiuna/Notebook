using System;
using System.Collections.Generic;
using System.Linq;
using MockQueryable.Moq;
using Moq;
using Notebook.Domain.Entity;
using Notebook.Domain.Interfaces.Repositories;

namespace Notebook.Test.Configurations
{
    public static class MockRepositoriesGetter
    {
        public static Mock<IBaseRepository<Report>> GetMockReportRepository()
        {
            var mock = new Mock<IBaseRepository<Report>>();

            var reports = GetReports().BuildMockDbSet();

            mock.Setup(r => r.GetAll()).Returns(() => reports.Object);
            return mock;
        }
        
        public static Mock<IBaseRepository<User>> GetMockUserRepository()
        {
            var mock = new Mock<IBaseRepository<User>>();

            var users = GetUsers().BuildMockDbSet();

            mock.Setup(u => u.GetAll()).Returns(() => users.Object);
            return mock;
        }

        public static IQueryable<Report> GetReports()
        {
            return new List<Report>()
            {
                new Report()
                {
                    Id = 1,
                    Title = "Report #1",
                    Description = "Text for report #1",
                    CreatedAt = DateTime.Now.AddDays(-2),
                    UpdatedAt = DateTime.Now.AddDays(-2)
                },
                new Report()
                {
                    Id = 1,
                    Title = "Report #2",
                    Description = "Text for report #2",
                    CreatedAt = DateTime.Now.AddDays(-2),
                    UpdatedAt = DateTime.Now.AddDays(-2)
                },
            }.AsQueryable();
        }
        
        public static IQueryable<User> GetUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Login = "Login1",
                    Password = "lkjnkjndzfjljlzf654zdf64zfzd5",
                    CreatedAt = DateTime.Now.AddDays(-2),
                    UpdatedAt = DateTime.Now.AddDays(-2)
                },
                new User()
                {
                    Id = 1,
                    Login = "Login2",
                    Password = "lkzfdg54zd6fzdsv84z46dsv55zvdv",
                    CreatedAt = DateTime.Now.AddDays(-2),
                    UpdatedAt = DateTime.Now.AddDays(-2)
                },
            }.AsQueryable();
        }
    }
}