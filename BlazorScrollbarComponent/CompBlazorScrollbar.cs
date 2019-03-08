using BlazorScrollbarComponent.classes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BlazorScrollbarComponent
{
    public class CompBlazorScrollbar: ComponentBase,IDisposable
    {
        [Inject]
        private IJSRuntime jsRuntimeCurrent { get; set; }

        [Parameter]
        protected BsbSettings bsbSettings { get; set; }

        [Parameter]
        public Action<double> OnPositionChange { get; set; }

        [Parameter]
        public bool ReactOnParentRefresh { get; set; } = true;

        internal BsbScrollbar bsbScrollbar { get; set; } = new BsbScrollbar();

        public bool IsVisible { get; private set; }

        public double CurrentPosition { get; internal set; } = 0;

        protected override void OnInit()
        {

            BsbJsInterop.jsRuntime = jsRuntimeCurrent;

            bsbScrollbar.compBlazorScrollbar = this;
            bsbScrollbar.PropertyChanged = BsbScrollbar_PropertyChanged;

            base.OnInit();
        }


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
                StateHasChanged();
            }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {

            if (IsVisible)
            {
                Cmd_Render(0, builder);
            }


            base.BuildRenderTree(builder);
           
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


        public void Dispose()
        {
            BsbJsInterop.UnHandleDrag(bsbScrollbar.bsbThumb.id);
            
        }


        public void SetScrollTotalWidth(double w)
        {
          
            bsbScrollbar.bsbSettings.ScrollTotalSize = w;

     
            IsVisible = bsbScrollbar.bsbSettings.initialize();
            if (IsVisible)
            {
                bsbScrollbar.Initialize();

                StateHasChanged();
            }
            

        }

        public void SetScrollVisibleWidth(double w)
        {
            
                bsbScrollbar.bsbSettings.ScrollVisibleSize = w;
            IsVisible = bsbScrollbar.bsbSettings.initialize();

            if (IsVisible)
            {
                bsbScrollbar.Initialize();

                StateHasChanged();
            }

        }


        public void SetScrollPosition(double p)
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
                StateHasChanged();
            }

        }

        public void SetMaxScrollPosition()
        {
            if (IsVisible)
            {
                // value is more then max but it will be limited to max inside this method
                bsbScrollbar.ThumbMove(bsbScrollbar.bsbSettings.ScrollTotalSize / bsbScrollbar.bsbSettings.ScrollScale);

                StateHasChanged();
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
