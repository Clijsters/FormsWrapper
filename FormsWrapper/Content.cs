using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormsWrapper
{
    public class Content
    {
        SourceType sourceType;

        public Content(string contentDescriptor, SourceType st)
        {
            this.sourceType = st;
        }

        public void getContent()
        {
            switch (this.sourceType)
            {
                case SourceType.cssFile:
                case SourceType.cssString:
                    break;
                case SourceType.htmlFile:
                case SourceType.htmlString:
                    break;
                case SourceType.jsonFile:
                case SourceType.jsonString:
                case SourceType.push:
                    break;
                case SourceType.xmlFile:
                case SourceType.xmlString:
                    break;
            }

        }
    }
}
