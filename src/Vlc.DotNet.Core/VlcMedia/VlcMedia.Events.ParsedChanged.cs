using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public partial class VlcMedia
    {
        private EventCallback myOnMediaParsedChangedInternalEventCallback;
        public event EventHandler<VlcMediaParsedChangedEventArgs> ParsedChanged;

        private void OnMediaParsedChangedInternal(IntPtr ptr)
        {
#if X86 || X64
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
#else
            var args = (VlcEventArg)X86_X64_PtrToStructure.PtrToStructure(ptr);
#endif
            OnMediaParsedChanged(args.MediaParsedChanged.NewStatus);
        }

        public void OnMediaParsedChanged(int newStatus)
        {
            var del = ParsedChanged;
            if (del != null)
                del(this, new VlcMediaParsedChangedEventArgs(newStatus));
        }
    }
}