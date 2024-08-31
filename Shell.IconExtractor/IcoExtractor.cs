using Shell.IconExtractor.Enumes;
using Shell.IconExtractor.Helper;
using Shell.IconExtractor.Strucrure;
using System.Runtime.InteropServices;

namespace Shell.IconExtractor
{
    public class IcoExtractor : IDisposable
    {

        private bool disposedValue;
        private Icon? CloneIcon;
        private ShellFileInfo fileInfo = new ShellFileInfo();
        public Icon _GetIcon(string path, ItemType type, IconSize iconSize, ItemState state)
        {
            uint attributes = (uint)(type == ItemType.Folder ? FileAttribute.Directory : FileAttribute.File);
            uint flags = (uint)(ShellAttribute.Icon | ShellAttribute.UseFileAttributes);

            if (type == ItemType.Folder && state == ItemState.Open)
            {
                flags = flags | (uint)ShellAttribute.OpenIcon;
            }
            if (iconSize == IconSize.Small)
            {
                flags = flags | (uint)ShellAttribute.SmallIcon;
            }
            else
            {
                flags = flags | (uint)ShellAttribute.LargeIcon;
            }


            {
                uint size = (uint)Marshal.SizeOf(fileInfo);
                nint result = Interop.SHGetFileInfo(path, attributes, out fileInfo, size, flags);
                using (Icon tmp = Icon.FromHandle(fileInfo.hIcon))
                {
                    CloneIcon = (Icon)tmp.Clone();
                }
            }

            return CloneIcon;
        }


        public IcoExtractor(IcoExtractorOptions options)
        {
            try
            {
                CloneIcon = _GetIcon(options.path, options.type, options.iconSize, options.state);
            }
            catch (Exception)
            {


            }

        }

        public Icon? GetIcon => CloneIcon;

        public bool SaveToFile(string path)
        {
            try
            {
                CloneIcon?.ToBitmap().Save(path);
                return true;
            }
            catch (Exception)
            {
                return false;

            }

        }


        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }

                disposedValue = true;
            }
        }


        ~IcoExtractor()
        {

            Dispose(disposing: false);
        }

        public void Dispose()
        {
            CloneIcon?.Dispose();
            fileInfo.Dispose();
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
