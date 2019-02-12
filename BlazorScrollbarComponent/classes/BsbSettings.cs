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


        public double ThumbWaySize { get; set; } = 170;
        public double ScrollSize { get; set; } = 1000;


        public string BGColor { get; set; } = "silver";
        public string ThumbColor { get; set; } = "gray";
    }
}
