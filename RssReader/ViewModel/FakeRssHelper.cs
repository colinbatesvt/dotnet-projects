using RssReader.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RssReader.ViewModel
{
    class FakeRssHelper : IRssHelper
    {
        public List<Item> GetPosts()
        {
            List<Item> items = new List<Item>();

            items.Add(new Item()
            {
                Title = "Test Title",
                PubDate = "Yesterday"
            });

            return items;
        }
    }
}
