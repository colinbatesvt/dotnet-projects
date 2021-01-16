using RssReader.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RssReader.ViewModel
{
    public interface IRssHelper
    {
        List<Item> GetPosts();
    }
}
