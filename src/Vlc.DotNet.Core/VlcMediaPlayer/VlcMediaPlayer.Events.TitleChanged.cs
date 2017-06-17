using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerTitleChangedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerTitleChangedEventArgs> TitleChanged;

        private void OnMediaPlayerTitleChangedInternal(IntPtr ptr)
        {
#if X86 || X64
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
#else
            var args = (VlcEventArg)X86_X64_PtrToStructure.PtrToStructure(ptr);
#endif
            var fileName = Marshal.PtrToStringAnsi(args.MediaPlayerTitleChanged.NewTitle);
            OnMediaPlayerTitleChanged(fileName);
        }

        public void OnMediaPlayerTitleChanged(string fileName)
        {
            var del = TitleChanged;
            if (del != null)
                del(this, new VlcMediaPlayerTitleChangedEventArgs(fileName));
        }
    }
}