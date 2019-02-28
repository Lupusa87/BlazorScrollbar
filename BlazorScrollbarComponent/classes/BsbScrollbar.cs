using BlazorScrollbarComponent.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BlazorScrollbarComponent.classes
{
    internal class BsbScrollbar 
    {
        internal Action PropertyChanged;

        internal CompBlazorScrollbar compBlazorScrollbar = null;

        internal BsbSettings bsbSettings { get; set; }

        internal BsbButton bsbButton1 { get; set; }
        internal BsbButton bsbButton2 { get; set; }

        internal BsbBG bsbBgBeforeThumb { get; set; }
        internal BsbBG bsbBgAfterThumb { get; set; }

        internal BsbThumb bsbThumb { get; set; }

        internal double Position { get; set; } = 0;

        internal double MaxPosition { get; set; } = 0;

        internal double Step { get; set; } = 0;

        internal void ThumbMove(double p)
        {

            Position += p;

            if (Position < 0)
            {
                Position = 0;

              //  BsbJsInterop.StopDrag(bsbThumb.id);
            }

            if (Position > MaxPosition)
            {
                Position = MaxPosition;
                //   BsbJsInterop.StopDrag(bsbThumb.id);
            }

            SetPosition();



            compBlazorScrollbar.CurrentPosition = Position * bsbSettings.ScrollScale;

            Console.WriteLine("CurrentPosition" + compBlazorScrollbar.CurrentPosition);
            compBlazorScrollbar.OnPositionChange?.Invoke(compBlazorScrollbar.CurrentPosition);
        }


        internal void SetPosition()
        {
            
            if (bsbSettings.VerticalOrHorizontal)
            {
                bsbThumb.y = bsbSettings.ButtonSize + Position;
            }
            else
            {
                bsbThumb.x = bsbSettings.ButtonSize + Position;

            }

           

            ReArrangeBGs();

            
            bsbThumb.InvokePropertyChanged();

         
            bsbBgAfterThumb.InvokePropertyChanged();

            
            bsbBgBeforeThumb.InvokePropertyChanged();
        }



        internal void Initialize()
        {

         

            
            if (bsbSettings.VerticalOrHorizontal)
            {

                bsbButton1 = new BsbButton
                {
                    FirstOrSecond = true,
                    x = 0,
                    y = 0,
                    width = bsbSettings.width,
                    height = bsbSettings.ButtonSize,
                    fill = bsbSettings.bsbStyle.ButtonColor,
                };



                bsbBgBeforeThumb = new BsbBG
                {
                    BeforeOrAfter = true,
                    x = 0,
                    y = bsbSettings.ButtonSize,
                    width = bsbSettings.width,
                    height = 0,
                    fill = bsbSettings.bsbStyle.ThumbWayColor,
                };


                bsbThumb = new BsbThumb
                {
                    id = bsbSettings.ID+ "bsbThumb",
                    x = 0,
                    y = bsbSettings.ButtonSize,
                    width = bsbSettings.width,
                    height = bsbSettings.ThumbSize,

                    fill = bsbSettings.bsbStyle.ThumbColor,
                };


                bsbBgAfterThumb = new BsbBG
                {
                    BeforeOrAfter = false,
                    x = 0,
                    y = bsbThumb.y + bsbThumb.height,
                    width = bsbSettings.width,
                    height = bsbSettings.height - bsbThumb.y - bsbThumb.height - bsbSettings.ButtonSize,
                    fill = bsbSettings.bsbStyle.ThumbWayColor,
                };


                bsbButton2 = new BsbButton
                {
                    FirstOrSecond = false,
                    x = 0,
                    y = bsbSettings.height - bsbSettings.ButtonSize,
                    width = bsbSettings.width,
                    height = bsbSettings.ButtonSize,
                    fill = bsbSettings.bsbStyle.ButtonColor,
                };




                Step = bsbThumb.height;
                
            }
            else
            {
                bsbButton1 = new BsbButton
                {
                    FirstOrSecond = true,
                    x = 0,
                    y = 0,
                    width = bsbSettings.ButtonSize,
                    height = bsbSettings.height,
                    fill = bsbSettings.bsbStyle.ButtonColor,
                };

                bsbBgBeforeThumb = new BsbBG
                {
                    BeforeOrAfter = true,
                    x = bsbSettings.ButtonSize,
                    y = 0,
                    width = 0,
                    height = bsbSettings.height,
                    fill = bsbSettings.bsbStyle.ThumbWayColor,
                };


                bsbThumb = new BsbThumb
                {
                    id = bsbSettings.ID + "bsbThumb",
                    x = bsbSettings.ButtonSize,
                    y = 0,
                    width = bsbSettings.ThumbSize,
                    height = bsbSettings.height,
                    fill = bsbSettings.bsbStyle.ThumbColor,
                };

                bsbBgAfterThumb = new BsbBG
                {
                    BeforeOrAfter = false,
                    x = bsbSettings.ButtonSize + bsbThumb.width,
                    y = 0,
                    width = bsbSettings.width - bsbSettings.ButtonSize - bsbThumb.width - bsbSettings.ButtonSize,
                    height = bsbSettings.height,
                    fill = bsbSettings.bsbStyle.ThumbWayColor,
                };

                bsbButton2 = new BsbButton
                {
                    FirstOrSecond = false,
                    x = bsbSettings.width - bsbSettings.ButtonSize,
                    y = 0,
                    width = bsbSettings.ButtonSize,
                    height = bsbSettings.height,
                    fill = bsbSettings.bsbStyle.ButtonColor,
                };

                Step = bsbThumb.width;
            }



            Position = 0;

            if (bsbSettings.VerticalOrHorizontal)
            {
               MaxPosition = bsbSettings.height - (bsbSettings.ButtonSize * 2) - bsbSettings.ThumbSize;
            }
            else
            {
               MaxPosition = bsbSettings.width - (bsbSettings.ButtonSize * 2) - bsbSettings.ThumbSize;
            }

         
            bsbThumb.PreviousPosition = 0;
            bsbThumb.PreviousPosition2 = 0;
        }


        internal void ReArrangeBGs()
        {
            if (bsbSettings.VerticalOrHorizontal)
            {
                bsbBgBeforeThumb.height = bsbThumb.y - bsbSettings.ButtonSize;

                bsbBgAfterThumb.y = bsbThumb.y + bsbThumb.height;
                bsbBgAfterThumb.height = bsbSettings.height - bsbBgAfterThumb.y - bsbSettings.ButtonSize;
            }
            else
            {
                bsbBgBeforeThumb.width = bsbThumb.x - bsbSettings.ButtonSize;
                  
                bsbBgAfterThumb.x = bsbThumb.x + bsbThumb.width;
                bsbBgAfterThumb.width = bsbSettings.width - bsbBgAfterThumb.x - bsbSettings.ButtonSize;
            }
        }


        internal void CmdWhell(bool IsForward)
        {
           
                if (IsForward)
                {
                    ThumbMove(Step);
                }
                else
                {
                    ThumbMove(-Step);
                }
            
        }



        internal void InvokePropertyChanged()
        {
            PropertyChanged?.Invoke();
        }

    }
}
