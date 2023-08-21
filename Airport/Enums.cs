using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    public enum FlightClass
    {
        Economy,
        Business,
        FirstClass
    }

    [Flags]
    enum FlightStatus
    {
        Valid = 0,
        IdReserved = 1,
        DepartureDateError = 2,
        ArrivalDateError = 4,
        NumberOfSeatsOutOfBound = 8,
        FlightPriceOutOfBound = 16
    }
}
