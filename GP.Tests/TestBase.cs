using GP.Domain.Contracts.DataAccess.Logs;
using GP.Domain.Contracts.DataAccess.Authors;
using GP.Domain.Contracts.DataAccess.Books;
using GP.Domain.Contracts.DataAccess.PublishingHouses;
using GP.Domain.Contracts.Services;
using GP.Domain.Services;
using GP.Infrastructure.Ef;
using GP.Infrastructure.Ef.DataAccess.Logs;
using GP.Infrastructure.Ef.DataAccess.Authors;
using GP.Infrastructure.Ef.DataAccess.Books;
using GP.Infrastructure.Ef.DataAccess.PublishingHouses;
using GP.Shared.Utils;
using GP.Tests.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using Xunit;

namespace GP.Tests
{
    public abstract class TestBase : IDisposable
    {
        protected DatabaseContext ArrangeRepositoryContext;
        protected DatabaseContext ActRepositoryContext;
        protected DatabaseContext AssertRepositoryContext;

        protected EventLogContext ArrangeEventLogContext;
        protected EventLogContext ActEventLogContext;
        protected EventLogContext AssertEventLogContext;

        protected IBookRepository BookRepository;
        protected IPublishingHouseRepository PublishingHouseRepository;
        protected IAuthorRepository AuthorRepository;
        protected IClock Clock;
        protected ILogRepository LogRepository;
        protected IBookService BookService;

        protected Logger Logger;
        protected TestBase()
        {

            InitializeUtils();
            InitializeContexts();
            InitializeBaseRepositories();
            InitializeDomainServices();
        }

        private void InitializeUtils()
        {
            Clock = new TestClock(DateTime.UtcNow);
        }

        public void Dispose()
        {

        }
        private void InitializeContexts()
        {
            var dbName = Guid.NewGuid().ToString();

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(dbName)
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            var eventLogOptions = new DbContextOptionsBuilder<EventLogContext>()
                .UseInMemoryDatabase(dbName)
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            ArrangeRepositoryContext = new DatabaseContext(options);
            ActRepositoryContext = new DatabaseContext(options);
            AssertRepositoryContext = new DatabaseContext(options);

            ArrangeEventLogContext = new EventLogContext(eventLogOptions);
            ActEventLogContext = new EventLogContext(eventLogOptions);
            AssertEventLogContext = new EventLogContext(eventLogOptions);
        }
        private void InitializeBaseRepositories()
        {
            BookRepository = new BookRepository(ActRepositoryContext);
            PublishingHouseRepository = new PublishingHouseRepository(ActRepositoryContext);
            AuthorRepository = new AuthorRepository(ActRepositoryContext);

            LogRepository = new LogRepository(ActEventLogContext);
        }
        private void InitializeDomainServices()
        {
            Logger = new Logger(LogRepository);
            BookService = new BookService(BookRepository, PublishingHouseRepository, AuthorRepository, Clock);
        }
    }
}
