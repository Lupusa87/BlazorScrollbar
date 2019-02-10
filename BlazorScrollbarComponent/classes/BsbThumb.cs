using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BlazorScrollbarComponent.classes
{
    public class BsbThumb : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string id { get; set; } = null;


        public double x { get; set; } = double.NaN;
        public double y { get; set; } = double.NaN;

        public double width { get; set; } = double.NaN;
        public double height { get; set; } = double.NaN;
        public string style { get; set; } = null;
        public string fill { get; set; } = null;


        public int PreviousPosition { get; set; } = 0;
        public int PreviousPosition2 { get; set; } = 0;

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
