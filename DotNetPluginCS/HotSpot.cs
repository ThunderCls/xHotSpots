using System.Threading;
using System.Windows.Forms;
using DotNetPlugin.Script;
using DotNetPlugin.SDK;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.InteropServices;
using xHotSpots;
using System;

namespace DotNetPlugin
{
    public static class HotSpot
    {
        public static frmMain mainDlg;
        public static frmAbout aboutDlg;
        public static string moduleName;
        public enum COMPILER_TYPE 
        {
            COMPILER_VB5 = 0,
	        COMPILER_VB6,
	        COMPILER_BORLAND,
	        COMPILER_VC6,
	        COMPILER_VC10_MFC_DYNAMIC_DEBUG,
	        COMPILER_VC10_MFC_DYNAMIC_RELEASE,
	        COMPILER_VC10_MFC_STATIC_DEBUG,
	        COMPILER_VC10_MFC_STATIC_RELEASE,
	        COMPILER_VC12_MFC_DYNAMIC_DEBUG,
	        COMPILER_VC12_MFC_DYNAMIC_RELEASE,
	        COMPILER_VC12_MFC_STATIC_DEBUG,
	        COMPILER_VC12_MFC_STATIC_RELEASE,
	        COMPILER_VC14_MFC_DYNAMIC_DEBUG,
	        COMPILER_VC14_MFC_DYNAMIC_RELEASE,
	        COMPILER_VC14_MFC_STATIC_DEBUG,
	        COMPILER_VC14_MFC_STATIC_RELEASE,
	        POINT_HMEMCPY
        }

        public struct MagicPoint 
        {
            public COMPILER_TYPE compiler;
            public String module;
            public int section;
            public int bp_displacement;
            public String pattern;
            public bool loop;
        }

