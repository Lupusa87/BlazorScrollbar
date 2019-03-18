using BlazorScrollbarComponent.classes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BlazorScrollbarComponent
{
    internal class CompButton : ComponentBase, IDisposable
    {
        [Parameter]
        protected ComponentBase parent { get; set; }


        [Parameter]
        protected BsbButton bsbButton { get; set; }

        private CompBlazorScrollbar _parent;

        protected override void OnInit()
        {
            bsbButton.PropertyChanged = BsbButton_PropertyChanged;
            _parent = parent as CompBlazorScrollbar;
        }

        private void BsbButton_PropertyChanged()
        {
            StateHasChanged();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {

            int k = -1;


            builder.OpenElement(k++, "rect");
            builder.AddAttribute(k++, "x", bsbButton.x);
            builder.AddAttribute(k++, "y", bsbButton.y);
            builder.AddAttribute(k++, "width", bsbButton.width);
            builder.AddAttribute(k++, "height", bsbButton.height);
            builder.AddAttribute(k++, "fill", bsbButton.fill);
            builder.AddAttribute(k++, "onclick", EventCallback.Factory.Create<UIMouseEventArgs>(this, Clicked));
            builder.CloseElement();

            base.BuildRenderTree(builder);
        }


        private void Clicked(UIMouseEventArgs e)
        {
            ClickHandler.HandleClick(e, bsbButton.FirstOrSecond, _parent.bsbScrollbar);
        }


        public void Dispose()
        {
           
        }
    }
}
