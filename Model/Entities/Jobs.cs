using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMVP
{
    public enum Jobs
    {
        DoPrintFlightsOnlyInfo,
        DoPrintFlightsAllInfo,
        DoPrintPassengersInfo,
        DoPrintFlightInfo,
        DoSearchFlighByNumber,
        DoSearchFlightByCity,
        DoSearchFlightByTimeArrival,
        DoSearchFlightByTimeDeparture,
        DosearchFlightByTimeLessHour,
        DoSearchPassengersByNumberFlight,
        DoSearchPassengerByName,
        DoSearchPassengerByLastName,
        DoSearchPassengerByPassport,
        InformationNotFound,
        DoSearchFlightByLowCost,
        DoEditFlightInfo,
        DoInputNewFlight,
        DoDeleteFlight,
        DoInputNewPassenger,
        DoDeletePassenger
    }
}
