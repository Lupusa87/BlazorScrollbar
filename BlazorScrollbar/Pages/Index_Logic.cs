using BlazorScrollbarComponent;
using BlazorScrollbarComponent.classes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorScrollbar.Pages
{
    public class Index_Logic : ComponentBase
    {
        public CompBlazorScrollbar CompBlazorScrollbar1;
        public CompBlazorScrollbar CompBlazorScrollbar2;

        public int P1 = 0;
        public int P2 = 0;

        public BsbSettings bsbSettings1 { get; set; } = new BsbSettings();

        public BsbSettings bsbSettings2 { get; set; } = new BsbSettings();

        protected override void OnInit()
        {

            bsbSettings2 = new BsbSettings
            {
                VerticalOrHorizontal = false,
                width = 200,
                height = 15,
                MaxValue = 10,

            };


            
            base.OnInit();
        }


        protected override void OnAfterRender()
        {
            CompBlazorScrollbar1.OnScroll += OnScroll1;
            CompBlazorScrollbar2.OnScroll += OnScroll2;

            base.OnAfterRender();
        }


        private void OnScroll1(int p)
        {
            P1 = p;
            StateHasChanged();
        }

        private void OnScroll2(int p)
        {
            P2 = p;
            StateHasChanged();
        }

    }
}
