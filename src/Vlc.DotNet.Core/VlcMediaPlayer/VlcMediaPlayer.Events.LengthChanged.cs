﻿using System;
using System.Runtime.InteropServices;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerLengthChangedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerLengthChangedEventArgs> LengthChanged;

        private void OnMediaPlayerLengthChangedInternal(IntPtr ptr)
        {
#if X86 || X64
            var args = (VlcEventArg)Marshal.PtrToStructure(ptr, typeof(VlcEventArg));
#else
            var args = (VlcEventArg)X86_X64_PtrToStructure.PtrToStructure(ptr);
#endif
            OnMediaPlayerLengthChanged(args.MediaPlayerLengthChanged.NewLength * 10000);
        }

        public void OnMediaPlayerLengthChanged(float newLength)
        {
            var del = LengthChanged;
            if (del != null)
                del(this, new VlcMediaPlayerLengthChangedEventArgs(newLength));
        }
    }
}