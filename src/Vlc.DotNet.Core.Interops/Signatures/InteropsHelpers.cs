using System;
using System.Collections.Generic;
using System.Text;

namespace Vlc.DotNet.Core.Interops.Signatures
{
    internal static class InteropsHelpers
    {
        public const int OFFSET_LENGTH_OF_POINTER_X86 = 4;
        public const int OFFSET_LENGTH_OF_POINTER_X64 = 8;
#if X86
        public const int OFFSET_LENGTH_OF_POINTER = OFFSET_LENGTH_OF_POINTER_X86;
#elif X64
        public const int OFFSET_LENGTH_OF_POINTER = OFFSET_LENGTH_OF_POINTER_X64;
#endif
    }
}
