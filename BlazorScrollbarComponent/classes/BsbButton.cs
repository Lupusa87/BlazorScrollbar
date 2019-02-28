using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BlazorScrollbarComponent.classes
{

    internal class BsbButton : BsbBaseProps
    {


        internal bool FirstOrSecond { get; set; } = true;


        //protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}



        internal void InvokePropertyChanged()
        {
            PropertyChanged?.Invoke();
        }

    }

}
