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


        [Parameter]
        public Action<double> OnPositionChange { get; set; }

        protected override void OnInit()
        {
       
            bsbScrollbar.bsbSettings = bsbSettings;
            bsbScrollbar.Initialize();

            bsbScrollbar.compBlazorScrollbar = this;
            bsbScrollbar.PropertyChanged += BsbScrollbar_PropertyChanged;

            base.OnInit();
        }




        private void BsbScrollbar_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
          StateHasChanged();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {

            //Console.WriteLine("BuildRenderTree scrollbar component");

            Cmd_Render(0, builder);
 
            base.BuildRenderTree(builder);
           
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
            BsbJsInterop.UnHandleDrag(bsbScrollbar.bsbThumb.id);
            bsbScrollbar.PropertyChanged -= BsbScrollbar_PropertyChanged;
        }


        public void SetScrollTotalWidth(double w)
        {

            bsbScrollbar.bsbSettings.ScrollTotalSize = w;
            bsbScrollbar.bsbSettings.initialize();
            bsbScrollbar.Initialize();

            StateHasChanged();

        }

        public void SetScrollVisibleWidth(double w)
        {

            bsbScrollbar.bsbSettings.ScrollVisibleSize = w;
            bsbScrollbar.bsbSettings.initialize();
            bsbScrollbar.Initialize();

            StateHasChanged();

        }

    }
}
