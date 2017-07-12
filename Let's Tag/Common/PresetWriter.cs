using System.IO;
using System.Text;
using System.Xml;

namespace LetsTag.Common
{
    public class PresetWriter
    {
        public static void SavePreset(Preset preset)
        {
            string path = string.Format("{0}.xml", preset.Name);
            Stream stream = PresetManager.OpenPresetFile(path, FileMode.Create, FileAccess.ReadWrite);
            XmlWriter writer = new XmlTextWriter(stream, UTF8Encoding.UTF8);
            WritePreset(writer, preset);
            writer.Flush();
            writer.Close();
        }

        private static void WritePreset(XmlWriter writer, Preset preset)
        {
            writer.WriteStartDocument();
            writer.WriteWhitespace("\r\n");
            writer.WriteStartElement("preset");
            writer.WriteStartAttribute("delimiter");
            writer.WriteString(preset.Delimiter);
            writer.WriteEndAttribute();
            writer.WriteWhitespace("\r\n");

            WritePresetFields(writer, preset);

            writer.WriteEndElement();
            writer.WriteEndDocument();
        }

        private static void WritePresetFields(XmlWriter writer, Preset preset)
        {
            foreach (IField field in preset.Fields)
            {
                writer.WriteWhitespace("\t");
                field.WriteXml(writer);
                writer.WriteWhitespace("\r\n");
            }
        }
    }
}
