using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormsWrapper;
using FormsWrapper.GUI;
using FormsWrapper.TUI;

namespace BatchInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            InterceptMouse.Hook();
            Application.Run();            
            InterceptMouse.UnHook();
        }
    }
}
