using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorScrollbarComponent.classes
{
    public class BsbSettings
    {
        public string ID { get; set; } = "Scrollbar1";
        public bool VerticalOrHorizontal { get; set; } = true;

        public double width { get; set; } = 15;
        public double height { get; set; } = 200;

        public double ButtonSize { get; set; } = 15;


        public int MaxValue { get; set; } = 10;

        public string BGColor { get; set; } = "silver";
        public string ThumbColor { get; set; } = "gray";
    }
}
