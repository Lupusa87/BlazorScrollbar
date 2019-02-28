using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorScrollbarComponent.classes
{
    public class BsbSettings
    {
        public string ID { get; private set; }

        public bool VerticalOrHorizontal { get; set; } = true;

        public double width { get; set; } = 15;
        public double height { get; set; } = 200;

        internal double ButtonSize { get; set; } = 15;

        public bool IsVisible { get; private set; }

        internal double ThumbWaySize { get; set; } = 0;
        internal double ThumbSize { get; private set; } = 0;

        public double ScrollVisibleSize { get; set; } = 200;
        public double ScrollTotalSize { get; set; } = 1000;

        public BsbStyle bsbStyle { get; set; } = new BsbStyle();

        internal double ScrollScale { get; set; } = 1.0;


        public BsbSettings (string ScrollBarID = "ScrollBar")
        {
            if (string.IsNullOrEmpty(ScrollBarID))
            {
                ID = ScrollBarID + Guid.NewGuid().ToString("d").Substring(1, 4);
            }
            else
            {
                ID = "ScrollBar" + Guid.NewGuid().ToString("d").Substring(1, 4);
            }
        }


        public bool initialize()
        {

            IsVisible = ScrollTotalSize > ScrollVisibleSize;

            if (IsVisible)
            {

                if (VerticalOrHorizontal)
                {
                    ThumbWaySize = height - ButtonSize * 2;
                }
                else
                {
                    ThumbWaySize = width - ButtonSize * 2;
                }



                ThumbSize = ScrollVisibleSize * ThumbWaySize / ScrollTotalSize;


                if (ThumbSize < ButtonSize)
                {
                    ThumbSize = ButtonSize;

                }

                ThumbWaySize -= ThumbSize;

                ScrollScale = (ScrollTotalSize - ScrollVisibleSize) / ThumbWaySize;

            }


            return IsVisible;
        }
    }
}
