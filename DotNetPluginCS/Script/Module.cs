using System;
using System.Runtime.InteropServices;
using DotNetPlugin.SDK;

namespace DotNetPlugin.Script
{
    public static class Module
    {
        public struct ModuleInfo
        {
            public IntPtr @base;
            public IntPtr size;
            public IntPtr entry;
            public int sectionCount;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Bridge.MAX_MODULE_SIZE)]
            public string name;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = WAPI.MAX_PATH)]
            public string path;
        }

        public struct ModuleSectionInfo
        {
            public IntPtr addr;
            public IntPtr size;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Bridge.MAX_SECTION_SIZE * 5)]
            public string name;
        }

#if AMD64
        [DllImport("x64dbg.dll", CallingConvention = CallingConvention.Cdecl,
             EntryPoint = "?GetList@Module@Script@@YA_NPEAUListInfo@@@Z")]
#else
        [DllImport("x32dbg.dll", CallingConvention = CallingConvention.Cdecl,
             EntryPoint = "?GetList@Module@Script@@YA_NPAUListInfo@@@Z")]
#endif

        private static extern bool ScriptModuleGetList(ref Bridge.ListInfo listInfo);

        public static ModuleInfo[] GetList()
        {
            var listInfo = new Bridge.ListInfo();
            return listInfo.ToArray<ModuleInfo>(ScriptModuleGetList(ref listInfo));
        }

#if AMD64
        [DllImport("x64dbg.dll", CallingConvention = CallingConvention.Cdecl,
             EntryPoint = "?SectionListFromAddr@Module@Script@@YA_N_KPEAUListInfo@@@Z")]
#else
        [DllImport("x32dbg.dll", CallingConvention = CallingConvention.Cdecl,
             EntryPoint = "?SectionListFromAddr@Module@Script@@YA_NKPAUListInfo@@@Z")]
#endif

        private static extern bool ScriptModuleSectionListFromAddr(IntPtr addr, ref Bridge.ListInfo listInfo);

        public static ModuleSectionInfo[] SectionListFromAddr(IntPtr addr)
        {
            var listInfo = new Bridge.ListInfo();
            return listInfo.ToArray<ModuleSectionInfo>(ScriptModuleSectionListFromAddr(addr, ref listInfo));
        }

#if AMD64
        [DllImport("x64dbg.dll", CallingConvention = CallingConvention.Cdecl,
             EntryPoint = "?InfoFromAddr@Module@Script@@YA_N_KPEAUModuleInfo@12@@Z")]
#else
        [DllImport("x32dbg.dll", CallingConvention = CallingConvention.Cdecl,
             EntryPoint = "?InfoFromAddr@Module@Script@@YA_NKPAUModuleInfo@12@@Z")]
#endif

        private static extern bool ScriptModuleInfoFromAddr(IntPtr addr, ref ModuleInfo info);

        public static bool InfoFromAddr(IntPtr addr, ref ModuleInfo info)
        {
            return ScriptModuleInfoFromAddr(addr, ref info);
        }


#if AMD64
        [DllImport("x64dbg.dll", CallingConvention = CallingConvention.Cdecl,
             EntryPoint = "?SectionFromName@Module@Script@@YA_NPBDHPAUModuleSectionInfo@12@@Z")]
#else
        [DllImport("x32dbg.dll", CallingConvention = CallingConvention.Cdecl,
             EntryPoint = "?SectionFromName@Module@Script@@YA_NPBDHPAUModuleSectionInfo@12@@Z")]
#endif

        private static extern bool ScriptModuleSectionFromName(string module, int section, ref ModuleSectionInfo info);

        public static bool SectionFromName(string module, int section, ref ModuleSectionInfo info)
        {
            return ScriptModuleSectionFromName(module, section, ref info);
        }

#if AMD64
        [DllImport("x64dbg.dll", CallingConvention = CallingConvention.Cdecl,
             EntryPoint = "?FindMem@Pattern@Script@@YAKKKPBD@Z")]
#else
        [DllImport("x32dbg.dll", CallingConvention = CallingConvention.Cdecl,
             EntryPoint = "?FindMem@Pattern@Script@@YAKKKPBD@Z")]
#endif

        private static extern IntPtr ScriptPatternFindMem(IntPtr addrStart, IntPtr size, string pattern);

        public static IntPtr FindMemPattern(IntPtr addrStart, IntPtr size, string pattern)
        {
            return ScriptPatternFindMem(addrStart, size, pattern);
        }


#if AMD64
        [DllImport("x64dbg.dll", CallingConvention = CallingConvention.Cdecl,
             EntryPoint = "?SetBreakpoint@Debug@Script@@YA_NK@Z")]
#else
        [DllImport("x32dbg.dll", CallingConvention = CallingConvention.Cdecl,
             EntryPoint = "?SetBreakpoint@Debug@Script@@YA_NK@Z")]
#endif

        private static extern bool ScriptDebugSetBreakpoint(IntPtr bpAddr);

        public static bool DebugSetBreakpoint(IntPtr bpAddr)
        {
            return ScriptDebugSetBreakpoint(bpAddr);
        }


#if AMD64
        [DllImport("x64dbg.dll", CallingConvention = CallingConvention.Cdecl,
             EntryPoint = "?Set@Comment@Script@@YA_NKPBD_N@Z")]
#else
        [DllImport("x32dbg.dll", CallingConvention = CallingConvention.Cdecl,
             EntryPoint = "?Set@Comment@Script@@YA_NKPBD_N@Z")]
#endif

        private static extern bool ScriptCommentSet(IntPtr addr, string comment, bool dbg);

        public static bool CommentSet(IntPtr addr, string comment, bool dbg)
        {
            return ScriptCommentSet(addr, comment, dbg);
        }

#if AMD64
        [DllImport("x64dbg.dll", CallingConvention = CallingConvention.Cdecl,
             EntryPoint = "?GetMainModuleName@Module@Script@@YA_NPAD@Z")]
#else
        [DllImport("x32dbg.dll", CallingConvention = CallingConvention.Cdecl,
             EntryPoint = "?GetMainModuleName@Module@Script@@YA_NPAD@Z")]
#endif

        private static extern bool ScriptModuleGetMainModuleName(ref HotSpot.MainModule mod);

        public static bool GetMainModuleName(ref HotSpot.MainModule mod)
        {
            return ScriptModuleGetMainModuleName(ref mod);
        }        
    }
}
