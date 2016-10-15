using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelMVP;

namespace PresenterMVP
{
    public interface IView
    {
        string CityHome { get; set; }
        event Func<Jobs, Flight, Flight[]> SearchFlightInfoEventRaised;
        event Func<Jobs, Flight, Flight[]> DeleteFlightInfoEventRaised;
        event Func<Jobs, Flight, Flight[]> InputFlightInfoEventRaised;
        event Func<Jobs, Flight, Flight[]> EditFlightInfoEventRaised;
        event Func<Jobs, Flight, Flight[]> MakePrintInfoEventRaised;
       
    }
}
