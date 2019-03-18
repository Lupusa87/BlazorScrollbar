using BlazorScrollbarComponent.classes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BlazorScrollbarComponent
{
    internal class CompBG : ComponentBase, IDisposable
    {
        [Parameter]
        protected ComponentBase parent { get; set; }


        [Parameter]
        protected BsbBG bsbBG { get; set; }

        private CompBlazorScrollbar _parent;

        protected override void OnInit()
        {
            Subscribe();
            _parent = parent as CompBlazorScrollbar;
        }

        internal void Subscribe()
        {
            bsbBG.PropertyChanged = BsbBG_PropertyChanged;
        }



        protected override void OnAfterRender()
        {
           
            if (bsbBG.compBG == null)
            {
                bsbBG.compBG = this;
            }

            base.OnAfterRender();
        }

        private void BsbBG_PropertyChanged()
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
            builder.AddAttribute(k++, "onclick", EventCallback.Factory.Create<UIMouseEventArgs>(this, Clicked));

            builder.AddAttribute(k++, "onwheel", EventCallback.Factory.Create<UIWheelEventArgs>(this, OnWheel));

            builder.CloseElement();

            base.BuildRenderTree(builder);
        }

        public void OnWheel(UIWheelEventArgs e)
        {
                _parent.bsbScrollbar.CmdWhell(e.DeltaY > 0);

        }

        private void Clicked(UIMouseEventArgs e)
        {
            ClickHandler.HandleClick(e, bsbBG.BeforeOrAfter, _parent.bsbScrollbar);       
        }


        public void Dispose()
        {
           
        }
    }
}
