using BlazorScrollbarComponent.classes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;


namespace BlazorScrollbarComponent
{
    internal class CompBG : ComponentBase, IDisposable
    {
        [Parameter]
        public ComponentBase parent { get; set; }


        [Parameter]
        public BsbBG bsbBG { get; set; }

        private CompBlazorScrollbar _parent;

        protected override void OnInitialized()
        {
            Subscribe();
            _parent = parent as CompBlazorScrollbar;

            base.OnInitialized();
        }

        internal void Subscribe()
        {
            bsbBG.PropertyChanged = BsbBG_PropertyChanged;
        }



        protected override void OnAfterRender(bool firstRender)
        {
           
            if (bsbBG.compBG == null)
            {
                bsbBG.compBG = this;
            }

            base.OnAfterRender(firstRender);
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
            builder.AddAttribute(k++, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, Clicked));

            builder.AddAttribute(k++, "onwheel", EventCallback.Factory.Create<WheelEventArgs>(this, OnWheel));

            builder.CloseElement();

            base.BuildRenderTree(builder);
        }

        public void OnWheel(WheelEventArgs e)
        {
                _parent.bsbScrollbar.CmdWhell(e.DeltaY > 0);

        }

        private void Clicked(MouseEventArgs e)
        {
            ClickHandler.HandleClick(e, bsbBG.BeforeOrAfter, _parent.bsbScrollbar);       
        }


        public void Dispose()
        {
           
        }
    }
}
