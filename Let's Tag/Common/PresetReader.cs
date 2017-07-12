using System.IO;
using System.Xml;

namespace LetsTag.Common
{
    public class PresetReader
    {
        public static Preset LoadPreset(string path)
        {
            Stream stream = PresetManager.OpenPresetFile(path, FileMode.Open, FileAccess.Read);
            XmlReader reader = new XmlTextReader(stream);
            Preset preset = new Preset(Path.GetFileNameWithoutExtension(path));
            ReadPreset(reader, preset);
            reader.Close();
            return preset;
        }

        private static void ReadPreset(XmlReader reader, Preset preset)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name.ToLower() == "preset")
                {
                    string delimiter = reader.GetAttribute("delimiter");
                    if (!string.IsNullOrEmpty(delimiter))
                        preset.Delimiter = delimiter;
                    
                    ReadPresetFields(reader.ReadSubtree(), preset);

                    return;
                }
            }

            throw new LetsTagException("Could not find <preset> element");
        }

        private static void ReadPresetFields(XmlReader reader, Preset preset)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name.ToLower() == "field")
                    preset.Fields.Add(ReadPresetField(reader.ReadSubtree()));
            }
        }

        private static IField ReadPresetField(XmlReader reader)
        {
            CompositeField field;

            reader.Read();

            if(string.IsNullOrEmpty(reader.GetAttribute("mp3tagFormat")))
                field = new CompositeField();
            else
                field = new CompositeField(reader.GetAttribute("mp3tagFormat"));

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Text:
                        field.FieldValues.Add(new StringValue(reader.Value));
                        break;

                    case XmlNodeType.Element:
                        switch (reader.Name.ToLower())
                        {
                            case "discnumber":
                                field.FieldValues.Add(new DiscNumberValue());
                                break;

                            case "tracknumber":
                                field.FieldValues.Add(new TrackNumberValue());
                                break;

                            case "trackname":
                                field.FieldValues.Add(new TrackNameValue());
                                break;

                            case "albumfield":
                                field.FieldValues.Add(ReadPresetAlbumFieldValue(reader.ReadSubtree()));
                                break;

                            case "field":
                                throw new LetsTagException("Missing closing </field> element");

                            default:
                                throw new LetsTagException(string.Format("Unrecognized element <{0}>", reader.Name));
                        }
                        break;

                    case XmlNodeType.EndElement:
                        if(reader.Name.ToLower() == "field")
                            return field;
                        break;
                }
            }

            throw new LetsTagException("Missing closing </field> element");
        }

        private static AlbumFieldValue ReadPresetAlbumFieldValue(XmlReader reader)
        {
            reader.Read();

            string name = reader.GetAttribute("name");

            if(string.IsNullOrEmpty(name))
                throw new LetsTagException("<albumfield> element missing name attribute");

            return new AlbumFieldValue(name);
        }
    }
}
