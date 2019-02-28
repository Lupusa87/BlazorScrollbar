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


        public bool FirtsLoad = true;

        protected override void OnInit()
        {

            bsbSettings1 = new BsbSettings("VericalScroll")
            {
                VerticalOrHorizontal = true,
                width = 15,
                height = 200,
                ScrollVisibleSize = 100,
                ScrollTotalSize = 1000,
                //bsbStyle = new BsbStyle
                //{
                //    ThumbWayColor = "lightgreen",
                //    ThumbColor = "red",
                //    ButtonColor = "green"
                //}

            };
            bsbSettings1.initialize();


            bsbSettings2 = new BsbSettings("HorizontalScroll")
            {
                VerticalOrHorizontal = false,
                width = 200,
                height = 15,
                ScrollVisibleSize = 400,
                ScrollTotalSize = 1000,
                //bsbStyle = new BsbStyle
                //{
                //    ThumbWayColor = "lightgreen",
                //    ThumbColor = "red",
                //    ButtonColor = "green"
                //}
            };
            bsbSettings2.initialize();


            base.OnInit();
        }


        protected override void OnAfterRender()
        {
            if (FirtsLoad)
            {
                FirtsLoad = false;

                CompBlazorScrollbar1.OnPositionChange = OnPositionChanged1;
                CompBlazorScrollbar2.OnPositionChange = OnPositionChanged2;

                
            }

            base.OnAfterRender();

        }


        private void OnPositionChanged1(double p)
        {
           
            P1 = (int)p;
            StateHasChanged();
        }

        private void OnPositionChanged2(double p)
        {
            P2 = (int)p;
           
            StateHasChanged();
        }

        public void Cmd1()
        {
            //P1 = 0;
            //StateHasChanged();
            //CompBlazorScrollbar1.SetScrollWidth(500);


            //CompBlazorScrollbar1.SetVisibility(true);

            CompBlazorScrollbar1.SetScrollPosition(0);
            StateHasChanged();
        }

    }
}
