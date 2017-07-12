using System.Collections.Generic;

namespace LetsTag.Common
{
    public class Preset
    {
        string name;
        IList<IField> fields;
        string delimiter;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public IList<IField> Fields
        {
            get { return fields; }
        }

        public string Delimiter
        {
            get { return delimiter; }
            set { delimiter = value; }
        }

        public Preset(string name)
            : this(name, new List<IField>(), "//") { }

        public Preset(string name, string delimiter)
            : this(name, new List<IField>(), delimiter) { }

        public Preset(string name, IList<IField> fields)
            : this(name, new List<IField>(fields), "//") { }

        public Preset(string name, IList<IField> fields, string delimiter)
        {
            this.name = name;
            this.fields = new List<IField>(fields);
            this.delimiter = delimiter;
        }

        public Preset Clone()
        {
            return new Preset(name, fields, delimiter);
        }
    }
}
