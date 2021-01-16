using RssReader.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RssReader.ViewModel
{
    public class RssHelper : IRssHelper
    {

        public List<Item> GetPosts()
        {
            List<Item> posts= new List<Item>();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(NasaFeed));

            using (WebClient client= new WebClient())
            {
                string xml = Encoding.Default.GetString(client.DownloadData("https://www.nasa.gov/rss/dyn/breaking_news.rss"));

                using(Stream reader = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                {
                    NasaFeed feed = (NasaFeed)xmlSerializer.Deserialize(reader);

                    posts = feed.Channel.Item;
                }
            }

            return posts;
        }
    }
}
