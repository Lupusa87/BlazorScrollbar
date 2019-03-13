using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BlazorScrollbarComponent.classes
{

    internal class BsbBG : BsbBaseProps
    {

        internal CompBG compBG { get; set; } = null;

        internal bool BeforeOrAfter { get; set; } = true;


        //protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}



        internal void InvokePropertyChanged()
        {
            
            if (PropertyChanged == null)
            {
                compBG.Subscribe();
            }
          
            PropertyChanged?.Invoke();
           
        }

    }

}
