using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMVP
{
    public interface IAirportModel
    {
        IEnumerable<Flight> Flights { get; }
        string CityHome { get; }
        Flight[] SearchFlightInfo(Jobs task, Flight flight);
        Flight[] EditFlightInfo(Jobs task, Flight flight);
        Flight[] InputNewFlightInfo(Jobs task, Flight flight);
        Flight[] DeleteFlightInfo(Jobs task, Flight flight);
        Flight[] MakePrintInfo(Jobs taskMode, Flight temp);

    }
}
