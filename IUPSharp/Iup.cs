using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;


namespace IUPSharp
{

    public delegate int Icallback(IntPtr handle);
    public delegate int ISizecallback(IntPtr handle, int widht, int height);
    public delegate int Iparamcb(IntPtr dialog, int param_index, IntPtr user_data);

    /************************************************************************/
    /*               SHOW_CB Callback Values                                */
    /************************************************************************/
    public enum SHOW_CB { IUP_SHOW, IUP_RESTORE, IUP_MINIMIZE, IUP_MAXIMIZE, IUP_HIDE }

    /************************************************************************/
    /*               SCROLL_CB Callback Values                              */
    /************************************************************************/
    public enum SCROLL_CB
    {
        IUP_SBUP, IUP_SBDN, IUP_SBPGUP, IUP_SBPGDN, IUP_SBPOSV, IUP_SBDRAGV,
        IUP_SBLEFT, IUP_SBRIGHT, IUP_SBPGLEFT, IUP_SBPGRIGHT, IUP_SBPOSH, IUP_SBDRAGH
    }

    public class Iup
    {

        /************************************************************************/
        /*                   Common Flags and Return Values                     */
        /************************************************************************/
        public const int IUP_ERROR = 1;
        public const int IUP_NOERROR = 0;
        public const int IUP_OPENED = -1;
        public const int IUP_INVALID = -1;
        public const int IUP_INVALID_ID = -10;


        /************************************************************************/
        /*                   Callback Return Values                             */
        /************************************************************************/
        public const int IUP_IGNORE = -1;
        public const int IUP_DEFAULT = -2;
        public const int IUP_CLOSE = -3;
        public const int IUP_CONTINUE = -4;

        /************************************************************************/
        /*           IupPopup and IupShowXY Parameter Values                    */
        /************************************************************************/
        public const int IUP_CENTER = 0xFFFF;  /* 65535 */
        public const int IUP_LEFT = 0xFFFE;  /* 65534 */
        public const int IUP_RIGHT = 0xFFFD;  /* 65533 */
        public const int IUP_MOUSEPOS = 0xFFFC;  /* 65532 */
        public const int IUP_CURRENT = 0xFFFB;  /* 65531 */
        public const int IUP_CENTERPARENT = 0xFFFA;  /* 65530 */
        public const int IUP_LEFTPARENT = 0xFFF9;  /* 65529 */
        public const int IUP_RIGHTPARENT = 0xFFF8;  /* 65528 */
        public const int IUP_TOP = IUP_LEFT;
        public const int IUP_BOTTOM = IUP_RIGHT;
        public const int IUP_TOPPARENT = IUP_LEFTPARENT;
        public const int IUP_BOTTOMPARENT = IUP_RIGHTPARENT;



        /************************************************************************/
        /*               Mouse Button Values and Macros                         */
        /************************************************************************/
        public const char IUP_BUTTON1 = '1';
        public const char IUP_BUTTON2 = '2';
        public const char IUP_BUTTON3 = '3';
        public const char IUP_BUTTON4 = '4';
        public const char IUP_BUTTON5 = '5';
        /************************************************************************/
        /*                      Pre-Defined Masks                               */
        /************************************************************************/
        public const string IUP_MASK_FLOAT = "[+/-]?(/d+/.?/d*|/./d+)";
        public const string IUP_MASK_UFLOAT = "(/d+/.?/d*|/./d+)";
        public const string IUP_MASK_EFLOAT = "[+/-]?(/d+/.?/d*|/./d+)([eE][+/-]?/d+)?";
        public const string IUP_MASK_UEFLOAT = "(/d+/.?/d*|/./d+)([eE][+/-]?/d+)?";
        public const string IUP_MASK_FLOATCOMMA = "[+/-]?(/d+/,?/d*|/,/d+)";
        public const string IUP_MASK_UFLOATCOMMA = "(/d+/,?/d*|/,/d+)";
        public const string IUP_MASK_INT = "[+/-]?/d+";
        public const string IUP_MASK_UINT = "/d+";


