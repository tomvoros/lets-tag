using System.Collections.Generic;
using System.Drawing;

namespace LetsTag
{
    public class Album
    {
        public IDictionary<string, string> Details = new Dictionary<string, string>();
        public IList<Disc> Discs = new List<Disc>();
        public Image Cover = null;
    }

    public class Disc
    {
        public string Number;
        public IList<Track> Tracks = new List<Track>();
    }

    public class Track
    {
        public string Number;
        public string Name;
    }
}
