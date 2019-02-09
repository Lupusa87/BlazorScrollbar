using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BlazorScrollbarComponent.classes
{

    public class BsbBG : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        public bool BeforeOrAfter { get; set; } = true;

        public string id { get; set; } = null;

        public double x { get; set; } = double.NaN;
        public double y { get; set; } = double.NaN;

        public double width { get; set; } = double.NaN;
        public double height { get; set; } = double.NaN;
        public string style { get; set; } = null;
        public string fill { get; set; } = null;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        public void InvokePropertyChanged()
        {
            PropertyChanged?.Invoke(this, null);
        }

    }

}
