using BlazorScrollbarComponent.classes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BlazorScrollbarComponent
{
    public class CompBlazorScrollbar: ComponentBase,IDisposable
    {
        

        [Parameter]
        public BsbSettings bsbSettings { get; set; }

        [Parameter]
        public Action<double> OnPositionChange { get; set; }

        [Parameter]
        public bool ReactOnParentRefresh { get; set; } = true;

        internal BsbScrollbar bsbScrollbar { get; set; } = new BsbScrollbar();

        public bool IsVisible { get; private set; }

        public double CurrentPosition { get; internal set; } = 0;

        
        //private bool EnableRender = true;


        protected override void OnInitialized()
        {
            bsbScrollbar.compBlazorScrollbar = this;
            bsbScrollbar.PropertyChanged = BsbScrollbar_PropertyChanged;

            base.OnInitialized();
        }


        //protected override bool ShouldRender()
        //{
        //    return EnableRender;
        //}


        protected override void OnParametersSet()
        {
            if (ReactOnParentRefresh)
            {
                bsbScrollbar.bsbSettings = bsbSettings;
                bsbScrollbar.Initialize();

                IsVisible = bsbScrollbar.bsbSettings.initialize();
            }

            base.OnParametersSet();
        }




        private void BsbScrollbar_PropertyChanged()
        {
            if (IsVisible)
            {
                Refresh();
            }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            //if (EnableRender)
            //{

                base.BuildRenderTree(builder);

                if (IsVisible)
                {
                    Cmd_Render(0, builder);
                }

                               
                //EnableRender = false;
            //}
        }


        private void Cmd_Render(int k, RenderTreeBuilder builder)
        {


            builder.OpenElement(k++, "svg");
            builder.AddAttribute(k++, "id", bsbSettings.ID);
            builder.AddAttribute(k++, "width", bsbSettings.width);
            builder.AddAttribute(k++, "height", bsbSettings.height);
            builder.AddAttribute(k++, "xmlns", "http://www.w3.org/2000/svg");


            builder.OpenComponent<CompButton>(k++);
            builder.AddAttribute(k++, "bsbButton", bsbScrollbar.bsbButton1);
            builder.AddAttribute(k++, "parent", this);
            builder.CloseComponent();


            builder.OpenComponent<CompBG>(k++);
            builder.AddAttribute(k++, "bsbBG", bsbScrollbar.bsbBgBeforeThumb);
            builder.AddAttribute(k++, "parent", this);
            builder.CloseComponent();

            builder.OpenComponent<CompThumb>(k++);
            builder.AddAttribute(k++, "bsbThumb", bsbScrollbar.bsbThumb);
            builder.AddAttribute(k++, "EnableRender", true);
            builder.AddAttribute(k++, "parent", this);
            builder.CloseComponent();


            builder.OpenComponent<CompBG>(k++);
            builder.AddAttribute(k++, "bsbBG", bsbScrollbar.bsbBgAfterThumb);
            builder.AddAttribute(k++, "parent", this);
            builder.CloseComponent();

            builder.OpenComponent<CompButton>(k++);
            builder.AddAttribute(k++, "bsbButton", bsbScrollbar.bsbButton2);
            builder.AddAttribute(k++, "parent", this);
            builder.CloseComponent();


            builder.CloseElement();
        }


        internal void Refresh()
        {
            //EnableRender = true;
            StateHasChanged();  
        }



        public void Dispose()
        {
        }


        public void SetScrollTotalWidth(double w)
        {
            if (bsbScrollbar.bsbSettings.ScrollTotalSize != w)
            {
                bsbScrollbar.bsbSettings.ScrollTotalSize = w;

                CurrentPosition = 0;

                IsVisible = bsbScrollbar.bsbSettings.initialize();
                if (IsVisible)
                {
                    bsbScrollbar.Initialize();
                    Refresh();
                }

            }
        }

        public void SetScrollVisibleWidth(double w)
        {
            if (bsbScrollbar.bsbSettings.ScrollVisibleSize != w)
            {
                bsbScrollbar.bsbSettings.ScrollVisibleSize = w;

                CurrentPosition = 0;

                IsVisible = bsbScrollbar.bsbSettings.initialize();

                if (IsVisible)
                {
                    bsbScrollbar.Initialize();
                    Refresh();
                }
            }
        }


        public void SetScrollPosition(double p)
        {

            if (CurrentPosition != p)
            {
                if (IsVisible)
                {

                    bsbScrollbar.Position = 0;

                    if (p == 0)
                    {
                        bsbScrollbar.ThumbMove(0);
                    }
                    else
                    {
                        bsbScrollbar.ThumbMove(p / bsbScrollbar.bsbSettings.ScrollScale);

                    }

                }
            }
        

        }

        public void SetMaxScrollPosition()
        {
            if (!IsOnMaxPosition())
            {
                if (IsVisible)
                {
                    // value is more then max but it will be limited to max inside this method
                    bsbScrollbar.ThumbMove(bsbScrollbar.bsbSettings.ScrollTotalSize / bsbScrollbar.bsbSettings.ScrollScale);
                }
            }
        }


        public void ThumbMove(double p)
        {
            if (IsVisible)
            {
                bsbScrollbar.ThumbMove(p / bsbScrollbar.bsbSettings.ScrollScale); 
            }
        }

        public bool IsOnMinPosition()
        {
            if (IsVisible)
            {
                return bsbScrollbar.Position == 0;
            }
            else
            {
                return false;
            }
        }

        public bool IsOnMaxPosition()
        {
            if (IsVisible)
            {
                return bsbScrollbar.Position == bsbScrollbar.MaxPosition;
            }
            else
            {
                return false;
            }
            
        }


        public void DoWheel(bool IsForward)
        {
            if (IsVisible)
            {
                bsbScrollbar.CmdWhell(IsForward);
            }
        }
    }
}
