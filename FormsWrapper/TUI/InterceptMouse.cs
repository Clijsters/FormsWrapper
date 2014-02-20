using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

//TODO: Create good code, remove this sample.
//This class isn't good. Look at MouseHook.cs and KeyboardHook.cs instead.

#region oldStuff
namespace FormsWrapper.TUI
{
    [ComVisible(true)]
    public class InterceptMouse
    {
        private static LowLevelMouseProc mouseProc = HookCallback;
        private static IntPtr hookID = IntPtr.Zero;
        private static Process curProcess;
        private static Rect MyRectangle = new Rect();
        private static IntPtr ptr;


        public static void Hook()
        {
            hookID = SetHook(mouseProc);
            ptr = curProcess.MainWindowHandle;
            GetWindowRect(ptr, ref MyRectangle);
            Console.WriteLine("Window Position: " + MyRectangle.Left + " x " + MyRectangle.Top);
        }

        public static void UnHook()
        {
            UnhookWindowsHookEx(hookID);
        }

        private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            curProcess = Process.GetCurrentProcess();
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        public delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
            {
                GetWindowRect(ptr, ref MyRectangle);
                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                int calcedX = hookStruct.pt.x - MyRectangle.Left - 10;
                int calcedY = hookStruct.pt.y - MyRectangle.Top - 31;
                //TODO: Find a way to get Console font size without using Win's Registry
                int coordX = calcedX / 8;
                int coordY = calcedY / 12;                
                //Console.WriteLine("Mouse Click: " + calcedX + ", " + calcedY + " Coordinates: " + coordX + " x " + coordY);
                int curLeft = Console.CursorLeft;
                int curTop = Console.CursorTop;
                Console.SetCursorPosition(coordX, coordY);
                Console.Write("A");
                Console.SetCursorPosition(curLeft, curTop);
            }
            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }

        private const int WH_MOUSE_LL = 14;

        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }

        [StructLayout(LayoutKind.Sequential)]
        struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
#endregion