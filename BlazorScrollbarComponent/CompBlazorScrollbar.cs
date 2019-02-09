using BlazorScrollbarComponent.classes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BlazorScrollbarComponent
{
    public class CompBlazorScrollbar: ComponentBase,IDisposable
    {
        [Parameter]
        protected BsbSettings bsbSettings { get; set; }


        public BsbScrollbar bsbScrollbar { get; set; } = new BsbScrollbar();

        public Action<int> OnScroll { get; set; }

        protected override void OnInit()
        {
            bsbScrollbar.bsbSettings = bsbSettings;
            bsbScrollbar.Initialize();


            bsbScrollbar.PropertyChanged += BsbScrollbar_PropertyChanged;
            bsbScrollbar.PositionChanged += OnPositionChanged;
            base.OnInit();
        }


        private void OnPositionChanged()
        {
            OnScroll?.Invoke((int)bsbScrollbar.Position);
        }


        private void BsbScrollbar_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            StateHasChanged();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {

            Cmd_Render(0, builder);

            base.BuildRenderTree(builder);
        }

        protected override void OnParametersSet()
        {
            
            base.OnParametersSet();
        }


        public void Cmd_Render(int k, RenderTreeBuilder builder)
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
            bsbScrollbar.PropertyChanged -= BsbScrollbar_PropertyChanged;
        }

    }
}
