using BlazorScrollbarComponent.classes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BlazorScrollbarComponent
{
    public class CompBG : ComponentBase, IDisposable
    {
        [Parameter]
        protected ComponentBase parent { get; set; }


        [Parameter]
        protected BsbBG bsbBG { get; set; }

        public CompBlazorScrollbar _parent;

        protected override void OnInit()
        {
            bsbBG.PropertyChanged += BsbBG_PropertyChanged;
            _parent = parent as CompBlazorScrollbar;
        }

        private void BsbBG_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            StateHasChanged();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {

            int k = -1;


            builder.OpenElement(k++, "rect");
            builder.AddAttribute(k++, "x", bsbBG.x);
            builder.AddAttribute(k++, "y", bsbBG.y);
            builder.AddAttribute(k++, "width", bsbBG.width);
            builder.AddAttribute(k++, "height", bsbBG.height);
            builder.AddAttribute(k++, "fill", bsbBG.fill);
            builder.AddAttribute(k++, "onclick", Clicked);

            builder.AddAttribute(k++, "onwheel", OnWheel);

            builder.CloseElement();

            base.BuildRenderTree(builder);
        }

        public void OnWheel(UIWheelEventArgs e)
        {
                _parent.bsbScrollbar.CmdWhell(e.DeltaY > 0);

        }

        public void Clicked(UIMouseEventArgs e)
        {
            if (bsbBG.BeforeOrAfter)
            {
                _parent.bsbScrollbar.ThumbMove(-_parent.bsbScrollbar.Step);
            }
            else
            {
                _parent.bsbScrollbar.ThumbMove(_parent.bsbScrollbar.Step);
            }

            
        }


        public void Dispose()
        {
            bsbBG.PropertyChanged -= BsbBG_PropertyChanged;
        }
    }
}
