using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using LetsTag.Common;

namespace LetsTag
{
    class ConsoleProgram
    {
        public static int Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    PrintUsage();
                    return 0;
                }

                IDictionary<string, string> options = new Dictionary<string, string>();

                for (int i = 0; i < args.Length; i++)
                {
                    string arg = args[i];

                    if (arg == "--help")
                    {
                        PrintUsage();
                        return 0;
                    }
                    else if (arg.StartsWith("--album="))
                    {
                        options.Add("album", arg.Substring(8));
                    }
                    else if (arg.StartsWith("-a="))
                    {
                        options.Add("album", arg.Substring(3));
                    }
                    else if (arg.StartsWith("--preset="))
                    {
                        options.Add("preset", arg.Substring(9));
                    }
                    else if (arg.StartsWith("-p="))
                    {
                        options.Add("preset", arg.Substring(3));
                    }
                    else if (i == args.Length - 1)
                    {
                        options.Add("output", arg);
                    }
                }

                if (!options.ContainsKey("output"))
                    options.Add("output", "-");

                Validate(options);
                Execute(options);
            }
            catch (LetsTagException ex)
            {
                Console.WriteLine(ex.ToString());
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Let's Tag encountered an unhandled exception:");
                Console.WriteLine(ex.ToString());
                return 2;
            }

            return 0;
        }

        static void PrintUsage()
        {
            ResourceManager resourceManager = new ResourceManager("LetsTag.ConsoleResource", Assembly.GetExecutingAssembly());
            Console.WriteLine(resourceManager.GetString("UsageString"));
        }

        static void Validate(IDictionary<string, string> options)
        {
            string output = options["output"];
            if (output != "-")
            {
                try
                {
                    Path.GetFullPath(output);
                }
                catch (Exception ex)
                {
                    throw new LetsTagException("Invalid output file: " + output, ex);
                }
            }

            if (!options.ContainsKey("album"))
                throw new LetsTagException("No album specified");
        }

        static void Execute(IDictionary<string, string> options)
        {
            Preset preset = GetPreset(options);
            Album album = GetAlbum(options["album"]);
            StreamWriter output = OpenOutput(options["output"]);
            Exporter.Export(album, preset, output);
            output.Close();
        }

        static StreamWriter OpenOutput(string output)
        {
            if (output == "-")
            {
                return new StreamWriter(Console.OpenStandardOutput(), new UTF8Encoding(false));
            }
            else
            {
                try
                {
                    return new StreamWriter(output, false, new UTF8Encoding(true));
                }
                catch (Exception ex)
                {
                    throw new LetsTagException("Could not open output file: " + output, ex);
                }
            }
        }

        static Album GetAlbum(string albumId)
        {
            string albumData = GetAlbumData(albumId);

            Album album = new Album();

            // Split data string where the tracklist starts
            int tracklistIndex = albumData.IndexOf(">Tracklist</h");
            if (tracklistIndex < 0)
                throw new LetsTagException("There was a problem parsing the album data");

            string detailsString = albumData.Substring(0, tracklistIndex);
            AlbumParser.Parse(album, detailsString);

            string tracklistString = albumData.Substring(tracklistIndex);
            TracklistParser.Parse(album, tracklistString);

            return album;
        }

        static string GetAlbumData(string albumId)
        {
            string albumUri = string.Format("http://vgmdb.net/album/{0}", albumId);
            HttpGetRequest request = new HttpGetRequest(albumUri);
            request.Execute();
            while (true)
            {
                switch (request.Status)
                {
                    case HttpRequestStatus.Aborted:
                        throw new LetsTagException("Downloading album data aborted");

                    case HttpRequestStatus.Error:
                        throw new LetsTagException("Error downloading album data");

                    case HttpRequestStatus.Done:
                        return UTF8Encoding.UTF8.GetString(request.Response);
                }
                Thread.Sleep(100);
            }
        }

        static Preset GetPreset(IDictionary<string, string> options)
        {
            try
            {
                string presetName = "Default.xml";
                if (options.ContainsKey("preset"))
                {
                    presetName = options["preset"];
                    if (string.IsNullOrEmpty(Path.GetExtension(presetName)))
                        presetName = string.Format("{0}.xml", presetName);
                }
                return PresetReader.LoadPreset(presetName);
            }
            catch (Exception ex)
            {
                throw new LetsTagException("Could not load preset", ex);
            }
        }
    }
}
