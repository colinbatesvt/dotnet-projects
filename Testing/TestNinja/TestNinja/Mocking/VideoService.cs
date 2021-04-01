using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private IFileReader _fileReader;

        public VideoService(IFileReader fileReader = null)
        {
            _fileReader = fileReader ?? new FileReader();
        }

        public string ReadVideoTitle()
        {
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv(IVideoContext context)
        {
            var videoIds = new List<int>();

            var videos = context.GetUnprocessedVideos();
            
            foreach (var v in videos)
                videoIds.Add(v.Id);
            
            return String.Join(",", videoIds);
            
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public interface IVideoContext
    {
        List<Video> GetUnprocessedVideos();
    }


    public class VideoContext : DbContext, IVideoContext
    {
        public DbSet<Video> Videos { get; set; }

        public List<Video> GetUnprocessedVideos()
        {
           return (from video in Videos
             where !video.IsProcessed
             select video).ToList();
        }
    }
}