using System;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace LetsTag
{
    public static class AlbumParser
    {
        readonly static Regex albumNameRegex = new Regex(
            @"<span\s+class\s*=\s*[\'\""]albumtitle[\'\""]\s+lang\s*=\s*[\'\""]en[\'\""].*?>(.*?)</span>",
            RegexOptions.Singleline | RegexOptions.IgnoreCase);

        readonly static Regex coverRegex = new Regex(
            @"<div\s+id\s*=\s*[\'\""]coverart[\'\""]\s+[^>]*background-image:\s*url\('(.*?)'\)",
            RegexOptions.Singleline | RegexOptions.IgnoreCase);

        readonly static Regex detailRegex = new Regex(
            @"<tr>.*?<td.*?>.*?<span\s+class\s*=\s*[\'\""]label[\'\""].*?>\s*<b>(.*?)</b>\s*</span>.*?</td>.*?<td.*?>(.*?)</td>.*?</tr>",
            RegexOptions.Singleline | RegexOptions.IgnoreCase);

        readonly static Regex detailCatalogNumberRegex = new Regex(
            @"<span\s+id\s*\=\s*[\'\""]childbrowse[\'\""].*?<a\s+.*?>(.*?)</a>",
            RegexOptions.Singleline | RegexOptions.IgnoreCase);

        readonly static Regex detailMultilingualValueRegex = new Regex(
            @"<span\s+.*?lang\s*\=\s*[\'\""](.*?)[\'\""].*?>(.*?)</span>",
            RegexOptions.Singleline | RegexOptions.IgnoreCase);

        readonly static Regex detailValueCleanupRegex = new Regex(
            @"<.*?>",
            RegexOptions.Singleline | RegexOptions.IgnoreCase);

        public static void Parse(Album album, string data)
        {
            // Extract album name

            Match match = albumNameRegex.Match(data);

            if (!match.Success)
                throw new Exception("There was a problem parsing the album data.");

            album.Details.Add("Album Name", HttpUtility.HtmlDecode(match.Groups[1].Value).Trim());

            // Extract cover

            match = coverRegex.Match(data);

            if (match.Success)
                album.Cover = GetImage(match.Groups[1].Value);

            // Extract other details

            match = detailRegex.Match(data);
            while (match.Success)
            {
                string key = HttpUtility.HtmlDecode(match.Groups[1].Value).Trim();
                string value = match.Groups[2].Value;

                if (key.ToLower().Contains("catalog"))
                {
                    Match subMatch = detailCatalogNumberRegex.Match(value);
                    if (subMatch.Success)
                        value = subMatch.Groups[1].Value;
                }
                else
                {
                    value = detailMultilingualValueRegex.Replace(value, new MatchEvaluator(DetailMultilingualEvaluator));
                }

                value = HttpUtility.HtmlDecode(detailValueCleanupRegex.Replace(value, "")).Trim();

                album.Details.Add(key, value);

                match = match.NextMatch();
            }
        }

        static Image GetImage(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            Image image = Image.FromStream(response.GetResponseStream());
            response.Close();
            return image;
        }

        static string DetailMultilingualEvaluator(Match match)
        {
            if (match.Groups[1].Value.ToLower() == "en")
                return match.Groups[2].Value;
            else
                return "";
        }
    }
}
