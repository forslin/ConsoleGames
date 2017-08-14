using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.IO;

namespace GameConsoleUtility
{
    class GameConsole
    {
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern SafeFileHandle CreateFile(
       string fileName,
       [MarshalAs(UnmanagedType.U4)] uint fileAccess,
       [MarshalAs(UnmanagedType.U4)] uint fileShare,
       IntPtr securityAttributes,
       [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
       [MarshalAs(UnmanagedType.U4)] int flags,
       IntPtr template);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteConsoleOutput(
          SafeFileHandle hConsoleOutput,
          CharInfo[] lpBuffer,
          Coord dwBufferSize,
          Coord dwBufferCoord,
          ref SmallRect lpWriteRegion);

        [StructLayout(LayoutKind.Sequential)]
        struct Coord
        {
            public short X;
            public short Y;

            public Coord(short X, short Y)
            {
                this.X = X;
                this.Y = Y;
            }
        };

        [StructLayout(LayoutKind.Explicit)]
        struct CharUnion
        {
            [FieldOffset(0)] public char UnicodeChar;
            [FieldOffset(0)] public byte AsciiChar;
        }

        [StructLayout(LayoutKind.Explicit)]
        struct CharInfo
        {
            [FieldOffset(0)] public CharUnion Char;
            [FieldOffset(2)] public short Attributes;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct SmallRect
        {
            public short Left;
            public short Top;
            public short Right;
            public short Bottom;
        }

        SafeFileHandle h;
        int width;
        int height;
        CharInfo[] buf;
        SmallRect rect;

        bool doubleWidth;

        public GameConsole(int width, int height, bool doubleWidth)
        {
            this.doubleWidth = doubleWidth;

            if(this.doubleWidth)
                width *= 2;

            this.width = width;
            this.height = height;

            Console.CursorVisible = false;

            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);

            Console.WindowHeight = height;
            Console.WindowWidth = width;

            h = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
            buf = new CharInfo[width * height];
            rect = new SmallRect() { Left = 0, Top = 0, Right = (short)width, Bottom = (short)height };
        }

        internal void Clear()
        {
            for (int i = 0; i < buf.Length; i++)
            {
                buf[i].Char.UnicodeChar = ' ';
                buf[i].Attributes = 0;
            }
        }

        public void Change(char c, short color, int x, int y)
        {
            Change(c, c, color, x, y);
        }

        public void Change(char leftc, char rightc, short color, int x, int y)
        {
            buf[width * y + x * 2].Char.UnicodeChar = leftc;
            buf[width * y + x * 2].Attributes = color;

            if (doubleWidth)
            {
                buf[width * y + x * 2 + 1].Char.UnicodeChar = rightc;
                buf[width * y + x * 2 + 1].Attributes = color;
            }
        }


        internal void Blit()
        {
            bool b = WriteConsoleOutput(h, buf,
                          new Coord() { X = (short)width, Y = (short)height },
                          new Coord() { X = 0, Y = 0 },
                          ref rect);
        }

        public void Shutdown()
        {
            if(!h.IsClosed)
            {
                h.Close();
            }
        }
    }
}
