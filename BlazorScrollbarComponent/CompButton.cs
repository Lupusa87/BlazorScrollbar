using BlazorScrollbarComponent.classes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;


namespace BlazorScrollbarComponent
{
    internal class CompButton : ComponentBase, IDisposable
    {
        [Parameter]
        public ComponentBase parent { get; set; }


        [Parameter]
        public BsbButton bsbButton { get; set; }

        private CompBlazorScrollbar _parent;

        protected override void OnInitialized()
        {
            bsbButton.PropertyChanged = BsbButton_PropertyChanged;
            _parent = parent as CompBlazorScrollbar;

            base.OnInitialized();
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
            builder.AddAttribute(k++, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, Clicked));
            builder.CloseElement();

            base.BuildRenderTree(builder);
        }


        private void Clicked(MouseEventArgs e)
        {
            ClickHandler.HandleClick(e, bsbButton.FirstOrSecond, _parent.bsbScrollbar);
        }


        public void Dispose()
        {
           
        }
    }
}
