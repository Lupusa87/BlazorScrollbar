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

        public CompBG compBG { get; set; } = null;

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
            //if (compBG == null)
            //{
            //    Console.WriteLine("compBG is null");
            //}
            //else
            //{
            //    Console.WriteLine("compBG is not null");
            //}



            if (PropertyChanged == null)
            {
                compBG.Subscribe();
            }



            //if (PropertyChanged == null)
            //{
            //    Console.WriteLine("BG is null");
            //}
            //else
            //{
            //    Console.WriteLine("BG is not null");
            //}

            PropertyChanged?.Invoke(this, null);
        }

    }

}
