using System.Runtime.InteropServices;
using DotNetPlugin.SDK;
using RGiesecke.DllExport;

namespace DotNetPlugin
{
    public static class MainPlugin
    {
        private const string plugin_name = "xHotSpots";
        private const int plugin_version = 1;
        private static string szprojectnameInfo = "\n" + plugin_name + " " + plugin_version + 
                                ".0 Plugin by ThunderCls 2017\n" +
								"Locate Applications HotSpots\n" +
								"-> For latest release, issues, etc....\n" +
								"-> code: http://github.com/ThunderCls/xHotSpots\n" +
								"-> blog: http://reversec0de.wordpress.com\n\n";

        [DllExport("pluginit", CallingConvention.Cdecl)]
        public static bool pluginit(ref Plugins.PLUG_INITSTRUCT initStruct)
        {
            Plugins.pluginHandle = initStruct.pluginHandle;
            initStruct.sdkVersion = Plugins.PLUG_SDKVERSION;
            initStruct.pluginVersion = plugin_version;
            initStruct.pluginName = plugin_name;
            return FunctionCode.PlugIn_Init(initStruct);
        }

        [DllExport("plugstop", CallingConvention.Cdecl)]
        private static bool plugstop()
        {
            FunctionCode.PlugIn_Stop();
            return true;
        }

        [DllExport("plugsetup", CallingConvention.Cdecl)]
        private static void plugsetup(ref Plugins.PLUG_SETUPSTRUCT setupStruct)
        {
            FunctionCode.globalVars.hMenu = setupStruct.hMenu;
            FunctionCode.globalVars.hMenuDisasm = setupStruct.hMenuDisasm;
            FunctionCode.globalVars.hMenuDump = setupStruct.hMenuDump;
            FunctionCode.globalVars.hMenuStack = setupStruct.hMenuStack;
            FunctionCode.globalVars.hwndDlg = setupStruct.hwndDlg;

            PLog.WriteLine(szprojectnameInfo); // Add some info of the plugin to the log
            FunctionCode.PlugIn_SetUp(setupStruct);
        }
    }
}
