﻿using BlazorScrollbarComponent.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BlazorScrollbarComponent.classes
{
    public class BsbScrollbar : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public Action PositionChanged { get; set; }

        public string ID { get; set; }

        public BsbSettings bsbSettings { get; set; }

        public BsbButton bsbButton1 { get; set; }
        public BsbButton bsbButton2 { get; set; }

        public BsbBG bsbBgBeforeThumb { get; set; }
        public BsbBG bsbBgAfterThumb { get; set; }

        public BsbThumb bsbThumb { get; set; }

        public double Position { get; set; } = 0;

        public double Step { get; set; } = 0;

        public void ThumbMove(double p)
        {

            Position+= p;

            if (Position < 0)
            {
                Position = 0;
            }


            if (bsbSettings.VerticalOrHorizontal)
            {

                if (Position >= bsbSettings.height - (bsbSettings.ButtonSize * 2) - bsbThumb.height - 1)
                {
                    Position = bsbSettings.height - (bsbSettings.ButtonSize * 2) - bsbThumb.height;
                }

            }
            else
            {
                if (Position >= bsbSettings.width - (bsbSettings.ButtonSize * 2) - bsbThumb.width - 1)
                {
                    Position = bsbSettings.width - (bsbSettings.ButtonSize * 2) - bsbThumb.width;
                }
            }
            
            SetPosition();


            PositionChanged?.Invoke();
        }


        public void SetPosition()
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



        public void Initialize()
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
                    fill = "red",
                };



                bsbBgBeforeThumb = new BsbBG
                {
                    BeforeOrAfter = true,
                    x = 0,
                    y = bsbSettings.ButtonSize,
                    width = bsbSettings.width,
                    height = 0,
                    fill = bsbSettings.BGColor,
                };


                bsbThumb = new BsbThumb
                {
                    x = 0,
                    y = bsbSettings.ButtonSize,
                    width = bsbSettings.width,
                    height = (bsbSettings.height - bsbSettings.ButtonSize * 2) / bsbSettings.MaxValue,
                    fill = bsbSettings.ThumbColor,
                };


                bsbBgAfterThumb = new BsbBG
                {
                    BeforeOrAfter = false,
                    x = 0,
                    y = bsbThumb.y + bsbThumb.height,
                    width = bsbSettings.width,
                    height = bsbSettings.height - bsbThumb.y - bsbThumb.height - bsbSettings.ButtonSize,
                    fill = bsbSettings.BGColor,
                };


                bsbButton2 = new BsbButton
                {
                    FirstOrSecond = false,
                    x = 0,
                    y = bsbSettings.height - bsbSettings.ButtonSize,
                    width = bsbSettings.width,
                    height = bsbSettings.ButtonSize,
                    fill = "red",
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
                    fill = "red",
                };

                bsbBgBeforeThumb = new BsbBG
                {
                    BeforeOrAfter = true,
                    x = bsbSettings.ButtonSize,
                    y = 0,
                    width = 0,
                    height = bsbSettings.height,
                    fill = bsbSettings.BGColor,
                };


                bsbThumb = new BsbThumb
                {
                    x = bsbSettings.ButtonSize,
                    y = 0,
                    width = (bsbSettings.width - bsbSettings.ButtonSize * 2) / bsbSettings.MaxValue,
                    height = bsbSettings.height,
                    fill = bsbSettings.ThumbColor,
                };

                bsbBgAfterThumb = new BsbBG
                {
                    BeforeOrAfter = false,
                    x = bsbSettings.ButtonSize + bsbThumb.width,
                    y = 0,
                    width = bsbSettings.width - bsbSettings.ButtonSize - bsbThumb.width - bsbSettings.ButtonSize,
                    height = bsbSettings.height,
                    fill = bsbSettings.BGColor,
                };

                bsbButton2 = new BsbButton
                {
                    FirstOrSecond = false,
                    x = bsbSettings.width - bsbSettings.ButtonSize,
                    y = 0,
                    width = bsbSettings.ButtonSize,
                    height = bsbSettings.height,
                    fill = "red",
                };

                Step = bsbThumb.width;
            }
        }


        public void ReArrangeBGs()
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


        public void CmdWhell(bool IsForward)
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

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        public void InvokePropertyChanged()
        {
            PropertyChanged?.Invoke(this, null);
        }

    }
}
