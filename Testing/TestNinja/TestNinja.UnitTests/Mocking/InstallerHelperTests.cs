

using Moq;
using NUnit.Framework;
using System.Net;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class InstallerHelperTests
    {
        private Mock<IDownloader> _fileDownloader;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloader.Object);
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnsFalse()
        {
            _fileDownloader.Setup(fd => 
                fd.Download(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();

            Assert.That(_installerHelper.DownloadInstaller("customer", "installer"), Is.False);
        }

        [Test]
        public void DownloadInstaller_WhenInstallerIsDownloaded_ReturnsTrue()
        {
            Assert.That(_installerHelper.DownloadInstaller("customer", "installer"), Is.True);
        }

    }
}
