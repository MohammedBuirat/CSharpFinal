using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    internal class ManagerValidation
    {
        private void FlightSeats()
        {
            Console.WriteLine("*******************\n");
            Console.WriteLine($"Flights Max number of seats     {FlightValidator.MaxNumOfSeats}");
            Console.WriteLine($"Flights Min number of seats     {FlightValidator.MinNumOfSeats}");
            Console.WriteLine("1)Default    2)Set new value");
            string? input = Console.ReadLine();
            try
            {
                int option = int.Parse(input);
                if (option == 1)
                {
                    return;
                }
                else if (option == 2)
                {
                    int maxSeats;
                    Console.WriteLine("Please enter the new max number of seats");
                    try
                    {
                        maxSeats = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Just enter a valid number");
                        FlightSeats();
                        return;
                    }

                    int minSeats;
                    Console.WriteLine("Please enter the new min number of seats");
                    try
                    {
                        minSeats = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Just enter a valid number");
                        FlightSeats();
                        return;
                    }
                    if (maxSeats < minSeats)
                    {
                        Console.WriteLine("Max number of seats can not be less than min number of seats ");
                        FlightSeats();
                        return;
                    }
                    if (maxSeats < 0 || minSeats < 0)
                    {
                        Console.WriteLine("Max number and min number of seats can not be negative");
                        FlightSeats();
                        return;
                    }
                    FlightValidator.MinNumOfSeats = minSeats;
                    FlightValidator.MaxNumOfSeats = maxSeats;

                }
                else
                {
                    Console.WriteLine("Please enter a valid number from the previous options");
                    FlightSeats();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine("Please enter a valid number from the previous options");
                FlightSeats();
            }

        }

        private void FlightPrice()
        {
            Console.WriteLine("*******************\n");
            Console.WriteLine($"Flights Max price     {FlightValidator.MaxPrice}");
            Console.WriteLine($"Flights Min price     {FlightValidator.MinPrice}");
            Console.WriteLine("1)Default    2)Set new value");
            string? input = Console.ReadLine();
            try
            {
                int option = int.Parse(input);
                if (option == 1)
                {
                    return;
                }
                else if (option == 2)
                {
                    decimal maxPrice;
                    Console.WriteLine("Please enter the new max flight price");
                    try
                    {
                        maxPrice = decimal.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Just enter a valid number");
                        FlightPrice();
                        return;
                    }

                    decimal minPrice;
                    Console.WriteLine("Please enter the new min flight price");
                    try
                    {
                        minPrice = decimal.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Just enter a valid number");
                        FlightPrice();
                        return;
                    }
                    if (maxPrice < minPrice)
                    {
                        Console.WriteLine("Max flight price can not be less than min price of flight ");
                        FlightPrice();
                        return;
                    }
                    if (maxPrice < 0 || minPrice < 0)
                    {
                        Console.WriteLine("Max number and min number of price can not be negative");
                        FlightPrice();
                        return;
                    }
                    FlightValidator.MaxPrice = maxPrice;
                    FlightValidator.MinPrice = minPrice;

                }
                else
                {
                    Console.WriteLine("Please enter a valid number from the previous options");
                    FlightPrice();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine("Please enter a valid number from the previous options");
                FlightPrice();
            }

        }

        private void FutureYears()
        {
            Console.WriteLine("*******************\n");
            Console.WriteLine($"Flights Max Years in the future     {FlightValidator.FutureYears}");
            Console.WriteLine("1)Default    2)Set new value");
            string? input = Console.ReadLine();
            try
            {
                int option = int.Parse(input);
                if (option == 1)
                {
                    return;
                }
                else if (option == 2)
                {
                    int years;
                    Console.WriteLine("Please enter the new max flight future years");
                    try
                    {
                        years = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Just enter a valid number");
                        FutureYears();
                        return;
                    }

                    if (years < 0)
                    {
                        Console.WriteLine("Max number of future years can not be negative");
                        FutureYears();
                        return;
                    }
                    FlightValidator.FutureYears = years;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number from the previous options");
                    FutureYears();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine("Please enter a valid number from the previous options");
                FutureYears();
            }
        }

        private void ValidationConfirm()
        {
            Console.WriteLine("Current validation Conditions");
            Console.WriteLine($"Max number of seats:   {FlightValidator.MaxNumOfSeats}\n" +
                $"Min number of seats:   {FlightValidator.MinNumOfSeats}\n" +
                $"Future Years:   {FlightValidator.FutureYears}\n" +
                $"Max flight price:   {FlightValidator.MaxPrice}\n" +
                $"Min flight price:   {FlightValidator.MinPrice}");
            Console.WriteLine("*******************\n");
            Console.WriteLine("1)Confirm    2)Change the values");
            string? input = Console.ReadLine();

            try
            {
                int option = int.Parse(input);
                if (option == 1)
                {
                    return;
                }
                else if (option == 2)
                {
                    SetValidation();
                }
                else
                {
                    Console.WriteLine("Please enter a valid number from the previous options");
                    ValidationConfirm();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine("Please enter a valid number from the previous options");
                FutureYears();
            }
        }

        public void SetValidation()
        {
            Console.WriteLine("Welcome, Please enter the required validation");
            FlightSeats();
            FlightPrice();
            FutureYears();
            ValidationConfirm();
        }
    }
}