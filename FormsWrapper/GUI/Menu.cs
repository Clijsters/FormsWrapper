using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormsWrapper.GUI
{
    public partial class Menu
    {
        public enum FormType {
            gridForm = 1,
            freeForm = 2,
        }


        public Menu(FormType ft) { 
            //System.Windows.Forms.Form asd;
        }
        public Menu() { }

        public static void addToForm(ElementType et) { }
        public static void fill(Content content) { }

        public static void parseCSS(string cssFile) { }
        public static void parseBatch() { }

        public static void showForm() { }
        public static void showDialog() { }
        public static void showballoonTip() { }
        public TUI.Menu toGUI() {
            return new TUI.Menu();
        }
               
    }
}
