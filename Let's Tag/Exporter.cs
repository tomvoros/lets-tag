using System.IO;
using LetsTag.Common;

namespace LetsTag
{
    public static class Exporter
    {
        public static void Export(Album album, Preset preset, StreamWriter streamWriter)
        {
            foreach (Disc disc in album.Discs)
            {
                foreach (Track track in disc.Tracks)
                {
                    bool isFirstField = true;
                    foreach(IField field in preset.Fields)
                    {
                        if (isFirstField)
                            isFirstField = false;
                        else
                            streamWriter.Write(preset.Delimiter);

                        streamWriter.Write(field.GetValue(album, disc, track));
                    }

                    streamWriter.WriteLine();
                }
            }
        }
    }
}