        /************************************************************************/
        /*                   IupGetParam Callback situations                    */
        /************************************************************************/
        public const int IUP_GETPARAM_BUTTON1 = -1;
        public const int IUP_GETPARAM_INIT = -2;
        public const int IUP_GETPARAM_BUTTON2 = -3;
        public const int IUP_GETPARAM_BUTTON3 = -4;
        public const int IUP_GETPARAM_CLOSE = -5;
        public const int IUP_GETPARAM_MAP = -6;
        public const int IUP_GETPARAM_OK = IUP_GETPARAM_BUTTON1;
        public const int IUP_GETPARAM_CANCEL = IUP_GETPARAM_BUTTON2;
        public const int IUP_GETPARAM_HELP = IUP_GETPARAM_BUTTON3;

        /************************************************************************/
        /*                   Used by IupColorbar                                */
        /************************************************************************/
        public const int IUP_PRIMARY = -1;
        public const int IUP_SECONDARY = -2;



#if WIN64
        const string IUP_DLL = "win64/iup.dll";
#else
        const string IUP_DLL = "win64/iup.dll";
#endif


        [DllImport(IUP_DLL, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int IupOpen(IntPtr argc, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPTStr)] string[] argv);

        [DllImport(IUP_DLL)] public static extern void IupClose();
        [DllImport(IUP_DLL)] public static extern int IupIsOpened();

        [DllImport(IUP_DLL)] public static extern void IupImageLibOpen();

        [DllImport(IUP_DLL)] public static extern int IupMainLoop();
        [DllImport(IUP_DLL)] public static extern int IupLoopStep();
        [DllImport(IUP_DLL)] public static extern int IupLoopStepWait();
        [DllImport(IUP_DLL)] public static extern int IupMainLoopLevel();
        [DllImport(IUP_DLL)] public static extern void IupFlush();
        [DllImport(IUP_DLL)] public static extern void IupExitLoop();
        [DllImport(IUP_DLL)] public static extern void IupPostMessage(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string s, int i, double d, IntPtr p);

        [DllImport(IUP_DLL)] public static extern int IupRecordInput(string filename, int mode);
        [DllImport(IUP_DLL)] public static extern int IupPlayInput(string filename);

        [DllImport(IUP_DLL)] public static extern void IupUpdate(IntPtr ih);
        [DllImport(IUP_DLL)] public static extern void IupUpdateChildren(IntPtr ih);
        [DllImport(IUP_DLL)] public static extern void IupRedraw(IntPtr ih, int children);
        [DllImport(IUP_DLL)] public static extern void IupRefresh(IntPtr ih);
        [DllImport(IUP_DLL)] public static extern void IupRefreshChildren(IntPtr ih);

        [DllImport(IUP_DLL)] public static extern int IupExecute(string filename, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string parameters);
        [DllImport(IUP_DLL)] public static extern int IupExecuteWait(string filename, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string parameters);
        [DllImport(IUP_DLL)] public static extern int IupHelp(string url);
        [DllImport(IUP_DLL)] public static extern void IupLog(string type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string format);

        [DllImport(IUP_DLL)] public static extern string IupLoad(string filename);
        [DllImport(IUP_DLL)] public static extern string IupLoadBuffer(string buffer);

        [DllImport(IUP_DLL)] public static extern string IupVersion();
        [DllImport(IUP_DLL)] public static extern string IupVersionDate();
        [DllImport(IUP_DLL)] public static extern int IupVersionNumber();
        [DllImport(IUP_DLL)] public static extern void IupVersionShow();

        [DllImport(IUP_DLL)] public static extern void IupSetLanguage(string lng);
        [DllImport(IUP_DLL)] public static extern string IupGetLanguage();
        [DllImport(IUP_DLL)] public static extern void IupSetLanguageString(string name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string str);
        [DllImport(IUP_DLL)] public static extern void IupStoreLanguageString(string name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string str);
        [DllImport(IUP_DLL)] public static extern string IupGetLanguageString(string name);
        [DllImport(IUP_DLL)] public static extern void IupSetLanguagePack(IntPtr ih);

