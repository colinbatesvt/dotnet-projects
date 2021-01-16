using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RssReader.Model
{
    public class CData
    {
        public string ActualString { get; set; }
    }

    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "link")]
        public string Link { get; set; }
        private string pubDate;
        [XmlElement(ElementName = "pubDate")]
        public string PubDate { get; set; }

        [XmlElement(ElementName = "creator", Namespace = "http://purl.org/dc/elements/1.1/")]
        public string Creator { get; set; }
    }

    [XmlRoot(ElementName = "channel")]
    public class Channel
    {
        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }

        [XmlElement(ElementName = "link")]
        public string Link { get; set; }
    }

    [XmlRoot(ElementName = "rss")]
    public class NasaFeed
    {
        [XmlElement(ElementName = "channel")]
        public Channel Channel { get; set; }
    }
}
