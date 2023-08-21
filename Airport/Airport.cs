using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    internal class Airport
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public Airport(string name, string country, string city)
        {
            Name = name;
            Country = country;
            City = city;
        }

        public override string ToString()
        {
            return $"Airport Name: {Name}   Country: {Country}  City: {City}";
        }
    }
}
