using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorScrollbarComponent
{
    public class BsbJsInterop
    {
        public static Task<bool> Alert(string msg)
        {
          
            return JSRuntime.Current.InvokeAsync<bool>(
                "BsbJsFunctions.alertmsg", msg);
        }
        public static Task<bool> HandleDrag(string elementID, DotNetObjectRef dotnetHelper)
        {
         
            return JSRuntime.Current.InvokeAsync<bool>(
                "BsbJsFunctions.handleDrag", elementID, dotnetHelper);
        }

        public static Task<bool> UnHandleDrag(string elementID)
        {
           
            return JSRuntime.Current.InvokeAsync<bool>(
                "BsbJsFunctions.unHandleDrag", elementID);
        }

        public static Task<bool> StopDrag(string elementID)
        {
          
            return JSRuntime.Current.InvokeAsync<bool>(
                "BsbJsFunctions.stopDrag", elementID);
        }

        

        //public static Task<bool> SetPointerCapture(string elementID, string pointerID)
        //{
        //    return JSRuntime.Current.InvokeAsync<bool>(
        //        "BsbJsFunctions.setCapture", elementID, pointerID);
        //}
        //public static Task<bool> releasePointerCapture(string elementID, string pointerID)
        //{
        //    return JSRuntime.Current.InvokeAsync<bool>(
        //        "BsbJsFunctions.releasePCapture", elementID, pointerID);
        //}
    }
}
