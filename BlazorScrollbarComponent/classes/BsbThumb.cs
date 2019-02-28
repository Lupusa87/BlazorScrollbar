using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BlazorScrollbarComponent.classes
{
    internal class BsbThumb : BsbBaseProps
    {

        internal CompThumb compThumb { get; set; } = null;
        
        internal int PreviousPosition { get; set; } = 0;
        internal int PreviousPosition2 { get; set; } = 0;

        
        internal void InvokePropertyChanged()
        {

            if (PropertyChanged == null)
            {
                compThumb.Subscribe();
            }

            PropertyChanged?.Invoke();
        }

    }
}
