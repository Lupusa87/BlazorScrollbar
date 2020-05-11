using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorScrollbarComponent.classes
{
    public class BsbBaseProps
    {
        internal Action PropertyChanged;

        internal string id { get; set; } = string.Empty;

        internal double x { get; set; } = 0;
        internal double y { get; set; } = 0;

        internal double width { get; set; } = 0;
        internal double height { get; set; } = 0;
        internal string style { get; set; } = string.Empty;
        internal string fill { get; set; } = string.Empty;
    }
}
