using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ascon.Plm.Loodsman.PluginSDK;

namespace LoodsmanEmulator
{
    [LoodsmanPlugin]
    public class StarterClass : ILoodsmanNetPlugin
    {
        mainForm mf;

        public void BindMenu(IMenuDefinition menu)
        {
            menu.AddMenuItem("Start emulate", Command, CanCommand);
        }

        private bool CanCommand(INetPluginCall call)
        {
            return true;
        }

        private void Command(INetPluginCall call)
        {
            mf = new mainForm(call);

            mf.Show();
        }

        public void OnCloseDb()
        {
            
        }

        public void OnConnectToDb(INetPluginCall call)
        {
            
        }

        public void PluginLoad()
        {
            
        }

        public void PluginUnload()
        {
            
        }
    }
}
