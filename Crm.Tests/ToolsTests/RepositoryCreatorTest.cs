using amocrm.library;
using amocrm.library.Interfaces;
using amocrm.library.Models;
using amocrm.library.Tools;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Crm.Tests.ToolsTests
{
    [TestClass]
    public class RepositoryCreatorTest
    {
        [TestMethod]
        public void CreateBasicGenericRepository()
        {
            var provider = new Mock<ICrmProvider>().Object;

            IRepositoryCreator creator = new BasicRepositoryCreator(provider);

            Assert.IsInstanceOfType(creator.GetRepository<Lead>(), typeof(CrmRepositoty<Lead>));
        }

        [TestMethod]
        public void CreateLoggedGenericRepository()
        {
            var provider = new Mock<ICrmProvider>().Object;
            var logger = new Mock<ILogger>().Object;

            IRepositoryCreator creator = new LoggedRepositoryCreator(provider, logger);

            Assert.IsInstanceOfType(creator.GetRepository<Lead>(), typeof(LoggedRepositotyDecorator<Lead>));
        }
    }
}
