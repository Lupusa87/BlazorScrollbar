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


        bool FirtsLoad = true;

        protected override void OnInit()
        {

            bsbSettings2 = new BsbSettings
            {
                VerticalOrHorizontal = false,
                width = 200,
                height = 15,
                ScrollSize = 1000,

            };



            base.OnInit();
        }


        protected override void OnAfterRender()
        {
            if (FirtsLoad)
            {
                FirtsLoad = false;

                CompBlazorScrollbar1.OnPositionChange += OnPositionChanged1;
                CompBlazorScrollbar2.OnPositionChange += OnPositionChanged2;

                base.OnAfterRender();
            }

            
        }


        private void OnPositionChanged1(int p)
        {
            P1 = p;
            StateHasChanged();
        }

        private void OnPositionChanged2(int p)
        {
            P2 = p;
            StateHasChanged();
        }

        public void Cmd1()
        {
            //P1 = 0;
            //StateHasChanged();
            //CompBlazorScrollbar1.SetScrollWidth(500);


            //CompBlazorScrollbar1.SetVisibility(true);

           
        }

    }
}
