
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    class FakeVideoContext : IVideoContext
    {
        List<Video> Videos;

        public FakeVideoContext(List<Video> videos)
        {
            Videos = videos;
        }

        public List<Video> GetUnprocessedVideos()
        {
            return (from video in Videos
                    where !video.IsProcessed
                    select video).ToList();
        }
    }
}
