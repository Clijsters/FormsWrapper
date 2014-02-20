using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormsWrapper
{
    class Wrapper
    {
        public void showMenu(FormsWrapper.GUI.Menu menu) { }
        public void showMenu(FormsWrapper.TUI.Menu menu) { }
        public void startTUI() { }
        public void startGUI() { }
    }
}
