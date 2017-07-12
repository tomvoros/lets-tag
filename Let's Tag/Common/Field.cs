using System.Collections.Generic;
using System.Xml;

namespace LetsTag.Common
{
    public interface IField
    {
        string GetName();
        string GetMp3tagFormat();
        string GetValue(Album album, Disc disc, Track track);
        void WriteXml(XmlWriter writer);
    }

    public abstract class BaseField : IField
    {
        public abstract string GetName();
        public abstract string GetMp3tagFormat();
        public abstract string GetValue(Album album, Disc disc, Track track);
        public abstract void WriteXml(XmlWriter writer);

        protected void WriteXmlStartField(XmlWriter writer)
        {
            writer.WriteStartElement("field");
            writer.WriteStartAttribute("mp3tagFormat");
            writer.WriteString(GetMp3tagFormat());
            writer.WriteEndAttribute();
        }

        protected void WriteXmlEndField(XmlWriter writer)
        {
            writer.WriteEndElement();
        }
    }

    public class SimpleField : BaseField
    {
        IFieldValue fieldValue;
        string mp3tagFormat;

        public SimpleField(IFieldValue fieldValue)
            : this(fieldValue, "%dummy%") { }

        public SimpleField(IFieldValue fieldValue, string mp3tagFormat)
        {
            this.fieldValue = fieldValue;
            this.mp3tagFormat = mp3tagFormat;
        }

        public override string GetName()
        {
            return fieldValue.GetName();
        }

        public override string GetMp3tagFormat()
        {
            return mp3tagFormat;
        }

        public override string GetValue(Album album, Disc disc, Track track)
        {
            return fieldValue.GetValue(album, disc, track);
        }

        public override void WriteXml(XmlWriter writer)
        {
            WriteXmlStartField(writer);
            fieldValue.WriteXml(writer);
            WriteXmlEndField(writer);
        }
    }

    public class CompositeField : BaseField
    {
        IList<IFieldValue> fieldValues = new List<IFieldValue>();
        string mp3tagFormat;

        public IList<IFieldValue> FieldValues
        {
            get { return fieldValues; }
        }

        public CompositeField()
            : this("%dummy%") { }

        public CompositeField(string mp3tagFormat)
        {
            this.mp3tagFormat = mp3tagFormat;
        }

        public override string GetName()
        {
            string name = "";
            foreach (IFieldValue fieldValue in fieldValues)
                name += fieldValue.GetName();
            return name;
        }

        public override string GetMp3tagFormat()
        {
            return mp3tagFormat;
        }

        public override string GetValue(Album album, Disc disc, Track track)
        {
            string value = "";
            foreach (IFieldValue fieldValue in fieldValues)
                value += fieldValue.GetValue(album, disc, track);
            return value;
        }

        public override void WriteXml(XmlWriter writer)
        {
            WriteXmlStartField(writer);
            foreach (IFieldValue fieldValue in fieldValues)
                fieldValue.WriteXml(writer);
            WriteXmlEndField(writer);
        }
    }

    public interface IFieldValue
    {
        string GetName();
        string GetValue(Album album, Disc disc, Track track);
        void WriteXml(XmlWriter writer);
    }

    public class AlbumFieldValue : IFieldValue
    {
        string fieldName;

        public AlbumFieldValue(string fieldName)
        {
            this.fieldName = fieldName;
        }

        public string GetName()
        {
            return string.Format("<Album: {0}>", fieldName);
        }

        public string GetValue(Album album, Disc disc, Track track)
        {
            return album.Details[fieldName];
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("albumfield");
            writer.WriteStartAttribute("name");
            writer.WriteString(fieldName);
            writer.WriteEndAttribute();
            writer.WriteEndElement();
        }
    }

    public class DiscNumberValue : IFieldValue
    {
        public DiscNumberValue() { }

        public string GetName()
        {
            return "<Track: Disc>";
        }

        public string GetValue(Album album, Disc disc, Track track)
        {
            return disc.Number;
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("discnumber");
            writer.WriteEndElement();
        }
    }

    public class TrackNumberValue : IFieldValue
    {
        public TrackNumberValue() { }

        public string GetName()
        {
            return "<Track: Number>";
        }

        public string GetValue(Album album, Disc disc, Track track)
        {
            return track.Number;
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("tracknumber");
            writer.WriteEndElement();
        }
    }

    public class TrackNameValue : IFieldValue
    {
        public TrackNameValue() { }

        public string GetName()
        {
            return "<Track: Name>";
        }

        public string GetValue(Album album, Disc disc, Track track)
        {
            return track.Name;
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("trackname");
            writer.WriteEndElement();
        }
    }

    public class StringValue : IFieldValue
    {
        string value;

        public StringValue(string value)
        {
            this.value = value;
        }

        public string GetName()
        {
            return value;
        }

        public string GetValue(Album album, Disc disc, Track track)
        {
            return value;
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(value);
        }
    }
}