        [DllImport(IUP_DLL)] public static extern void IupDestroy(IntPtr ih);
        [DllImport(IUP_DLL)] public static extern void IupDetach(IntPtr child);
        [DllImport(IUP_DLL)] public static extern IntPtr IupAppend(IntPtr ih, IntPtr child);
        [DllImport(IUP_DLL)] public static extern IntPtr IupInsert(IntPtr ih, IntPtr ref_child, IntPtr child);
        [DllImport(IUP_DLL)] public static extern IntPtr IupGetChild(IntPtr ih, int pos);
        [DllImport(IUP_DLL)] public static extern int IupGetChildPos(IntPtr ih, IntPtr child);
        [DllImport(IUP_DLL)] public static extern int IupGetChildCount(IntPtr ih);
        [DllImport(IUP_DLL)] public static extern IntPtr IupGetNextChild(IntPtr ih, IntPtr child);
        [DllImport(IUP_DLL)] public static extern IntPtr IupGetBrother(IntPtr ih);
        [DllImport(IUP_DLL)] public static extern IntPtr IupGetParent(IntPtr ih);
        [DllImport(IUP_DLL)] public static extern IntPtr IupGetDialog(IntPtr ih);
        [DllImport(IUP_DLL)] public static extern IntPtr IupGetDialogChild(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name);
        [DllImport(IUP_DLL)] public static extern int IupReparent(IntPtr ih, IntPtr new_parent, IntPtr ref_child);

        [DllImport(IUP_DLL)] public static extern int IupPopup(IntPtr ih, int x, int y);
        [DllImport(IUP_DLL)] public static extern int IupShow(IntPtr ih);
        [DllImport(IUP_DLL)] public static extern int IupShowXY(IntPtr ih, int x, int y);
        [DllImport(IUP_DLL)] public static extern int IupHide(IntPtr ih);
        [DllImport(IUP_DLL)] public static extern int IupMap(IntPtr ih);
        [DllImport(IUP_DLL)] public static extern void IupUnmap(IntPtr ih);

