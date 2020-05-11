using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorScrollbarComponent
{


    public class BScrollbarCJsInterop
    {
        public static IJSRuntime jsRuntime;

        internal static ValueTask<bool> Alert(IJSRuntime jsRuntime, string msg)
        {
            return jsRuntime.InvokeAsync<bool>(
                "BScrollbarCJsFunctions.alertmsg", msg);
        }

        internal static ValueTask<bool> SetPointerCapture(IJSRuntime jsRuntime, string elementID, long pointerID)
        {
            return jsRuntime.InvokeAsync<bool>(
                "BScrollbarCJsFunctions.setPCapture", elementID, pointerID);
        }
        internal static ValueTask<bool> releasePointerCapture(IJSRuntime jsRuntime, string elementID, long pointerID)
        {
            return jsRuntime.InvokeAsync<bool>(
                "BScrollbarCJsFunctions.releasePCapture", elementID, pointerID);
        }
    }
}
