/******************************************************************************
 *
 *  This file is based on sample code found on the internet.
 *  Original author unknown.
 *
 *  Source:
 *  http://riqueliam.blog.51cto.com/466137/107612
 *
 *****************************************************************************/

namespace LetsTag.DragAndDrop
{
    // Constant declarations.  Please refer to "shlobj.h".
    public static class ShellClipboardFormats
    {
        public const string CFSTR_SHELLIDLIST = "Shell IDList Array";
        public const string CFSTR_SHELLIDLISTOFFSET = "Shell Object Offsets";
        public const string CFSTR_NETRESOURCES = "Net Resource";
        public const string CFSTR_FILEDESCRIPTORA = "FileGroupDescriptor";
        public const string CFSTR_FILEDESCRIPTORW = "FileGroupDescriptorW";
        public const string CFSTR_FILECONTENTS = "FileContents";
        public const string CFSTR_FILENAMEA = "FileName";
        public const string CFSTR_FILENAMEW = "FileNameW";
        public const string CFSTR_PRINTERGROUP = "PrinterFreindlyName";
        public const string CFSTR_FILENAMEMAPA = "FileNameMap";
        public const string CFSTR_FILENAMEMAPW = "FileNameMapW";
        public const string CFSTR_SHELLURL = "UniformResourceLocator";
        public const string CFSTR_INETURLA = CFSTR_SHELLURL;
        public const string CFSTR_INETURLW = "UniformResourceLocatorW";
        public const string CFSTR_PREFERREDDROPEFFECT = "Preferred DropEffect";
        public const string CFSTR_PERFORMEDDROPEFFECT = "Performed DropEffect";
        public const string CFSTR_PASTESUCCEEDED = "Paste Succeeded";
        public const string CFSTR_INDRAGLOOP = "InShellDragLoop";
        public const string CFSTR_DRAGCONTEXT = "DragContext";
        public const string CFSTR_MOUNTEDVOLUME = "MountedVolume";
        public const string CFSTR_PERSISTEDDATAOBJECT = "PersistedDataObject";
        public const string CFSTR_TARGETCLSID = "TargetCLSID";
        public const string CFSTR_LOGICALPERFORMEDDROPEFFECT = "Logical Performed DropEffect";
        public const string CFSTR_AUTOPLAY_SHELLIDLISTS = "Autoplay Enumerated IDList Array";
    }
}
