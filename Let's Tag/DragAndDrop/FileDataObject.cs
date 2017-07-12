/******************************************************************************
 *
 *  This file is based on sample code found on the internet.
 *  Original author unknown.
 *
 *  Source:
 *  http://riqueliam.blog.51cto.com/466137/107612
 *
 *****************************************************************************/

using System.IO;
using System.Windows.Forms;

namespace LetsTag.DragAndDrop
{
    public abstract class FileDataObject : DataObject
    {
        // This flag is used to prevent multiple callings to "GetData" when dropping in Explorer
        bool fileCreated = false;

        string tempFilename;

        public FileDataObject(string filename)
        {
            // Build a path for the temporary file
            tempFilename = Path.Combine(Path.GetTempPath(), filename);

            // Create the temporary file to make sure it exists
            FileStream fileStream = File.Create(tempFilename);
            fileStream.Close();

            // Add the file to the data object
            SetData(DataFormats.FileDrop, new string[] { tempFilename });

            // Set the preferred drop effect
            SetData(ShellClipboardFormats.CFSTR_PREFERREDDROPEFFECT, DragDropEffects.Copy);

            // Indicate that we are in a drag loop
            SetData(ShellClipboardFormats.CFSTR_INDRAGLOOP, 1);
        }

        public override object GetData(string format)
        {
            object obj = base.GetData(format);

            if (!fileCreated && format == DataFormats.FileDrop && !InDragLoop())
            {
                CreateFile(tempFilename);
                fileCreated = true;
            }

            return obj;
        }

        private bool InDragLoop()
        {
            return ((int)GetData(ShellClipboardFormats.CFSTR_INDRAGLOOP) != 0);
        }

        // Create the temporary file and its data
        protected abstract void CreateFile(string tempFilename);
    }
}
