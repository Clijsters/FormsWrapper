using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//It's all at KeyboardHook.cs and MouseHook.cs
#region oldStuff
namespace FormsWrapper.TUI
{
    public delegate void MouseClicked(object source, MouseClickedEventArgs e);
    public class MouseClickedEventArgs : EventArgs
    {
        private int xCoord;
        private int yCoord;
        public int x
        {
            get
            {
                return xCoord;
            }
            set
            {
                xCoord = x;
            }
        }
        public MouseClickedEventArgs(int x, int y)
        {
            yCoord = x;
        }
        public string GetRect()
        {
            return null;
        }
    }

   
    public class MyClass
    {
        public event MouseClicked Click;
        private int i;
        private int Maximum = 10;
        public int MyValue
        {
            get
            {
                return i;
            }
            set
            {
                if (value <= Maximum)
                {
                    i = value;
                }
                else
                {
                    //To make sure we only trigger the event if a handler is present
                    //we check the event to make sure it's not null.
                    if (Click != null)
                    {
                       // Click(this, new MouseClickedEventArgs(""));
                    }
                }
            }
        }
    }

    class Program
    {
        //EventHandler for MouseClicks
        static void MaximumReached(object source, MouseClickedEventArgs e)
        {
            //Console.WriteLine(e.GetInfo());
        }

        static void Main(string[] args)
        {
            //Now lets test the event contained in the above class.
            MyClass MyObject = new MyClass();
            MyObject.Click += new MouseClicked(MaximumReached);

            for (int x = 0; x <= 15; x++)
            {
                MyObject.MyValue = x;
            }

            Console.ReadLine();
        }
    }
}
#endregion