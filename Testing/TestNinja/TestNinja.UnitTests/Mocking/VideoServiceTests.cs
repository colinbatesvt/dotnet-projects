using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class VideoServiceTests
    {
        private VideoService _service;
        private Mock<IFileReader> _fileReader;

        [SetUp]
        public void Setup()
        {
            _fileReader = new Mock<IFileReader>();
            _service = new VideoService(_fileReader.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");
            var result = _service.ReadVideoTitle();

            Assert.That(result, Does.Contain("Error"));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_EmptyList_ReturnsEmptyString()
        {

            List<Video> videos = new List<Video>();

            FakeVideoContext context = new FakeVideoContext(videos);
            var result = _service.GetUnprocessedVideosAsCsv(context);
            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_VideoList_ReturnsCommaSeperatedIdsOfUnprocessedVideos()
        {
            Video a = new Video
            {
                Title = "Video A",
                Id = 1,
                IsProcessed = false
            };

            Video b = new Video
            {
                Title = "Video B",
                Id = 2,
                IsProcessed = true
            };

            Video c = new Video
            {
                Title = "Video C",
                Id = 3,
                IsProcessed = false
            };

            List<Video> videos = new List<Video>();
            videos.Add(a);
            videos.Add(b);
            videos.Add(c);

            FakeVideoContext context = new FakeVideoContext(videos);
            var result = _service.GetUnprocessedVideosAsCsv(context);
            Assert.That(result, Is.EqualTo("1,3"));
        }
    }
}
