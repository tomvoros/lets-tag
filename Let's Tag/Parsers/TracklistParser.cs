using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

namespace LetsTag
{
    public static class TracklistParser
    {
        readonly static Regex discRegex = new Regex(
            @"<b>\s*Disc\s+(\d+)\s*</b>.*?<table.*?>(.*?)</table>",
            RegexOptions.Singleline | RegexOptions.IgnoreCase);

        readonly static Regex trackRegex = new Regex(
            @"<span\s+class\s*=\s*" + "[\\\'\\\"]label[\\\'\\\"]" + @"\s*>(.*?)</span>" + // Track number
            @".*?<td.*?>(.*?)</td>", // Track name
            RegexOptions.Singleline | RegexOptions.IgnoreCase);

        public static void Parse(Album album, string data)
        {
            IList<string> discNumbers = new List<string>();

            Match match = discRegex.Match(data);
            while (match.Success)
            {
                Disc disc = new Disc();
                disc.Number = HttpUtility.HtmlDecode(match.Groups[1].Value).Trim();

                if (!discNumbers.Contains(disc.Number))
                {
                    discNumbers.Add(disc.Number);

                    Match subMatch = trackRegex.Match(match.Groups[2].Value);
                    while (subMatch.Success)
                    {
                        Track track = new Track();
                        track.Number = HttpUtility.HtmlDecode(subMatch.Groups[1].Value);
                        track.Name = HttpUtility.HtmlDecode(subMatch.Groups[2].Value);

                        disc.Tracks.Add(track);

                        subMatch = subMatch.NextMatch();
                    }

                    album.Discs.Add(disc);
                }

                match = match.NextMatch();
            }
        }
    }
}
