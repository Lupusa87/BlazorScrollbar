using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorScrollbarComponent
{
    internal class BsbJsInterop
    {
        internal static Task<bool> Alert(string msg)
        {
            return JSRuntime.Current.InvokeAsync<bool>(
                "BsbJsFunctions.alertmsg", msg);
        }

        internal static Task<bool> HandleDrag(string elementID, DotNetObjectRef dotnetHelper)
        {
            return JSRuntime.Current.InvokeAsync<bool>(
                "BsbJsFunctions.handleDrag", elementID, dotnetHelper);
        }

        internal static Task<bool> UnHandleDrag(string elementID)
        {
           
            return JSRuntime.Current.InvokeAsync<bool>(
                "BsbJsFunctions.unHandleDrag", elementID);
        }

        internal static Task<bool> StopDrag(string elementID)
        {
          
            return JSRuntime.Current.InvokeAsync<bool>(
                "BsbJsFunctions.stopDrag", elementID);
        }



        //internal static Task<bool> SetPointerCapture(string elementID, string pointerID)
        //{
        //    return JSRuntime.Current.InvokeAsync<bool>(
        //        "BsbJsFunctions.setCapture", elementID, pointerID);
        //}
        //internal static Task<bool> releasePointerCapture(string elementID, string pointerID)
        //{
        //    return JSRuntime.Current.InvokeAsync<bool>(
        //        "BsbJsFunctions.releasePCapture", elementID, pointerID);
        //}
    }
}
