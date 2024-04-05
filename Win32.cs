using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MyDirectX
{
    internal class Win32
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////           Win32 API functions&structures      
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(HandleRef hWnd, out Win32.RECT lpRect);

        [DllImport("user32.dll")]
        public static extern IntPtr SetCapture(HandleRef hWnd);
        [DllImport("user32.dll")]
        public static extern long ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(HandleRef hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern bool InvalidateRect(HandleRef hWnd, Win32.RECT lpRect, bool bErase);

        [DllImport("user32.dll")]
        public static extern void PostQuitMessage(int nExitCode);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ScreenToClient(HandleRef hWnd, out Win32.POINT lpRect);

        [DllImport("user32.dll")]
        public static extern IntPtr DefWindowProcW(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);

        [DllImport("user32.dll")]
        public static extern bool ShowCaret(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool SetCaretPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern bool DestroyCaret();

        [DllImport("user32.dll")]
        public static extern bool HideCaret(IntPtr hWnd);


        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);


        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);



        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPOS
        {
            public IntPtr hwnd;
            public IntPtr hwndInsertAfter;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public uint flags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NCCALCSIZE_PARAMS
        {
            //public RECT rgrc[3];
            public Win32.RECT r0;
            public Win32.RECT r1;
            public Win32.RECT r2;

            //public PWINDOWPOS lppos;
            public IntPtr lppos;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;        // x position 
            public int Y;        // y position 
        }

        /*
         * WM_ACTIVATE state values
         */
        const int WA_INACTIVE          = 0,	
            WA_ACTIVE            = 1,	
            WA_CLICKACTIVE       = 2	
            ;

        /*
         * SetWindowPos Flags
         */
        public const int SWP_NOSIZE           = 0x0001,	
            SWP_NOMOVE           = 0x0002,	
            SWP_NOZORDER         = 0x0004,	
            SWP_NOREDRAW         = 0x0008,	
            SWP_NOACTIVATE       = 0x0010,	
            SWP_FRAMECHANGED     = 0x0020,	  /* The frame changed: send WM_NCCALCSIZE */
            SWP_SHOWWINDOW       = 0x0040,	
            SWP_HIDEWINDOW       = 0x0080,	
            SWP_NOCOPYBITS       = 0x0100,	
            SWP_NOOWNERZORDER    = 0x0200,	  /* Don't do owner Z ordering */
            SWP_NOSENDCHANGING   = 0x0400,	  /* Don't send WM_WINDOWPOSCHANGING */
            SWP_DRAWFRAME        = SWP_FRAMECHANGED,
            SWP_NOREPOSITION     = SWP_NOOWNERZORDER,
            SWP_DEFERERASE       = 0x2000,	
            SWP_ASYNCWINDOWPOS   = 0x4000	
            ;

        /*
         * WM_NCHITTEST and MOUSEHOOKSTRUCT Mouse Position Codes
         */
        public const int HTERROR              = (-2),
            HTTRANSPARENT        = (-1),
            HTNOWHERE            = 0,	
            HTCLIENT             = 1,	
            HTCAPTION            = 2,	
            HTSYSMENU            = 3,	
            HTGROWBOX            = 4,	
            HTSIZE               = HTGROWBOX,
            HTMENU               = 5,	
            HTHSCROLL            = 6,	
            HTVSCROLL            = 7,	
            HTMINBUTTON          = 8,	
            HTMAXBUTTON          = 9,	
            HTLEFT               = 10,	
            HTRIGHT              = 11,	
            HTTOP                = 12,	
            HTTOPLEFT            = 13,	
            HTTOPRIGHT           = 14,	
            HTBOTTOM             = 15,	
            HTBOTTOMLEFT         = 16,	
            HTBOTTOMRIGHT        = 17,	
            HTBORDER             = 18,	
            HTREDUCE             = HTMINBUTTON,
            HTZOOM               = HTMAXBUTTON,
            HTSIZEFIRST          = HTLEFT,
            HTSIZELAST           = HTBOTTOMRIGHT,
            HTOBJECT             = 19,	
            HTCLOSE              = 20,	
            HTHELP               = 21	
            ;


        /*
         * ShowWindow() Commands
         */
        public const int SW_HIDE              = 0,	
            SW_SHOWNORMAL        = 1,	
            SW_NORMAL            = 1,	
            SW_SHOWMINIMIZED     = 2,	
            SW_SHOWMAXIMIZED     = 3,	
            SW_MAXIMIZE          = 3,	
            SW_SHOWNOACTIVATE    = 4,	
            SW_SHOW              = 5,	
            SW_MINIMIZE          = 6,	
            SW_SHOWMINNOACTIVE   = 7,	
            SW_SHOWNA            = 8,	
            SW_RESTORE           = 9,	
            SW_SHOWDEFAULT       = 10,	
            SW_FORCEMINIMIZE     = 11,	
            SW_MAX               = 11,	
            SW_PARENTCLOSING     = 1,	
            SW_OTHERZOOM         = 2,	
            SW_PARENTOPENING     = 3,	
            SW_OTHERUNZOOM       = 4,	
            SW_SCROLLCHILDREN    = 0x0001,	  /* Scroll children within *lprcScroll. */
            SW_INVALIDATE        = 0x0002,	  /* Invalidate after scrolling */
            SW_ERASE             = 0x0004,	  /* If SW_INVALIDATE, don't send WM_ERASEBACKGROUND */
            SW_SMOOTHSCROLL      = 0x0010	  /* Use smooth scrolling */
            ;

        /*
         * Class styles
         */
        public const int CS_VREDRAW           = 0x0001,	
            CS_HREDRAW           = 0x0002,	
            CS_DBLCLKS           = 0x0008,	
            CS_OWNDC             = 0x0020,	
            CS_CLASSDC           = 0x0040,	
            CS_PARENTDC          = 0x0080,	
            CS_NOCLOSE           = 0x0200,	
            CS_SAVEBITS          = 0x0800,	
            CS_BYTEALIGNCLIENT   = 0x1000,	
            CS_BYTEALIGNWINDOW   = 0x2000,	
            CS_GLOBALCLASS       = 0x4000,	
            CS_IME               = 0x00010000,	
            CS_DROPSHADOW        = 0x00020000	
            ;


        /*
         * Extended Window Styles
         */

        public const int WS_EX_DLGMODALFRAME  = 0x00000001,	
            WS_EX_NOPARENTNOTIFY = 0x00000004,	
            WS_EX_TOPMOST        = 0x00000008,	
            WS_EX_ACCEPTFILES    = 0x00000010,	
            WS_EX_TRANSPARENT    = 0x00000020,	
            WS_EX_MDICHILD       = 0x00000040,	
            WS_EX_TOOLWINDOW     = 0x00000080,	
            WS_EX_WINDOWEDGE     = 0x00000100,	
            WS_EX_CLIENTEDGE     = 0x00000200,	
            WS_EX_CONTEXTHELP    = 0x00000400,	
            WS_EX_RIGHT          = 0x00001000,	
            WS_EX_LEFT           = 0x00000000,	
            WS_EX_RTLREADING     = 0x00002000,	
            WS_EX_LTRREADING     = 0x00000000,	
            WS_EX_LEFTSCROLLBAR  = 0x00004000,	
            WS_EX_RIGHTSCROLLBAR = 0x00000000,	
            WS_EX_CONTROLPARENT  = 0x00010000,	
            WS_EX_STATICEDGE     = 0x00020000,	
            WS_EX_APPWINDOW      = 0x00040000,	
            WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE|WS_EX_CLIENTEDGE),
            WS_EX_PALETTEWINDOW  = (WS_EX_WINDOWEDGE|WS_EX_TOOLWINDOW|WS_EX_TOPMOST),
            WS_EX_LAYERED        = 0x00080000,	
            WS_EX_NOINHERITLAYOUT = 0x00100000,	 // Disable inheritence of mirroring by children
            WS_EX_NOREDIRECTIONBITMAP = 0x00200000,	
            WS_EX_LAYOUTRTL      = 0x00400000,	 // Right to left mirroring
            WS_EX_COMPOSITED     = 0x02000000,	
            WS_EX_NOACTIVATE     = 0x08000000
            ;


        /*
         * Window Styles
         */
        public const int WS_OVERLAPPED        = 0x00000000,	
            WS_POPUP             = unchecked((int) 0x80000000),	
            WS_CHILD             = 0x40000000,	
            WS_MINIMIZE          = 0x20000000,	
            WS_VISIBLE           = 0x10000000,	
            WS_DISABLED          = 0x08000000,	
            WS_CLIPSIBLINGS      = 0x04000000,	
            WS_CLIPCHILDREN      = 0x02000000,	
            WS_MAXIMIZE          = 0x01000000,	
            WS_CAPTION           = 0x00C00000,	     /* WS_BORDER | WS_DLGFRAME  */
            WS_BORDER            = 0x00800000,	
            WS_DLGFRAME          = 0x00400000,	
            WS_VSCROLL           = 0x00200000,	
            WS_HSCROLL           = 0x00100000,	
            WS_SYSMENU           = 0x00080000,	
            WS_THICKFRAME        = 0x00040000,	
            WS_GROUP             = 0x00020000,	
            WS_TABSTOP           = 0x00010000,	
            WS_MINIMIZEBOX       = 0x00020000,	
            WS_MAXIMIZEBOX       = 0x00010000,	
            WS_TILED             = WS_OVERLAPPED,
            WS_ICONIC            = WS_MINIMIZE,
            WS_SIZEBOX           = WS_THICKFRAME,
            WS_TILEDWINDOW       = WS_OVERLAPPEDWINDOW,
            WS_OVERLAPPEDWINDOW  = (WS_OVERLAPPED|
                                         WS_CAPTION        | 
                                         WS_SYSMENU        | 
                                         WS_THICKFRAME     | 
                                         WS_MINIMIZEBOX    | 
                                         WS_MAXIMIZEBOX),
            WS_POPUPWINDOW       = (WS_POPUP|
                                         WS_BORDER         | 
                                         WS_SYSMENU),
            WS_CHILDWINDOW       = (WS_CHILD),
            WS_ACTIVECAPTION     = 0x0001
            ;


        /*
         * Window Messages
         */

        public const int WM_NULL              = 0x0000,	
            WM_CREATE            = 0x0001,	
            WM_DESTROY           = 0x0002,	
            WM_MOVE              = 0x0003,	
            WM_SIZE              = 0x0005,	
            WM_ACTIVATE          = 0x0006,	
            WM_SETFOCUS          = 0x0007,	
            WM_KILLFOCUS         = 0x0008,	
            WM_ENABLE            = 0x000A,	
            WM_SETREDRAW         = 0x000B,	
            WM_SETTEXT           = 0x000C,	
            WM_GETTEXT           = 0x000D,	
            WM_GETTEXTLENGTH     = 0x000E,	
            WM_PAINT             = 0x000F,	
            WM_CLOSE             = 0x0010,	
            WM_QUERYENDSESSION   = 0x0011,	
            WM_QUERYOPEN         = 0x0013,	
            WM_ENDSESSION        = 0x0016,	
            WM_QUIT              = 0x0012,	
            WM_ERASEBKGND        = 0x0014,	
            WM_SYSCOLORCHANGE    = 0x0015,	
            WM_SHOWWINDOW        = 0x0018,	
            WM_WININICHANGE      = 0x001A,	
            WM_SETTINGCHANGE     = WM_WININICHANGE,
            WM_DEVMODECHANGE     = 0x001B,	
            WM_ACTIVATEAPP       = 0x001C,	
            WM_FONTCHANGE        = 0x001D,	
            WM_TIMECHANGE        = 0x001E,	
            WM_CANCELMODE        = 0x001F,	
            WM_SETCURSOR         = 0x0020,	
            WM_MOUSEACTIVATE     = 0x0021,	
            WM_CHILDACTIVATE     = 0x0022,	
            WM_QUEUESYNC         = 0x0023,	
            WM_GETMINMAXINFO     = 0x0024,	
            WM_PAINTICON         = 0x0026,	
            WM_ICONERASEBKGND    = 0x0027,	
            WM_NEXTDLGCTL        = 0x0028,	
            WM_SPOOLERSTATUS     = 0x002A,	
            WM_DRAWITEM          = 0x002B,	
            WM_MEASUREITEM       = 0x002C,	
            WM_DELETEITEM        = 0x002D,	
            WM_VKEYTOITEM        = 0x002E,	
            WM_CHARTOITEM        = 0x002F,	
            WM_SETFONT           = 0x0030,	
            WM_GETFONT           = 0x0031,	
            WM_SETHOTKEY         = 0x0032,	
            WM_GETHOTKEY         = 0x0033,	
            WM_QUERYDRAGICON     = 0x0037,	
            WM_COMPAREITEM       = 0x0039,	
            WM_GETOBJECT         = 0x003D,	
            WM_COMPACTING        = 0x0041,	
            WM_COMMNOTIFY        = 0x0044,	  /* no longer suported */
            WM_WINDOWPOSCHANGING = 0x0046,	
            WM_WINDOWPOSCHANGED  = 0x0047,	
            WM_POWER             = 0x0048,	
            WM_COPYDATA          = 0x004A,	
            WM_CANCELJOURNAL     = 0x004B,	
            WM_NOTIFY            = 0x004E,	
            WM_INPUTLANGCHANGEREQUEST = 0x0050,	
            WM_INPUTLANGCHANGE   = 0x0051,	
            WM_TCARD             = 0x0052,	
            WM_HELP              = 0x0053,	
            WM_USERCHANGED       = 0x0054,	
            WM_NOTIFYFORMAT      = 0x0055,	
            WM_CONTEXTMENU       = 0x007B,	
            WM_STYLECHANGING     = 0x007C,	
            WM_STYLECHANGED      = 0x007D,	
            WM_DISPLAYCHANGE     = 0x007E,	
            WM_GETICON           = 0x007F,	
            WM_SETICON           = 0x0080,	
            WM_NCCREATE          = 0x0081,	
            WM_NCDESTROY         = 0x0082,	
            WM_NCCALCSIZE        = 0x0083,	
            WM_NCHITTEST         = 0x0084,	
            WM_NCPAINT           = 0x0085,	
            WM_NCACTIVATE        = 0x0086,	
            WM_GETDLGCODE        = 0x0087,	
            WM_SYNCPAINT         = 0x0088,	
            WM_NCMOUSEMOVE       = 0x00A0,	
            WM_NCLBUTTONDOWN     = 0x00A1,	
            WM_NCLBUTTONUP       = 0x00A2,	
            WM_NCLBUTTONDBLCLK   = 0x00A3,	
            WM_NCRBUTTONDOWN     = 0x00A4,	
            WM_NCRBUTTONUP       = 0x00A5,	
            WM_NCRBUTTONDBLCLK   = 0x00A6,	
            WM_NCMBUTTONDOWN     = 0x00A7,	
            WM_NCMBUTTONUP       = 0x00A8,	
            WM_NCMBUTTONDBLCLK   = 0x00A9,	
            WM_NCXBUTTONDOWN     = 0x00AB,	
            WM_NCXBUTTONUP       = 0x00AC,	
            WM_NCXBUTTONDBLCLK   = 0x00AD,	
            WM_INPUT_DEVICE_CHANGE = 0x00FE,	
            WM_INPUT             = 0x00FF,	
            WM_KEYFIRST          = 0x0100,	
            WM_KEYDOWN           = 0x0100,	
            WM_KEYUP             = 0x0101,	
            WM_CHAR              = 0x0102,	
            WM_DEADCHAR          = 0x0103,	
            WM_SYSKEYDOWN        = 0x0104,	
            WM_SYSKEYUP          = 0x0105,	
            WM_SYSCHAR           = 0x0106,	
            WM_SYSDEADCHAR       = 0x0107,	
            WM_UNICHAR           = 0x0109,	
            //WM_KEYLAST           = 0x0109,	
            //WM_KEYLAST           = 0x0108,	
            WM_IME_STARTCOMPOSITION = 0x010D,	
            WM_IME_ENDCOMPOSITION = 0x010E,	
            WM_IME_COMPOSITION   = 0x010F,	
            WM_IME_KEYLAST       = 0x010F,	
            WM_INITDIALOG        = 0x0110,	
            WM_COMMAND           = 0x0111,	
            WM_SYSCOMMAND        = 0x0112,	
            WM_TIMER             = 0x0113,	
            WM_HSCROLL           = 0x0114,	
            WM_VSCROLL           = 0x0115,	
            WM_INITMENU          = 0x0116,	
            WM_INITMENUPOPUP     = 0x0117,	
            WM_GESTURE           = 0x0119,	
            WM_GESTURENOTIFY     = 0x011A,	
            WM_MENUSELECT        = 0x011F,	
            WM_MENUCHAR          = 0x0120,	
            WM_ENTERIDLE         = 0x0121,	
            WM_MENURBUTTONUP     = 0x0122,	
            WM_MENUDRAG          = 0x0123,	
            WM_MENUGETOBJECT     = 0x0124,	
            WM_UNINITMENUPOPUP   = 0x0125,	
            WM_MENUCOMMAND       = 0x0126,	
            WM_CHANGEUISTATE     = 0x0127,	
            WM_UPDATEUISTATE     = 0x0128,	
            WM_QUERYUISTATE      = 0x0129,	
            WM_CTLCOLORMSGBOX    = 0x0132,	
            WM_CTLCOLOREDIT      = 0x0133,	
            WM_CTLCOLORLISTBOX   = 0x0134,	
            WM_CTLCOLORBTN       = 0x0135,	
            WM_CTLCOLORDLG       = 0x0136,	
            WM_CTLCOLORSCROLLBAR = 0x0137,	
            WM_CTLCOLORSTATIC    = 0x0138,	
            WM_MOUSEFIRST        = 0x0200,	
            WM_MOUSEMOVE         = 0x0200,	
            WM_LBUTTONDOWN       = 0x0201,	
            WM_LBUTTONUP         = 0x0202,	
            WM_LBUTTONDBLCLK     = 0x0203,	
            WM_RBUTTONDOWN       = 0x0204,	
            WM_RBUTTONUP         = 0x0205,	
            WM_RBUTTONDBLCLK     = 0x0206,	
            WM_MBUTTONDOWN       = 0x0207,	
            WM_MBUTTONUP         = 0x0208,	
            WM_MBUTTONDBLCLK     = 0x0209,	
            WM_MOUSEWHEEL        = 0x020A,	
            WM_XBUTTONDOWN       = 0x020B,	
            WM_XBUTTONUP         = 0x020C,	
            WM_XBUTTONDBLCLK     = 0x020D,	
            WM_MOUSEHWHEEL       = 0x020E,	
            //WM_MOUSELAST         = 0x020E,	
            //WM_MOUSELAST         = 0x020D,	
            //WM_MOUSELAST         = 0x020A,	
            //WM_MOUSELAST         = 0x0209,	
            WM_PARENTNOTIFY      = 0x0210,	
            WM_ENTERMENULOOP     = 0x0211,	
            WM_EXITMENULOOP      = 0x0212,	
            WM_NEXTMENU          = 0x0213,	
            WM_SIZING            = 0x0214,	
            WM_CAPTURECHANGED    = 0x0215,	
            WM_MOVING            = 0x0216,	
            WM_POWERBROADCAST    = 0x0218,	
            WM_DEVICECHANGE      = 0x0219,	
            WM_MDICREATE         = 0x0220,	
            WM_MDIDESTROY        = 0x0221,	
            WM_MDIACTIVATE       = 0x0222,	
            WM_MDIRESTORE        = 0x0223,	
            WM_MDINEXT           = 0x0224,	
            WM_MDIMAXIMIZE       = 0x0225,	
            WM_MDITILE           = 0x0226,	
            WM_MDICASCADE        = 0x0227,	
            WM_MDIICONARRANGE    = 0x0228,	
            WM_MDIGETACTIVE      = 0x0229,	
            WM_MDISETMENU        = 0x0230,	
            WM_ENTERSIZEMOVE     = 0x0231,	
            WM_EXITSIZEMOVE      = 0x0232,	
            WM_DROPFILES         = 0x0233,	
            WM_MDIREFRESHMENU    = 0x0234,	
            WM_POINTERDEVICECHANGE = 0x238,	
            WM_POINTERDEVICEINRANGE = 0x239,	
            WM_POINTERDEVICEOUTOFRANGE = 0x23A,	
            WM_TOUCH             = 0x0240,	
            WM_NCPOINTERUPDATE   = 0x0241,	
            WM_NCPOINTERDOWN     = 0x0242,	
            WM_NCPOINTERUP       = 0x0243,	
            WM_POINTERUPDATE     = 0x0245,	
            WM_POINTERDOWN       = 0x0246,	
            WM_POINTERUP         = 0x0247,	
            WM_POINTERENTER      = 0x0249,	
            WM_POINTERLEAVE      = 0x024A,	
            WM_POINTERACTIVATE   = 0x024B,	
            WM_POINTERCAPTURECHANGED = 0x024C,	
            WM_TOUCHHITTESTING   = 0x024D,	
            WM_POINTERWHEEL      = 0x024E,	
            WM_POINTERHWHEEL     = 0x024F,	
            WM_IME_SETCONTEXT    = 0x0281,	
            WM_IME_NOTIFY        = 0x0282,	
            WM_IME_CONTROL       = 0x0283,	
            WM_IME_COMPOSITIONFULL = 0x0284,	
            WM_IME_SELECT        = 0x0285,	
            WM_IME_CHAR          = 0x0286,	
            WM_IME_REQUEST       = 0x0288,	
            WM_IME_KEYDOWN       = 0x0290,	
            WM_IME_KEYUP         = 0x0291,	
            WM_MOUSEHOVER        = 0x02A1,	
            WM_MOUSELEAVE        = 0x02A3,	
            WM_NCMOUSEHOVER      = 0x02A0,	
            WM_NCMOUSELEAVE      = 0x02A2,	
            WM_WTSSESSION_CHANGE = 0x02B1,	
            WM_TABLET_FIRST      = 0x02c0,	
            WM_TABLET_LAST       = 0x02df,	
            WM_DPICHANGED        = 0x02E0,	
            WM_CUT               = 0x0300,	
            WM_COPY              = 0x0301,	
            WM_PASTE             = 0x0302,	
            WM_CLEAR             = 0x0303,	
            WM_UNDO              = 0x0304,	
            WM_RENDERFORMAT      = 0x0305,	
            WM_RENDERALLFORMATS  = 0x0306,	
            WM_DESTROYCLIPBOARD  = 0x0307,	
            WM_DRAWCLIPBOARD     = 0x0308,	
            WM_PAINTCLIPBOARD    = 0x0309,	
            WM_VSCROLLCLIPBOARD  = 0x030A,	
            WM_SIZECLIPBOARD     = 0x030B,	
            WM_ASKCBFORMATNAME   = 0x030C,	
            WM_CHANGECBCHAIN     = 0x030D,	
            WM_HSCROLLCLIPBOARD  = 0x030E,	
            WM_QUERYNEWPALETTE   = 0x030F,	
            WM_PALETTEISCHANGING = 0x0310,	
            WM_PALETTECHANGED    = 0x0311,	
            WM_HOTKEY            = 0x0312,	
            WM_PRINT             = 0x0317,	
            WM_PRINTCLIENT       = 0x0318,	
            WM_APPCOMMAND        = 0x0319,	
            WM_THEMECHANGED      = 0x031A,	
            WM_CLIPBOARDUPDATE   = 0x031D,	
            WM_DWMCOMPOSITIONCHANGED = 0x031E,	
            WM_DWMNCRENDERINGCHANGED = 0x031F,	
            WM_DWMCOLORIZATIONCOLORCHANGED = 0x0320,	
            WM_DWMWINDOWMAXIMIZEDCHANGE = 0x0321,	
            WM_DWMSENDICONICTHUMBNAIL = 0x0323,	
            WM_DWMSENDICONICLIVEPREVIEWBITMAP = 0x0326,	
            WM_GETTITLEBARINFOEX = 0x033F,	
            WM_HANDHELDFIRST     = 0x0358,	
            WM_HANDHELDLAST      = 0x035F,	
            WM_AFXFIRST          = 0x0360,	
            WM_AFXLAST           = 0x037F,	
            WM_PENWINFIRST       = 0x0380,	
            WM_PENWINLAST        = 0x038F,	
            WM_APP               = 0x8000,	
            WM_USER              = 0x0400
            ;

        /*
         * System metrics
         */

        public const int SM_CXSCREEN          = 0,
            SM_CYSCREEN          = 1,	
            SM_CXVSCROLL         = 2,	
            SM_CYHSCROLL         = 3,	
            SM_CYCAPTION         = 4,	
            SM_CXBORDER          = 5,	
            SM_CYBORDER          = 6,	
            SM_CXDLGFRAME        = 7,	
            SM_CYDLGFRAME        = 8,	
            SM_CYVTHUMB          = 9,	
            SM_CXHTHUMB          = 10,	
            SM_CXICON            = 11,	
            SM_CYICON            = 12,	
            SM_CXCURSOR          = 13,	
            SM_CYCURSOR          = 14,	
            SM_CYMENU            = 15,	
            SM_CXFULLSCREEN      = 16,	
            SM_CYFULLSCREEN      = 17,	
            SM_CYKANJIWINDOW     = 18,	
            SM_MOUSEPRESENT      = 19,	
            SM_CYVSCROLL         = 20,	
            SM_CXHSCROLL         = 21,	
            SM_DEBUG             = 22,	
            SM_SWAPBUTTON        = 23,	
            SM_RESERVED1         = 24,	
            SM_RESERVED2         = 25,	
            SM_RESERVED3         = 26,	
            SM_RESERVED4         = 27,	
            SM_CXMIN             = 28,	
            SM_CYMIN             = 29,	
            SM_CXSIZE            = 30,	
            SM_CYSIZE            = 31,	
            SM_CXFRAME           = 32,	
            SM_CYFRAME           = 33,	
            SM_CXMINTRACK        = 34,	
            SM_CYMINTRACK        = 35,	
            SM_CXDOUBLECLK       = 36,	
            SM_CYDOUBLECLK       = 37,	
            SM_CXICONSPACING     = 38,	
            SM_CYICONSPACING     = 39,	
            SM_MENUDROPALIGNMENT = 40,	
            SM_PENWINDOWS        = 41,	
            SM_DBCSENABLED       = 42,	
            SM_CMOUSEBUTTONS     = 43,	
            SM_CXFIXEDFRAME      = SM_CXDLGFRAME/*;win40namechange*/,
            SM_CYFIXEDFRAME      = SM_CYDLGFRAME/*;win40namechange*/,
            SM_CXSIZEFRAME       = SM_CXFRAME/*;win40namechange*/,
            SM_CYSIZEFRAME       = SM_CYFRAME/*;win40namechange*/,
            SM_SECURE            = 44,	
            SM_CXEDGE            = 45,	
            SM_CYEDGE            = 46,	
            SM_CXMINSPACING      = 47,	
            SM_CYMINSPACING      = 48,	
            SM_CXSMICON          = 49,	
            SM_CYSMICON          = 50,	
            SM_CYSMCAPTION       = 51,	
            SM_CXSMSIZE          = 52,	
            SM_CYSMSIZE          = 53,	
            SM_CXMENUSIZE        = 54,	
            SM_CYMENUSIZE        = 55,	
            SM_ARRANGE           = 56,	
            SM_CXMINIMIZED       = 57,	
            SM_CYMINIMIZED       = 58,	
            SM_CXMAXTRACK        = 59,	
            SM_CYMAXTRACK        = 60,	
            SM_CXMAXIMIZED       = 61,	
            SM_CYMAXIMIZED       = 62,	
            SM_NETWORK           = 63,	
            SM_CLEANBOOT         = 67,	
            SM_CXDRAG            = 68,	
            SM_CYDRAG            = 69,	
            SM_SHOWSOUNDS        = 70,	
            SM_CXMENUCHECK       = 71,	   /* Use instead of GetMenuCheckMarkDimensions()! */
            SM_CYMENUCHECK       = 72,	
            SM_SLOWMACHINE       = 73,	
            SM_MIDEASTENABLED    = 74,	
            SM_MOUSEWHEELPRESENT = 75,	
            SM_XVIRTUALSCREEN    = 76,	
            SM_YVIRTUALSCREEN    = 77,	
            SM_CXVIRTUALSCREEN   = 78,	
            SM_CYVIRTUALSCREEN   = 79,	
            SM_CMONITORS         = 80,	
            SM_SAMEDISPLAYFORMAT = 81,	
            SM_IMMENABLED        = 82,	
            SM_CXFOCUSBORDER     = 83,	
            SM_CYFOCUSBORDER     = 84,	
            SM_TABLETPC          = 86,	
            SM_MEDIACENTER       = 87,	
            SM_STARTER           = 88,	
            SM_SERVERR2          = 89,	
            SM_MOUSEHORIZONTALWHEELPRESENT = 91,	
            SM_CXPADDEDBORDER    = 92,	
            SM_DIGITIZER         = 94,	
            SM_MAXIMUMTOUCHES    = 95,	
            SM_CMETRICS          = 76,	
            //SM_CMETRICS          = 83,	
            //SM_CMETRICS          = 91,	
            //SM_CMETRICS          = 93,	
            //SM_CMETRICS          = 97,	
            SM_REMOTESESSION     = 0x1000,	
            SM_SHUTTINGDOWN      = 0x2000,	
            SM_REMOTECONTROL     = 0x2001,	
            SM_CARETBLINKINGENABLED = 0x2002,	
            SM_CONVERTIBLESLATEMODE = 0x2003,	
            SM_SYSTEMDOCKED      = 0x2004	
            ;

    }
}
