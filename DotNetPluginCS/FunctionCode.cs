using System.Runtime.InteropServices;
using DotNetPlugin.SDK;
using Microsoft.VisualBasic;
using RGiesecke.DllExport;
using System;
using DotNetPlugin.Script;
using System.Windows.Forms;

namespace DotNetPlugin
{
    public class FunctionCode
    {
        private const int MENU_ABOUT = 0;
        private const int MENU_GET_HOTSPOTS = 1;
        private static bool debugging = false;

        public static Plugins.PLUG_SETUPSTRUCT globalVars;

        public static bool PlugIn_Init(Plugins.PLUG_INITSTRUCT initStruct)
        {
            //Plugins._plugin_registercommand(initStruct.pluginHandle, "GetHotSpots", HotSpot.cbLocateHotSpots, true);
            //PLog.WriteLine("[HotSpots] pluginHandle: {0}", Plugins.pluginHandle);
            return true;
        }

        public static void PlugIn_Stop()
        {
            //Plugins._plugin_unregistercommand(Plugins.pluginHandle, "GetHotSpots");  
   
            Plugins._plugin_menuclear(globalVars.hMenu);
            Plugins._plugin_menuclear(globalVars.hMenuDisasm);
            Plugins._plugin_menuclear(globalVars.hMenuDump);
            Plugins._plugin_menuclear(globalVars.hMenuStack);
        }

        public static void PlugIn_SetUp(Plugins.PLUG_SETUPSTRUCT setupStruct)
        {
            HotSpot.mainDlg = new frmMain();
            HotSpot.aboutDlg = new xHotSpots.frmAbout();

            //Bridge.ICONDATA menu_icon = new Bridge.ICONDATA();
            //IntPtr unmanagedPointer = Marshal.AllocHGlobal(Icon.mainIcon.Length);
            //Marshal.Copy(Icon.mainIcon, 0, unmanagedPointer, Icon.mainIcon.Length);
            //menu_icon.data = unmanagedPointer;
            //menu_icon.size = Icon.mainIcon.Length;
            //Plugins._plugin_menuseticon(setupStruct.hMenu, ref menu_icon); //Marshal.FreeHGlobal(unmanagedPointer);
            Plugins._plugin_menuaddentry(setupStruct.hMenu, MENU_GET_HOTSPOTS, "&Get HotSpots");
            Plugins._plugin_menuaddseparator(setupStruct.hMenu);
            Plugins._plugin_menuaddentry(setupStruct.hMenu, MENU_ABOUT, "&About...");
        }

        [DllExport("CBINITDEBUG", CallingConvention.Cdecl)]
        public static void CBINITDEBUG(Plugins.CBTYPE cbType, ref Plugins.PLUG_CB_INITDEBUG info)
        {
            debugging = true;
            //var szFileName = info.szFileName.MarshalToString();
            //PLog.WriteLine("[HotSpots] DotNet test debugging of file {0} started!", szFileName);
        }

        [DllExport("CBSTOPDEBUG", CallingConvention.Cdecl)]
        public static void CBSTOPDEBUG(Plugins.CBTYPE cbType, ref Plugins.PLUG_CB_STOPDEBUG info)
        {
            debugging = false;
            HotSpot.mainDlg.LstFoundSpots.Items.Clear();
            HotSpot.mainDlg.Found.Text = "";
        }

        [DllExport("CBCREATEPROCESS", CallingConvention.Cdecl)]
        public static void CBCREATEPROCESS(Plugins.CBTYPE cbType, ref Plugins.PLUG_CB_CREATEPROCESS info)
        {
        }

        [DllExport("CBLOADDLL", CallingConvention.Cdecl)]
        public static void CBLOADDLL(Plugins.CBTYPE cbType, ref Plugins.PLUG_CB_LOADDLL info)
        {
        }

        [DllExport("CBMENUENTRY", CallingConvention.Cdecl)]
        public static void CBMENUENTRY(Plugins.CBTYPE cbType, ref Plugins.PLUG_CB_MENUENTRY info)
        {
            switch (info.hEntry)
            {
                case MENU_ABOUT:
                    HotSpot.aboutDlg.ShowDialog();
                    break;
                case MENU_GET_HOTSPOTS:
                    //Bridge.DbgCmdExec("GetHotSpots");
                    if(debugging) 
                        HotSpot.mainDlg.ShowDialog(); 
                    else
                        //Interaction.MsgBox("You need to be debugging to use this option", MsgBoxStyle.OkOnly, "Info");
                        MessageBox.Show("You need to be debugging to use this option", "Not Debugging!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
    }
}
