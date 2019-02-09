using BlazorScrollbarComponent.classes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BlazorScrollbarComponent
{
    public class CompButton : ComponentBase, IDisposable
    {
        [Parameter]
        protected ComponentBase parent { get; set; }


        [Parameter]
        protected BsbButton bsbButton { get; set; }

        public CompBlazorScrollbar _parent;

        protected override void OnInit()
        {
            bsbButton.PropertyChanged += BsbButton_PropertyChanged;
            _parent = parent as CompBlazorScrollbar;
        }

        private void BsbButton_PropertyChanged(object sender, PropertyChangedEventArgs e)
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
            builder.AddAttribute(k++, "onclick", Clicked);
            builder.CloseElement();

            base.BuildRenderTree(builder);
        }


        public void Clicked(UIMouseEventArgs e)
        {

            if (bsbButton.FirstOrSecond)
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
            bsbButton.PropertyChanged -= BsbButton_PropertyChanged;
        }
    }
}
