using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace FormsWrapper
{
    public enum DialogType
    {
        Alert = 0,
        Warning = 1,
        Query = 2,
        Login = 3,
        Password = 4,
        SelectFolder = 5,
        SelectFile = 6,
    }

    public enum SourceType
    {
        htmlString = 0,
        htmlFile = 1,
        cssString = 2,
        cssFile = 3,
        jsonString = 4,
        jsonFile = 5,
        xmlString = 6,
        xmlFile = 7,
        push = 8
    }

    public enum ElementType
    {

    }

}
