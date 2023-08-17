using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    internal class LoadFlights
    {
        public List<Flight> LoadData(out bool valid)
        {
            List<Flight> flights = new List<Flight>();
            valid = true;
            String fileContent;
            try
            {
                fileContent = ReadFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                valid = false;
                return flights;
            }
            flights = FillList(fileContent);
            valid = CheckFlights(flights);

            return flights;
        }

        public string ReadFile()
        {
            string filePath = "../../../Flight.csv";

            string fileContent = File.ReadAllText(filePath);

            return fileContent;
        }

        public List<Flight> FillList(string fileContent)
        {
            List<Flight> flights = new List<Flight>();
            string[] splittedFlights = fileContent.Split('\n');
            foreach (string splitted in splittedFlights)
            {

                string[] fields = splitted.Split(',');
                int id = int.Parse(fields[0]);
                string departureAirport = fields[1];
                string arrivalAirport = fields[2];
                string departureCountry = fields[3];
                string arrivalCountry = fields[4];
                int seats = int.Parse(fields[5]);
                DateTime departureTime = DateTime.Parse(fields[6]);
                DateTime arrivalTime = DateTime.Parse(fields[7]);
                decimal price = decimal.Parse(fields[8]);
                flights.Add(new Flight(id, departureAirport, arrivalAirport, departureCountry, arrivalCountry, seats,
                departureTime, arrivalTime, price));

            }
            return flights;
        }

        public bool CheckFlights(List<Flight> flights)
        {
            List<Flight> flights1 = new List<Flight>();
            bool valid = true;
            foreach (Flight flight in flights)
            {
                valid = CkeckFlight(flight, flights1);
                flights1.Add(flight);
            }
            return valid;
        }

        public bool CkeckFlight(Flight flight, List<Flight> flights1)
        {
            FlightValidator validator = new FlightValidator();
            FlightStatus resultCode = validator.ValidFlight(flight, flights1);
            if ((resultCode & FlightStatus.Valid) != FlightStatus.Valid)
            {
                Console.WriteLine(flight.ToString());
                if (((resultCode & FlightStatus.IdReserved) == FlightStatus.IdReserved))
                {
                    Console.WriteLine("Flight id is alredy reserved");
                }
                if (((resultCode & FlightStatus.DepartureDateError) == FlightStatus.DepartureDateError))
                {
                    Console.WriteLine("Departure date is wrong or out of the possible bound");
                }
                if (((resultCode & FlightStatus.ArrivalDateError) == FlightStatus.ArrivalDateError))
                {
                    Console.WriteLine("arrival date is wrong or out of the possible bound");
                }
                if (((resultCode & FlightStatus.NumberOfSeatsOutOfBound) == FlightStatus.NumberOfSeatsOutOfBound))
                {
                    Console.WriteLine("number of seats is not in the possible bound");
                }
                if (((resultCode & FlightStatus.FlightPriceOutOfBound) == FlightStatus.FlightPriceOutOfBound))
                {
                    Console.WriteLine("Price is out of the possible price bound");
                }
                return false;
            }
            return true;
        }
    }
}