        public struct MainModule
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Bridge.MAX_MODULE_SIZE)]
            public string name;
        }

        public static int LocateHotSpot(COMPILER_TYPE compiler, frmMain formMain)
        {
            HotSpot.MagicPoint mPoint = new HotSpot.MagicPoint();
            HotSpot.MainModule mod = new HotSpot.MainModule();
            int result = 0;

            mPoint.compiler = compiler;
            switch (compiler)
            {
                case COMPILER_TYPE.COMPILER_VB5:
                    mPoint.module = "msvbvm50.dll";
                    mPoint.section = 0;
                    mPoint.bp_displacement = 2;
                    mPoint.pattern = "F3A5FFD08BE55D8945FC8B45FC5F5E8BE55DC20C"; // VB5 pattern
                    mPoint.loop = false;
                    break;
                case COMPILER_TYPE.COMPILER_VB6:
                    mPoint.module = "msvbvm60.dll";
                    mPoint.section = 0;
                    mPoint.bp_displacement = 2;
                    mPoint.pattern = "F3A5FFD08BE55D8945FC8B45FC5F5EC9C20C"; // VB6 pattern
                    mPoint.loop = false;
                    break;
                case COMPILER_TYPE.COMPILER_BORLAND:
                    if (Module.GetMainModuleName(ref mod))
                    {
                        mPoint.module = mod.name;
                        mPoint.section = 0;
                        mPoint.bp_displacement = 10;
                        mPoint.pattern = "740E8BD38B83????????FF93????????"; // DELPHI pattern
                        mPoint.loop = true;
                    }
                    else
                        return result;
                    break;
                case COMPILER_TYPE.COMPILER_VC6:
                    mPoint.module = "mfc42d.dll";
                    mPoint.section = 0;
                    mPoint.bp_displacement = 10;
                    mPoint.pattern = "CC33C085C075E38B4D08FF55FCE94804????33C985C97401CC"; // VC6 pattern
                    mPoint.loop = false;
                    break;
                case COMPILER_TYPE.COMPILER_VC10_MFC_DYNAMIC_DEBUG:
                    mPoint.module = "mfc100ud.dll";
                    mPoint.section = 0;
                    mPoint.bp_displacement = 4;
                    mPoint.pattern = "CC8B4D08FF55F8E9????????837D18007411"; // VC10 DYNAMIC DEBUG pattern
                    mPoint.loop = false;
                    break;
                case COMPILER_TYPE.COMPILER_VC10_MFC_DYNAMIC_RELEASE:
                    mPoint.module = "mfc100u.dll";
                    mPoint.section = 0;
                    mPoint.bp_displacement = 15;
                    mPoint.pattern = "8B550C83C2C783FA0B0F87????????FF2495????????"; // VC10 DYNAMIC RELEASE pattern
                    mPoint.loop = false;
                    break;
                case COMPILER_TYPE.COMPILER_VC10_MFC_STATIC_DEBUG:
                    if (Module.GetMainModuleName(ref mod))
                    {
                        mPoint.module = mod.name;
                        mPoint.section = 1;
                        mPoint.bp_displacement = 4;
                        mPoint.pattern = "CC8B4D08FF55F8E9????????837D18007411"; // VC10 STATIC DEBUG pattern
                        mPoint.loop = false;
                    }
                    else
                        return result;
                    break;
                case COMPILER_TYPE.COMPILER_VC10_MFC_STATIC_RELEASE:
                    if (Module.GetMainModuleName(ref mod))
                    {
                        mPoint.module = mod.name;
                        mPoint.section = 0;
                        mPoint.bp_displacement = 16;
                        mPoint.pattern = "8B451C83C0C75683F80B0F87????????FF2485????????"; // VC10 STATIC RELEASE pattern
                        mPoint.loop = false;
                    }
                    else
                        return result;
                    break;
                case COMPILER_TYPE.COMPILER_VC12_MFC_DYNAMIC_DEBUG:
                    mPoint.module = "mfc120ud.dll";
                    mPoint.section = 0;
                    mPoint.bp_displacement = 6;
                    mPoint.pattern = "CC8BF48B4D08FF55F83BF4E8????????E9????????"; // VC12 DYNAMIC DEBUG pattern
                    mPoint.loop = false;
                    break;
                case COMPILER_TYPE.COMPILER_VC12_MFC_DYNAMIC_RELEASE:
                    mPoint.module = "mfc120u.dll";
                    mPoint.section = 0;
                    mPoint.bp_displacement = 15;
                    mPoint.pattern = "8B451483C0C683F80B0F87????????FF2485????????"; // VC12 DYNAMIC RELEASE pattern
                    mPoint.loop = false;
                    break;
                case COMPILER_TYPE.COMPILER_VC12_MFC_STATIC_DEBUG:
                    if (Module.GetMainModuleName(ref mod))
                    {
                        mPoint.module = mod.name;
                        mPoint.section = 1;
                        mPoint.bp_displacement = 6;
                        mPoint.pattern = "CC8BF48B4D08FF55F83BF4E8????????E9????????"; // VC12 STATIC DEBUG pattern
                        mPoint.loop = false;
                    }
                    else
                        return result;
                    break;
                case COMPILER_TYPE.COMPILER_VC12_MFC_STATIC_RELEASE:
                    if (Module.GetMainModuleName(ref mod))
                    {
                        mPoint.module = mod.name;
                        mPoint.section = 0;
                        mPoint.bp_displacement = 16;
                        mPoint.pattern = "8B451C83C0C65683F80B0F87????????FF2485????????"; // VC12 STATIC RELEASE pattern
                        mPoint.loop = false;
                    }
                    else
                        return result;
                    break;
                case COMPILER_TYPE.COMPILER_VC14_MFC_DYNAMIC_DEBUG:
                    mPoint.module = "mfc140ud.dll";
                    mPoint.section = 0;
                    mPoint.bp_displacement = 3;
                    mPoint.pattern = "8B4D08FF55B83BF4E8????????E9????????"; // VC14 DYNAMIC DEBUG pattern
                    mPoint.loop = false;
                    break;
                case COMPILER_TYPE.COMPILER_VC14_MFC_DYNAMIC_RELEASE:
                    mPoint.module = "mfc140u.dll";
                    mPoint.section = 0;
                    mPoint.bp_displacement = 16;
                    mPoint.pattern = "8B451483C0C65783F80B0F87????????FF2485????????"; // VC14 DYNAMIC RELEASE pattern
                    mPoint.loop = false;
                    break;
                case COMPILER_TYPE.COMPILER_VC14_MFC_STATIC_DEBUG:
                    if (Module.GetMainModuleName(ref mod))
                    {
                        mPoint.module = mod.name;
                        mPoint.section = 1;
                        mPoint.bp_displacement = 3;
                        mPoint.pattern = "8B4D08FF55B83BF4E8????????E9????????"; // VC14 STATIC DEBUG pattern
                        mPoint.loop = false;
                    }
                    else
                        return result;
                    break;
                case COMPILER_TYPE.COMPILER_VC14_MFC_STATIC_RELEASE:
                    if (Module.GetMainModuleName(ref mod))
                    {
                        mPoint.module = mod.name;
                        mPoint.section = 0;
                        mPoint.bp_displacement = 16;
                        mPoint.pattern = "8B451C83C0C65783F80B0F87????????FF2485????????"; // VC14 STATIC RELEASE pattern
                        mPoint.loop = false;
                    }
                    else
                        return result;
                    break;
                case COMPILER_TYPE.POINT_HMEMCPY:
                    mPoint.module = "user32.dll";
                    mPoint.section = 0;
                    mPoint.bp_displacement = 3;
                    mPoint.pattern = "515053E88429010083C40C8BCF"; // HMEMCPY pattern
                    mPoint.loop = false;
                    break;
                default:
                    break;
            }

            return FindPattern(ref mPoint);
        }

        public static int FindPattern(ref MagicPoint mPoint)
        {
	        int result = 0;
            
            Module.ModuleSectionInfo modInfo = new Module.ModuleSectionInfo();
	        if(!Module.SectionFromName(mPoint.module, mPoint.section, ref modInfo))
		        return result;

            IntPtr rvaCodeSection = modInfo.addr; // get section address
            IntPtr sectionSize = modInfo.size;    // get section size

            IntPtr lpPattern = IntPtr.Zero;
            IntPtr startRVA = rvaCodeSection;
	        do
	        {
                lpPattern = Module.FindMemPattern(rvaCodeSection, sectionSize, mPoint.pattern);
                if (lpPattern != IntPtr.Zero)
		        {
                    rvaCodeSection = lpPattern + mPoint.bp_displacement;
			        Module.DebugSetBreakpoint(rvaCodeSection);                   // set breakpoint
			        Module.CommentSet(rvaCodeSection, "<<-- MAGIC_POINT", true); // set comment

			        // populate gui info listview
                    ListViewItem lvi = new ListViewItem(mPoint.module);
                    lvi.SubItems.Add("0x" + rvaCodeSection.ToHexString());
                    mainDlg.LstFoundSpots.Items.Add(lvi);

                    // recalculate section size
                    sectionSize = IntPtr.Subtract(sectionSize, (int)IntPtr.Subtract(lpPattern, (int)startRVA));
                    startRVA = lpPattern;

			        result++;
		        }
		        else
			        break;
            } while (mPoint.loop);

	        return result;
        }
    }
}
