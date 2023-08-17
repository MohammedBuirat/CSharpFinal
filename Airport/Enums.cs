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
        Valid = 1,
        IdReserved = 2,
        DepartureDateError = 4,
        ArrivalDateError = 8,
        NumberOfSeatsOutOfBound = 16,
        FlightPriceOutOfBound = 32
    }
}