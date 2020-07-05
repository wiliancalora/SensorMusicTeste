using System;
using System.Collections.Generic;
using System.Text;

namespace SensorMusic.Domain.DTO
{
    public class SpotifyList
    {
        public Artists artists { get; set; }
    }

    public class Artists
    {
        public string href { get; set; }
        public List<Items> items { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
        public int offset { get; set; }
        public string previous { get; set; }
        public int total { get; set; }
    }

    public class Items
    {
        public ExternalUrls external_urls { get; set; }
        public Followers followers { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public List<Images> images { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class ExternalUrls
    {
        public string spotify { get; set; }
    }

    public class Followers
    {
        public object href { get; set; }
        public int total { get; set; }
    }

    public class Images
    {
        public object height { get; set; }
        public string url { get; set; }
        public object width { get; set; }
    }

}
