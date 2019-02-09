using BlazorScrollbarComponent.classes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BlazorScrollbarComponent
{
    public class CompThumb : ComponentBase, IDisposable
    {
        [Parameter]
        protected ComponentBase parent { get; set; }


        [Parameter]
        protected BsbThumb bsbThumb { get; set; }

        public CompBlazorScrollbar _parent;

        protected override void OnInit()
        {

            bsbThumb.PropertyChanged += BsbThumb_PropertyChanged;
            _parent = parent as CompBlazorScrollbar;
        }

        private void BsbThumb_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            StateHasChanged();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {

            int k = -1;


            builder.OpenElement(k++, "rect");
            builder.AddAttribute(k++, "x", bsbThumb.x);
            builder.AddAttribute(k++, "y", bsbThumb.y);
            builder.AddAttribute(k++, "width", bsbThumb.width);
            builder.AddAttribute(k++, "height", bsbThumb.height);
            builder.AddAttribute(k++, "fill", bsbThumb.fill);

            builder.AddAttribute(k++, "onmousedown", OnMouseDown);
            builder.AddAttribute(k++, "onmousemove", OnMouseMove);

            builder.AddAttribute(k++, "onwheel", OnWheel);

            builder.CloseElement();

            base.BuildRenderTree(builder);
        }

        
        public void OnWheel(UIWheelEventArgs e)
        {
            _parent.bsbScrollbar.CmdWhell(e.DeltaY > 0);

        }
    
        public void OnMouseMove(UIMouseEventArgs e)
        {
            if (e.Buttons == 1)
            {
                int NewPosition;
                if (_parent.bsbScrollbar.bsbSettings.VerticalOrHorizontal)
                {
                    NewPosition = (int)e.ClientY;
                }
                else
                {
                    NewPosition = (int)e.ClientX;
                }

                if (bsbThumb.PreviousPosition != NewPosition)
                {
                    _parent.bsbScrollbar.ThumbMove(NewPosition - bsbThumb.PreviousPosition);
                    bsbThumb.PreviousPosition = NewPosition;
                }
                
            }
        }

        public void OnMouseDown(UIMouseEventArgs e)
        {
            if (_parent.bsbScrollbar.bsbSettings.VerticalOrHorizontal)
            {
                bsbThumb.PreviousPosition = (int)e.ClientY;
            }
            else
            {
                bsbThumb.PreviousPosition = (int)e.ClientX;
            }
        }


        public void Dispose()
        {
            bsbThumb.PropertyChanged -= BsbThumb_PropertyChanged;
        }
    }
}