        [DllImport(IUP_DLL)] public static extern void IupResetAttribute(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name);
        [DllImport(IUP_DLL)] public static extern int IupGetAllAttributes(IntPtr ih, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPTStr)] string[] names, int n);
        [DllImport(IUP_DLL)] public static extern void IupCopyAttributes(IntPtr src_ih, IntPtr dst_ih);
        [DllImport(IUP_DLL)] public static extern IntPtr IupSetAtt(string handle_name, IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, params string[] extra);
        [DllImport(IUP_DLL)] public static extern IntPtr IupSetAttributes(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string str);
        [DllImport(IUP_DLL)] public static extern string IupGetAttributes(IntPtr ih);

        [DllImport(IUP_DLL)] public static extern void IupSetAttribute(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))]string value);
        [DllImport(IUP_DLL)] public static extern void IupSetStrAttribute(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string value);
        [DllImport(IUP_DLL)] public static extern void IupSetStrf(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string format, params string[] extra);
        [DllImport(IUP_DLL)] public static extern void IupSetInt(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int value);
        [DllImport(IUP_DLL)] public static extern void IupSetFloat(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, float value);
        [DllImport(IUP_DLL)] public static extern void IupSetDouble(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, double value);
        [DllImport(IUP_DLL)] public static extern void IupSetRGB(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, byte r, byte g, byte b);
        [DllImport(IUP_DLL)] public static extern void IupSetRGBA(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, byte r, byte g, byte b, byte a);

        [DllImport(IUP_DLL)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))]
        public static extern string IupGetAttribute(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name);

        [DllImport(IUP_DLL)] public static extern int IupGetInt(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name);
        [DllImport(IUP_DLL)] public static extern int IupGetInt2(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name);
        [DllImport(IUP_DLL)] public static extern int IupGetIntInt(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int[] i1, int[] i2);
        [DllImport(IUP_DLL)] public static extern float IupGetFloat(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name);
        [DllImport(IUP_DLL)] public static extern double IupGetDouble(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name);
        [DllImport(IUP_DLL)] public static extern void IupGetRGB(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string r, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string g, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string b);
        [DllImport(IUP_DLL)] public static extern void IupGetRGBA(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string r, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string g, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string b, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string a);

        [DllImport(IUP_DLL)] public static extern void IupSetAttributeId(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int id, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string value);
        [DllImport(IUP_DLL)] public static extern void IupSetStrAttributeId(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int id, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string value);
        [DllImport(IUP_DLL)] public static extern void IupSetStrfId(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int id, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string format, params string[] extra);
        [DllImport(IUP_DLL)] public static extern void IupSetIntId(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int id, int value);
        [DllImport(IUP_DLL)] public static extern void IupSetFloatId(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int id, float value);
        [DllImport(IUP_DLL)] public static extern void IupSetDoubleId(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int id, double value);
        [DllImport(IUP_DLL)] public static extern void IupSetRGBId(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int id, byte r, byte g, byte b);

        [DllImport(IUP_DLL)] public static extern string IupGetAttributeId(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int id);
        [DllImport(IUP_DLL)] public static extern int IupGetIntId(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int id);
        [DllImport(IUP_DLL)] public static extern float IupGetFloatId(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int id);
        [DllImport(IUP_DLL)] public static extern double IupGetDoubleId(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int id);
        [DllImport(IUP_DLL)] public static extern void IupGetRGBId(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int id, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string r, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string g, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string b);

        [DllImport(IUP_DLL)] public static extern void IupSetAttributeId2(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int lin, int col, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string value);
        [DllImport(IUP_DLL)] public static extern void IupSetStrAttributeId2(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int lin, int col, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string value);
        [DllImport(IUP_DLL)] public static extern void IupSetStrfId2(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int lin, int col, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string format, params string[] extra);
        [DllImport(IUP_DLL)] public static extern void IupSetIntId2(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int lin, int col, int value);
        [DllImport(IUP_DLL)] public static extern void IupSetFloatId2(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int lin, int col, float value);
        [DllImport(IUP_DLL)] public static extern void IupSetDoubleId2(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int lin, int col, double value);
        [DllImport(IUP_DLL)] public static extern void IupSetRGBId2(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int lin, int col, byte r, byte g, byte b);

        [DllImport(IUP_DLL)] public static extern string IupGetAttributeId2(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int lin, int col);
        [DllImport(IUP_DLL)] public static extern int IupGetIntId2(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int lin, int col);
        [DllImport(IUP_DLL)] public static extern float IupGetFloatId2(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int lin, int col);
        [DllImport(IUP_DLL)] public static extern double IupGetDoubleId2(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int lin, int col);
        [DllImport(IUP_DLL)] public static extern void IupGetRGBId2(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int lin, int col, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string r, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string g, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string b);

        [DllImport(IUP_DLL)] public static extern void IupSetGlobal(string name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string value);
        [DllImport(IUP_DLL)] public static extern void IupSetStrGlobal(string name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string value);
        [DllImport(IUP_DLL)] public static extern string IupGetGlobal(string name);

        [DllImport(IUP_DLL)] public static extern IntPtr IupSetFocus(IntPtr ih);
        [DllImport(IUP_DLL)] public static extern IntPtr IupGetFocus();
        [DllImport(IUP_DLL)] public static extern IntPtr IupPreviousField(IntPtr ih);
        [DllImport(IUP_DLL)] public static extern IntPtr IupNextField(IntPtr ih);

        [DllImport(IUP_DLL)] public static extern Icallback IupGetCallback(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name);
        [DllImport(IUP_DLL)] public static extern Icallback IupSetCallback(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, Icallback func);
        [DllImport(IUP_DLL)] public static extern Icallback IupSetCallback(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, ISizecallback func);
        [DllImport(IUP_DLL)] public static extern IntPtr IupSetCallbacks(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, Icallback func, params string[] extra);

        [DllImport(IUP_DLL)] public static extern Icallback IupGetFunction(string name);
        [DllImport(IUP_DLL)] public static extern Icallback IupSetFunction(string name, Icallback func);

        [DllImport(IUP_DLL)] public static extern IntPtr IupGetHandle(string name);
        [DllImport(IUP_DLL)] public static extern IntPtr IupSetHandle(string name, IntPtr ih);
        [DllImport(IUP_DLL)] public static extern int IupGetAllNames([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPTStr)] string[] names, int n);
        [DllImport(IUP_DLL)] public static extern int IupGetAllDialogs([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPTStr)] string[] names, int n);
        [DllImport(IUP_DLL)] public static extern string IupGetName(IntPtr ih);

        [DllImport(IUP_DLL)] public static extern void IupSetAttributeHandle(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, IntPtr ih_named);
        [DllImport(IUP_DLL)] public static extern IntPtr IupGetAttributeHandle(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name);
        [DllImport(IUP_DLL)] public static extern void IupSetAttributeHandleId(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int id, IntPtr ih_named);
        [DllImport(IUP_DLL)] public static extern IntPtr IupGetAttributeHandleId(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int id);
        [DllImport(IUP_DLL)] public static extern void IupSetAttributeHandleId2(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int lin, int col, IntPtr ih_named);
        [DllImport(IUP_DLL)] public static extern IntPtr IupGetAttributeHandleId2(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int lin, int col);

        [DllImport(IUP_DLL)]
        [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))]
        public static extern string IupGetClassName(IntPtr ih);
        [DllImport(IUP_DLL)] public static extern string IupGetClassType(IntPtr ih);
        [DllImport(IUP_DLL)] public static extern int IupGetAllClasses([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPTStr)] string[] names, int n);
        [DllImport(IUP_DLL)] public static extern int IupGetClassAttributes(string classname, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPTStr)] string[] names, int n);
        [DllImport(IUP_DLL)] public static extern int IupGetClassCallbacks(string classname, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPTStr)] string[] names, int n);
        [DllImport(IUP_DLL)] public static extern void IupSaveClassAttributes(IntPtr ih);
        [DllImport(IUP_DLL)] public static extern void IupCopyClassAttributes(IntPtr src_ih, IntPtr dst_ih);
        [DllImport(IUP_DLL)] public static extern void IupSetClassDefaultAttribute(string classname, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string value);
        [DllImport(IUP_DLL)] public static extern int IupClassMatch(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string classname);

        [DllImport(IUP_DLL)] public static extern IntPtr IupCreate(string classname);
        [DllImport(IUP_DLL)] public static extern IntPtr IupCreatev(string classname, IntPtr[] parameters);
        [DllImport(IUP_DLL)] public static extern IntPtr IupCreatep(string classname, IntPtr first, params string[] extra);

        /************************************************************************/
        /*                        Elements                                      */
        /************************************************************************/

        [DllImport(IUP_DLL)] public static extern IntPtr IupFill();
        [DllImport(IUP_DLL)] public static extern IntPtr IupSpace();

        [DllImport(IUP_DLL)] public static extern IntPtr IupRadio(IntPtr child);
        [DllImport(IUP_DLL)] public static extern IntPtr IupVbox(IntPtr child, params string[] extra);
        [DllImport(IUP_DLL)] public static extern IntPtr IupVboxv(params IntPtr[] children);
        [DllImport(IUP_DLL)] public static extern IntPtr IupZbox(IntPtr child, params string[] extra);
        [DllImport(IUP_DLL)] public static extern IntPtr IupZboxv(params IntPtr[] children);
        [DllImport(IUP_DLL)] public static extern IntPtr IupHbox(IntPtr child, params string[] extra);
        [DllImport(IUP_DLL)] public static extern IntPtr IupHboxv(params IntPtr[] children);

        [DllImport(IUP_DLL)] public static extern IntPtr IupNormalizer(IntPtr ih_first, params string[] extra);
        [DllImport(IUP_DLL)] public static extern IntPtr IupNormalizerv(params IntPtr[] ih_list);

        [DllImport(IUP_DLL)] public static extern IntPtr IupCbox(IntPtr child, params string[] extra);
        [DllImport(IUP_DLL)] public static extern IntPtr IupCboxv(params IntPtr[] children);
        [DllImport(IUP_DLL)] public static extern IntPtr IupSbox(IntPtr child);
        [DllImport(IUP_DLL)] public static extern IntPtr IupSplit(IntPtr child1, IntPtr child2);
        [DllImport(IUP_DLL)] public static extern IntPtr IupScrollBox(IntPtr child);
        [DllImport(IUP_DLL)] public static extern IntPtr IupFlatScrollBox(IntPtr child);
        [DllImport(IUP_DLL)] public static extern IntPtr IupGridBox(IntPtr child, params string[] extra);
        [DllImport(IUP_DLL)] public static extern IntPtr IupGridBoxv(params IntPtr[] children);
        [DllImport(IUP_DLL)] public static extern IntPtr IupMultiBox(IntPtr child, params string[] extra);
        [DllImport(IUP_DLL)] public static extern IntPtr IupMultiBoxv(params IntPtr[] children);
        [DllImport(IUP_DLL)] public static extern IntPtr IupExpander(IntPtr child);
        [DllImport(IUP_DLL)] public static extern IntPtr IupDetachBox(IntPtr child);
        [DllImport(IUP_DLL)] public static extern IntPtr IupBackgroundBox(IntPtr child);

        [DllImport(IUP_DLL)] public static extern IntPtr IupFrame(IntPtr child);
        [DllImport(IUP_DLL)] public static extern IntPtr IupFlatFrame(IntPtr child);

        [DllImport(IUP_DLL)] public static extern IntPtr IupImage(int width, int height, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string pixels);
        [DllImport(IUP_DLL)] public static extern IntPtr IupImageRGB(int width, int height, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string pixels);
        [DllImport(IUP_DLL)] public static extern IntPtr IupImageRGBA(int width, int height, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string pixels);

        [DllImport(IUP_DLL)] public static extern IntPtr IupItem(string title, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string action);
        [DllImport(IUP_DLL)] public static extern IntPtr IupSubmenu(string title, IntPtr child);
        [DllImport(IUP_DLL)] public static extern IntPtr IupSeparator();
        [DllImport(IUP_DLL)] public static extern IntPtr IupMenu(IntPtr child, params string[] extra);
        [DllImport(IUP_DLL)] public static extern IntPtr IupMenuv(params IntPtr[] children);

        [DllImport(IUP_DLL)] public static extern IntPtr IupButton(string title, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string action);
        [DllImport(IUP_DLL)] public static extern IntPtr IupFlatButton([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string title);
        [DllImport(IUP_DLL)] public static extern IntPtr IupFlatToggle(string title);
        [DllImport(IUP_DLL)] public static extern IntPtr IupDropButton(IntPtr dropchild);
        [DllImport(IUP_DLL)] public static extern IntPtr IupFlatLabel(string title);
        [DllImport(IUP_DLL)] public static extern IntPtr IupFlatSeparator();
        [DllImport(IUP_DLL)] public static extern IntPtr IupCanvas(string action);
        [DllImport(IUP_DLL)] public static extern IntPtr IupDialog(IntPtr child);
        [DllImport(IUP_DLL)] public static extern IntPtr IupUser();
        [DllImport(IUP_DLL)] public static extern IntPtr IupThread();
        [DllImport(IUP_DLL)] public static extern IntPtr IupLabel(string title);
        [DllImport(IUP_DLL)] public static extern IntPtr IupList(string action);
        [DllImport(IUP_DLL)] public static extern IntPtr IupFlatList();
        [DllImport(IUP_DLL)] public static extern IntPtr IupText(string action);
        [DllImport(IUP_DLL)] public static extern IntPtr IupMultiLine(string action);
        [DllImport(IUP_DLL)] public static extern IntPtr IupToggle(string title, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string action);
        [DllImport(IUP_DLL)] public static extern IntPtr IupTimer();
        [DllImport(IUP_DLL)] public static extern IntPtr IupClipboard();
        [DllImport(IUP_DLL)] public static extern IntPtr IupProgressBar();
        [DllImport(IUP_DLL)] public static extern IntPtr IupVal(string type);
        [DllImport(IUP_DLL)] public static extern IntPtr IupFlatVal(string type);
        [DllImport(IUP_DLL)] public static extern IntPtr IupFlatTree();
        [DllImport(IUP_DLL)] public static extern IntPtr IupTabs(IntPtr child, params string[] extra);
        [DllImport(IUP_DLL)] public static extern IntPtr IupTabsv(params IntPtr[] children);
        [DllImport(IUP_DLL)] public static extern IntPtr IupFlatTabs(IntPtr first, params string[] extra);
        [DllImport(IUP_DLL)] public static extern IntPtr IupFlatTabsv(params IntPtr[] children);
        [DllImport(IUP_DLL)] public static extern IntPtr IupTree();
        [DllImport(IUP_DLL)] public static extern IntPtr IupLink(string url, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string title);
        [DllImport(IUP_DLL)] public static extern IntPtr IupAnimatedLabel(IntPtr animation);
        [DllImport(IUP_DLL)] public static extern IntPtr IupDatePick();
        [DllImport(IUP_DLL)] public static extern IntPtr IupCalendar();
        [DllImport(IUP_DLL)] public static extern IntPtr IupColorbar();
        [DllImport(IUP_DLL)] public static extern IntPtr IupGauge();
        [DllImport(IUP_DLL)] public static extern IntPtr IupDial(string type);
        [DllImport(IUP_DLL)] public static extern IntPtr IupColorBrowser();

        /* Old controls, use SPIN attribute of IupText */
        [DllImport(IUP_DLL)] public static extern IntPtr IupSpin();
        [DllImport(IUP_DLL)] public static extern IntPtr IupSpinbox(IntPtr child);


        /************************************************************************/
        /*                      Utilities                                       */
        /************************************************************************/

        /* String compare utility */
        [DllImport(IUP_DLL)] public static extern int IupStringCompare(string str1, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string str2, int casesensitive, int lexicographic);

        /* IupImage utilities */
        [DllImport(IUP_DLL)] public static extern int IupSaveImageAsText(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string filename, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string format, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name);
        [DllImport(IUP_DLL)] public static extern IntPtr IupImageGetHandle(string name);

        /* IupText and IupScintilla utilities */
        [DllImport(IUP_DLL)] public static extern void IupTextConvertLinColToPos(IntPtr ih, int lin, int col, int[] pos);
        [DllImport(IUP_DLL)] public static extern void IupTextConvertPosToLinCol(IntPtr ih, int pos, int[] lin, int[] col);

        /* IupText, IupList, IupTree, IupMatrix and IupScintilla utility */
        [DllImport(IUP_DLL)] public static extern int IupConvertXYToPos(IntPtr ih, int x, int y);

        /* OLD names, kept for backward compatibility, will never be removed. */
        [DllImport(IUP_DLL)] public static extern void IupStoreGlobal(string name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string value);
        [DllImport(IUP_DLL)] public static extern void IupStoreAttribute(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string value);
        [DllImport(IUP_DLL)] public static extern void IupSetfAttribute(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string format, params string[] extra);
        [DllImport(IUP_DLL)] public static extern void IupStoreAttributeId(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int id, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string value);
        [DllImport(IUP_DLL)] public static extern void IupSetfAttributeId(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int id, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string f, params string[] extra);
        [DllImport(IUP_DLL)] public static extern void IupStoreAttributeId2(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int lin, int col, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string value);
        [DllImport(IUP_DLL)] public static extern void IupSetfAttributeId2(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int lin, int col, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string format, params string[] extra);

        /* IupTree and IupFlatTree utilities (work for both) */
        [DllImport(IUP_DLL)] public static extern int IupTreeSetUserId(IntPtr ih, int id, IntPtr userid);
        [DllImport(IUP_DLL)] public static extern IntPtr IupTreeGetUserId(IntPtr ih, int id);
        [DllImport(IUP_DLL)] public static extern int IupTreeGetId(IntPtr ih, IntPtr userid);
        [DllImport(IUP_DLL)] public static extern void IupTreeSetAttributeHandle(IntPtr ih, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string name, int id, IntPtr ih_named); /* deprecated, use IupSetAttributeHandleId */


        /************************************************************************/
        /*                      Pre-defined dialogs                           */
        /************************************************************************/

        [DllImport(IUP_DLL)] public static extern IntPtr IupFileDlg();
        [DllImport(IUP_DLL)] public static extern IntPtr IupMessageDlg();
        [DllImport(IUP_DLL)] public static extern IntPtr IupColorDlg();
        [DllImport(IUP_DLL)] public static extern IntPtr IupFontDlg();
        [DllImport(IUP_DLL)] public static extern IntPtr IupProgressDlg();

        [DllImport(IUP_DLL)] public static extern int IupGetFile(string arq);
        [DllImport(IUP_DLL)] public static extern void IupMessage(string title, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string msg);
        [DllImport(IUP_DLL)] public static extern void IupMessagef(string title, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string format, params string[] extra);
        [DllImport(IUP_DLL)] public static extern void IupMessageError(IntPtr parent, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string message);
        [DllImport(IUP_DLL)] public static extern int IupMessageAlarm(IntPtr parent, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string title, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string message, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string buttons);
        [DllImport(IUP_DLL)] public static extern int IupAlarm(string title, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string msg, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string b1, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string b2, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string b3);
        [DllImport(IUP_DLL)] public static extern int IupScanf(string format, params string[] extra);
        [DllImport(IUP_DLL)]
        public static extern int IupListDialog(int type, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string title, int size, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPTStr)] string[] list,
                   int op, int max_col, int max_lin, int[] marks);
        [DllImport(IUP_DLL)] public static extern int IupGetText(string title, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string text, int maxsize);
        [DllImport(IUP_DLL)] public static extern int IupGetColor(int x, int y, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string r, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string g, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string b);

        [DllImport(IUP_DLL)] public static extern int IupGetParam(string title, Iparamcb action, IntPtr user_data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string format, params string[] extra);
        [DllImport(IUP_DLL)] public static extern int IupGetParamv(string title, Iparamcb action, IntPtr user_data, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(CharStarMarshaler))] string format, int param_count, int param_extra, IntPtr[] param_data);
        [DllImport(IUP_DLL)] public static extern IntPtr IupParam(string format);
        [DllImport(IUP_DLL)] public static extern IntPtr IupParamBox(IntPtr param, params string[] extra);
        [DllImport(IUP_DLL)] public static extern IntPtr IupParamBoxv(params IntPtr[] param_array);

        [DllImport(IUP_DLL)] public static extern IntPtr IupLayoutDialog(IntPtr dialog);
        [DllImport(IUP_DLL)] public static extern IntPtr IupElementPropertiesDialog(IntPtr parent, IntPtr elem);
        [DllImport(IUP_DLL)] public static extern IntPtr IupGlobalsDialog();
        [DllImport(IUP_DLL)] public static extern IntPtr IupClassInfoDialog(IntPtr parent);


    }
}
