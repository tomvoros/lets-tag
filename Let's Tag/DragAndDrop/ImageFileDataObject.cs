using System.Drawing;
using System.Drawing.Imaging;

namespace LetsTag.DragAndDrop
{
    public class ImageFileDataObject : FileDataObject
    {
        Image image;
        ImageCodecInfo imageEncoder;
        EncoderParameters imageEncoderParams;

        public ImageFileDataObject(string filename, Image image)
            : this(filename, image, null) { }

        public ImageFileDataObject(string filename, Image image, ImageCodecInfo imageEncoder)
            : this(filename, image, imageEncoder, null) { }

        public ImageFileDataObject(string filename, Image image, ImageCodecInfo imageEncoder, EncoderParameters imageEncoderParams)
            : base(filename)
        {
            this.image = image;
            this.imageEncoder = imageEncoder;
            this.imageEncoderParams = imageEncoderParams;
        }

        protected override void CreateFile(string tempFilename)
        {
            if (imageEncoder == null)
                image.Save(tempFilename);
            else
                image.Save(tempFilename, imageEncoder, imageEncoderParams);
        }
    }
}
