using Shell.IconExtractor.Helper;
using System.Runtime.InteropServices;

namespace Shell.IconExtractor.Strucrure
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ShellFileInfo : IDisposable
    {
        public IntPtr hIcon;

        public int iIcon;

        public uint dwAttributes;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;

        public void DestroyIcon()
        {

            Interop.DestroyIcon(this.hIcon);
        }

        public void Dispose()
        {
            this.DestroyIcon();
        }
    }
}
