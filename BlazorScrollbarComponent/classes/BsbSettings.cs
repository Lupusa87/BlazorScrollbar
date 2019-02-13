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


        public double ThumbWaySize { get; set; } = 0;
        public double ThumbSize { get; set; } = 0;

        public double ScrollVisibleSize { get; set; } = 200;
        public double ScrollTotalSize { get; set; } = 1000;


        public double ScrollScale { get; set; } = 0;

        public string BGColor { get; set; } = "silver";
        public string ThumbColor { get; set; } = "gray";


        public void initialize()
        {
            if (VerticalOrHorizontal)
            {
                ThumbWaySize = height - ButtonSize * 2;
            }
            else
            {
                ThumbWaySize = width - ButtonSize * 2;
            }


           ThumbSize = ScrollVisibleSize / ScrollTotalSize * ThumbWaySize;

           ScrollScale = ScrollTotalSize / ThumbWaySize;
      
        }
    }
}
