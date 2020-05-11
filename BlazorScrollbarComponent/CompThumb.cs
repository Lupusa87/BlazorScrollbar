using BlazorScrollbarComponent.classes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;


namespace BlazorScrollbarComponent
{
    public class CompThumb : ComponentBase, IDisposable
    {
        [Inject]
        private IJSRuntime jsRuntimeCurrent { get; set; }

        [Parameter]
        public ComponentBase parent { get; set; }


        [Parameter]
        public BsbThumb bsbThumb { get; set; }

        private CompBlazorScrollbar _parent;


        private bool DragMode = false;

        [Parameter]
        public bool EnableRender { get; set; } = true;



        protected override void OnInitialized()
        {
            EnableRender = true;
            DragMode = false;

            Subscribe();

            _parent = parent as CompBlazorScrollbar;

            base.OnInitialized();
        }



        protected override bool ShouldRender()
        {
            return EnableRender;
        }

        internal void Subscribe()
        {
            bsbThumb.PropertyChanged = BsbThumb_PropertyChanged;
        }


        protected override void OnAfterRender(bool firstRender)
        {
            if (bsbThumb.compThumb == null)
            {
                bsbThumb.compThumb = this;
            }

            base.OnAfterRender(firstRender);
        }

        private void BsbThumb_PropertyChanged()
        {
            Refresh();
        }


        private void Refresh()
        {
            EnableRender = true;
            StateHasChanged();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {


            if (EnableRender)
            {
               
                base.BuildRenderTree(builder);

                int k = -1;

                builder.OpenElement(k++, "rect");
                builder.AddAttribute(k++, "id", bsbThumb.id);
                builder.AddAttribute(k++, "x", bsbThumb.x);
                builder.AddAttribute(k++, "y", bsbThumb.y);
                builder.AddAttribute(k++, "width", bsbThumb.width);
                builder.AddAttribute(k++, "height", bsbThumb.height);
                builder.AddAttribute(k++, "fill", bsbThumb.fill);


                builder.AddAttribute(k++, "onpointerdown", EventCallback.Factory.Create<PointerEventArgs>(this, OnPointerDown));
                builder.AddAttribute(k++, "onpointermove", EventCallback.Factory.Create<PointerEventArgs>(this, OnPointerMove));

                builder.AddAttribute(k++, "onpointerup", EventCallback.Factory.Create<PointerEventArgs>(this, OnPointerUp));

                builder.AddEventPreventDefaultAttribute(k++, "onmousemove", true);
                //builder.AddAttribute(k++, "onmousemove", EventCallback.Factory.Create<MouseEventArgs>(this, "return false;")); //event.preventDefault()

                builder.AddAttribute(k++, "onwheel", EventCallback.Factory.Create<WheelEventArgs>(this, OnWheel));

                builder.CloseElement();

                EnableRender = false;
            }

           
        }


        private void OnWheel(WheelEventArgs e)
        {
            _parent.bsbScrollbar.CmdWhell(e.DeltaY > 0);

        }

        private void OnPointerMove(PointerEventArgs e)
        {
            if (DragMode)
            {

                if (e.Buttons == 1)
                {
                    int NewPosition;
                    int NewPosition2;
                    if (_parent.bsbScrollbar.bsbSettings.VerticalOrHorizontal)
                    {
                        NewPosition = (int)e.ClientY;
                        NewPosition2 = (int)e.ClientX;
                    }
                    else
                    {
                        NewPosition = (int)e.ClientX;
                        NewPosition2 = (int)e.ClientY;
                    }


                    if (Math.Abs(bsbThumb.PreviousPosition2 - NewPosition2) < 300) //300 is outside limit 
                    {
                        if (bsbThumb.PreviousPosition != NewPosition)
                        {
                            _parent.bsbScrollbar.ThumbMove(NewPosition - bsbThumb.PreviousPosition);
                            bsbThumb.PreviousPosition = NewPosition;
                        }
                    }
                    //else
                    //{
                    //    BsbJsInterop.StopDrag(bsbThumb.id);
                    //}

                } 
            }
        }

        private void OnPointerDown(PointerEventArgs e)
        {
            BScrollbarCJsInterop.SetPointerCapture(jsRuntimeCurrent, bsbThumb.id, e.PointerId);
            DragMode = true;

            if (_parent.bsbScrollbar.bsbSettings.VerticalOrHorizontal)
            {
                bsbThumb.PreviousPosition = (int)e.ClientY;
                bsbThumb.PreviousPosition2 = (int)e.ClientX;
            }
            else
            {
                bsbThumb.PreviousPosition = (int)e.ClientX;
                bsbThumb.PreviousPosition2 = (int)e.ClientY;
            }
        }


        private void OnPointerUp(PointerEventArgs e)
        {
            BScrollbarCJsInterop.releasePointerCapture(jsRuntimeCurrent, bsbThumb.id, e.PointerId);
            DragMode = false;
        }

        public void Dispose()
        {

        }
    }
}
