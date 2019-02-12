using BlazorScrollbarComponent.classes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BlazorScrollbarComponent
{
    public class CompThumb : ComponentBase, IDisposable
    {
        [Parameter]
        protected ComponentBase parent { get; set; }


        [Parameter]
        protected BsbThumb bsbThumb { get; set; }

        public CompBlazorScrollbar _parent;


        public bool DragMode = false;

        public bool FirtLoad = true;

        protected override void OnInit()
        {

            DragMode = false;

            Subscribe();

            _parent = parent as CompBlazorScrollbar;
        }


        public void Subscribe()
        {
            bsbThumb.PropertyChanged += BsbThumb_PropertyChanged;
        }


        protected override void OnAfterRender()
        {
            if (FirtLoad)
            {

                FirtLoad = false;
                BsbJsInterop.HandleDrag(bsbThumb.id, new DotNetObjectRef(this));
            }

            if (bsbThumb.compThumb == null)
            {
                bsbThumb.compThumb = this;
            }

            base.OnAfterRender();
        }

        [JSInvokable]
        public void InvokeMoveFromJS(int x, int y)
        {
            int NewPosition;
            int NewPosition2;
            if (_parent.bsbScrollbar.bsbSettings.VerticalOrHorizontal)
            {
                NewPosition = y;
                NewPosition2 = x;
            }
            else
            {
                NewPosition = x;
                NewPosition2 = y;
            }


            if (Math.Abs(bsbThumb.PreviousPosition2 - NewPosition2) < 300)
            {
                if (bsbThumb.PreviousPosition != NewPosition)
                {
                    _parent.bsbScrollbar.ThumbMove(NewPosition - bsbThumb.PreviousPosition);
                    bsbThumb.PreviousPosition = NewPosition;
                }
            }
            else
            {
                BsbJsInterop.StopDrag(bsbThumb.id);
            }
        }

        [JSInvokable]
        public void InvokePointerDownFromJS(int x, int y)
        {

            if (_parent.bsbScrollbar.bsbSettings.VerticalOrHorizontal)
            {
                bsbThumb.PreviousPosition = y;
                bsbThumb.PreviousPosition2 = x;
            }
            else
            {
                bsbThumb.PreviousPosition = x;
                bsbThumb.PreviousPosition2 = y;
            }
        }


        private void BsbThumb_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            StateHasChanged();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
           // Console.WriteLine("BuildRenderTree thumb");

            int k = -1;


            builder.OpenElement(k++, "rect");
            builder.AddAttribute(k++, "id", bsbThumb.id);
            builder.AddAttribute(k++, "x", bsbThumb.x);
            builder.AddAttribute(k++, "y", bsbThumb.y);
            builder.AddAttribute(k++, "width", bsbThumb.width);
            builder.AddAttribute(k++, "height", bsbThumb.height);
            builder.AddAttribute(k++, "fill", bsbThumb.fill);

            //builder.AddAttribute(k++, "onmousedown", OnMouseDown);
            //builder.AddAttribute(k++, "onmousemove", OnMouseMove);

            //builder.AddAttribute(k++, "pointerdown", OnPointerDown);
            //builder.AddAttribute(k++, "pointermove", OnPointerMove);
            //builder.AddAttribute(k++, "pointerup", OnPointerUp);

            builder.AddAttribute(k++, "onwheel", OnWheel);

            builder.CloseElement();

            base.BuildRenderTree(builder);
        }


        public void OnWheel(UIWheelEventArgs e)
        {
            _parent.bsbScrollbar.CmdWhell(e.DeltaY > 0);

        }

        public void OnMouseMove(UIMouseEventArgs e)
        {
            if (e.Buttons == 1)
            {
                int NewPosition;
                if (_parent.bsbScrollbar.bsbSettings.VerticalOrHorizontal)
                {
                    NewPosition = (int)e.ClientY;
                }
                else
                {
                    NewPosition = (int)e.ClientX;
                }

                if (bsbThumb.PreviousPosition != NewPosition)
                {
                    _parent.bsbScrollbar.ThumbMove(NewPosition - bsbThumb.PreviousPosition);
                    bsbThumb.PreviousPosition = NewPosition;
                }

            }
        }

        public void OnMouseDown(UIMouseEventArgs e)
        {
            if (_parent.bsbScrollbar.bsbSettings.VerticalOrHorizontal)
            {
                bsbThumb.PreviousPosition = (int)e.ClientY;
            }
            else
            {
                bsbThumb.PreviousPosition = (int)e.ClientX;
            }
        }


        public void OnPointerMove(UIPointerEventArgs e)
        {
            if (DragMode)
            {


                if (e.Buttons == 1)
                {
                    int NewPosition;
                    if (_parent.bsbScrollbar.bsbSettings.VerticalOrHorizontal)
                    {
                        NewPosition = (int)e.ClientY;
                    }
                    else
                    {
                        NewPosition = (int)e.ClientX;
                    }

                    if (bsbThumb.PreviousPosition != NewPosition)
                    {
                        _parent.bsbScrollbar.ThumbMove(NewPosition - bsbThumb.PreviousPosition);
                        bsbThumb.PreviousPosition = NewPosition;
                    }

                }
            }
        }

        public void OnPointerDown(UIPointerEventArgs e)
        {


            //BsbJsInterop.SetPointerCapture(bsbThumb.id, e.PointerId);
            //DragMode = true;

            //if (_parent.bsbScrollbar.bsbSettings.VerticalOrHorizontal)
            //{
            //    bsbThumb.PreviousPosition = (int)e.ClientY;
            //}
            //else
            //{
            //    bsbThumb.PreviousPosition = (int)e.ClientX;
            //}
        }


        public void OnPointerUp(UIPointerEventArgs e)
        {


            //BsbJsInterop.releasePointerCapture(bsbThumb.id, e.PointerId);
            DragMode = false;
        }

        public void Dispose()
        {
          //  bsbThumb.PropertyChanged -= BsbThumb_PropertyChanged;
        }
    }
}
