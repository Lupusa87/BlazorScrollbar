using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorScrollbarComponent.classes
{
    internal static class ClickHandler
    {
        internal static void HandleClick(UIMouseEventArgs e, bool FirstOrSecond, BsbScrollbar bsbScrollbar)
        {
            if (e.CtrlKey)
            {
                if (FirstOrSecond)
                {
                    bsbScrollbar.ThumbMove(-10000);
                }
                else
                {
                    bsbScrollbar.ThumbMove(10000);
                }
            }
            else if (e.ShiftKey)
            {
                if (FirstOrSecond)
                {
                    bsbScrollbar.ThumbMove(-1 / bsbScrollbar.bsbSettings.ScrollScale);
                }
                else
                {
                    bsbScrollbar.ThumbMove(1 / bsbScrollbar.bsbSettings.ScrollScale);
                }
            }
            else if (e.AltKey)
            {
                if (FirstOrSecond)
                {
                    bsbScrollbar.ThumbMove(-1);
                }
                else
                {
                    bsbScrollbar.ThumbMove(1);
                }
            }
            else
            {
                if (FirstOrSecond)
                {
                    bsbScrollbar.ThumbMove(-bsbScrollbar.Step);
                }
                else
                {
                    bsbScrollbar.ThumbMove(bsbScrollbar.Step);
                }
            }


        }
    }
}
