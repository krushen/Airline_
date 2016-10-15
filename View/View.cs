using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresenterMVP;
using ModelMVP;

namespace ViewMVP
{
    public class View : IView
    {
        Flight flightTemp = new Flight();
        Passenger passengerTemp = new Passenger();
        public string CityHome { get; set; }
        ConsolePrint ConsoleP { get; set; }
        Flight _flight= new Flight();
        public event Action MenuEvent = null;

        public event Func<Jobs, Flight, Flight[]> SearchFlightInfoEventRaised;
        public event Func<Jobs, Flight, Flight[]> DeleteFlightInfoEventRaised;
        public event Func<Jobs, Flight, Flight[]> InputFlightInfoEventRaised;
        public event Func<Jobs, Flight, Flight[]> EditFlightInfoEventRaised;
        public event Func<Jobs, Flight, Flight[]> MakePrintInfoEventRaised;


        public void MenuEventAction()
        {
            if (MenuEvent != null) MenuEvent.Invoke();
        }
        public View()
        {
            Console.SetWindowSize(Console.LargestWindowWidth - 15, Console.LargestWindowHeight - 15);
            ConsoleP = new ConsolePrint(CityHome);
        }
 
        private Flight[] OnSearchFlightInfo(Jobs task, Flight flight)
        {
            var handler = SearchFlightInfoEventRaised;
            if (handler != null)
               return handler.Invoke(task,flight);
            return null;
        }
        private Flight[] OnDeleteFlight(Jobs task, Flight flight)
        {
            var handler = DeleteFlightInfoEventRaised;
            if (handler != null)
                return handler.Invoke(task, flight);
            return null;
        }
        private Flight[] OnInputFlightInfo(Jobs task, Flight flight)
        {
            var handler = InputFlightInfoEventRaised;
            if (handler != null)
                return handler.Invoke(task, flight);
            return null;
        }

        private Flight[] OnEditFlightInfo(Jobs task, Flight flight)
        {
            var handler = EditFlightInfoEventRaised;
            if (handler != null)
                return handler.Invoke(task, flight);
            return null;
        }

        private Flight[] OnMakePrintInfo(Jobs task, Flight flight)
        {
            var handler = MakePrintInfoEventRaised;
            if (handler != null)
                return handler.Invoke(task, flight);
            return null;
        }

        public void MainMenu()
        {
            int choisInt = 0;
            bool fl2 = true;
            bool fl = true;
            ConsoleP.CityHome = CityHome;
            DateTime dateNow = DateTime.Now;
            do
            {
                MenuEvent = null;
                string choisEnter = "";
                bool boll;
                do
                {
                    flightTemp = new Flight();
                    passengerTemp = new Passenger();
                    flightTemp.Passengers[0] = passengerTemp;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine($"Welcome to the Airport {CityHome}, Date Now is " + dateNow);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("Make one's choice:");
                    Console.WriteLine(@"
               1 FLIGHTS BOARD INFORMATION
               2 SEARCH  INFORMATION
               3 EDIT    INFORMATION
               4 INPUT   FLIGHT
               5 DELETE  FLIGHT
               6 BOOKING OFFICE FOR PASSENGERS
               7 EXIT
            ");
                    choisEnter = Console.ReadLine();
                    boll = int.TryParse(choisEnter, out choisInt);
                    if (boll)
                    {
                        if (choisInt > 7) boll = false;
                        if (choisInt < 1) boll = false;
                    };
                } while (boll != true);
                switch (choisInt)
                {
                    case 1:
                        MenuEvent += TakeInfo;
                        break;
                    case 2:
                        MenuEvent += SearchInfo;
                        break;
                    case 3:
                        MenuEvent += EditInfo;
                        break;
                    case 4:
                        MenuEvent += InputInfo;
                        break;
                    case 5:
                        MenuEvent += DeleteInfo;
                        break;
                    case 6:
                        MenuEvent += BookingOfficePassengers;
                        break;
                }
                MenuEventAction();
                if (choisInt != 7)
                {
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("For Exit Press Key [ ESCAPE ]  /  For return to Main Menu [ HOME ]");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else break;
                Console.ForegroundColor = ConsoleColor.Black;
                fl = false;
                fl2 = false;
                do
                {
                    if (Console.ReadKey().Key == ConsoleKey.Home) { fl = true; break; }
                    if (Console.ReadKey().Key == ConsoleKey.Escape) { fl2 = true; break; }

                } while ((!fl) && (!fl2));
                Console.ForegroundColor = ConsoleColor.White;
                //} while (Console.ReadKey().Key != ConsoleKey.Escape);
            } while (!fl2);

        }

        private void DeleteInfo()
        {
            
            Console.WriteLine("Enter Number of the Flight to Delete");
            int number = EnterConsoleNumber(10000);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"Searching for Flight {number} to delete");
            flightTemp.Number = number;
            Flight[] flightArray = OnSearchFlightInfo(Jobs.DoSearchFlighByNumber,flightTemp);
            if (flightArray.Length == 1)
            {
                ConsoleP.PrintInfo(Jobs.DoPrintFlightsOnlyInfo, flightArray);
                Console.WriteLine($"Do you want to delete Flight {flightArray[0].Number} [y/n]");
                string key;
                do { key = Console.ReadLine(); } while (((key[0] != 'y') || (key[0] != 'n')) & (key.Length != 1));
                if (key[0] == 'y')
                {
                    OnDeleteFlight(Jobs.DoDeleteFlight, flightArray[0]);
                    Console.WriteLine($"Flight {flightArray[0].Number} was deleting!");
                }
            }
            else ConsoleP.PrintInfo(Jobs.InformationNotFound, flightArray);
        }

        private Passenger EnterPassenger()
        {
            Console.WriteLine("Please enter FirstName:");
            string fName = MakeToUpperFirst(EnterConsoleString(2));
            Console.WriteLine("Please enter LastName:");
            string lName = MakeToUpperFirst(EnterConsoleString(2));
            Console.WriteLine("Please enter Nationality:");
            string natio = MakeToUpperFirst(EnterConsoleString(2));
            Console.WriteLine("Please enter Passport:");
            string passp = MakeToUpperAll(EnterConsoleString(5));
            Console.WriteLine("Please Enter  Birthday day: DD/MM/YYYY:");
            string date = Console.ReadLine();
            DateTime birthday;
            while (!DateTime.TryParse(date, out birthday))
            {
                Console.WriteLine("Enter correct form of Birthday day [DD/MM/YYYY]:");
                date = EnterConsoleString(10);
            }
            Console.WriteLine("Enter Sex: Male[1] / Female[2]");
            Sex sex = Sex.Male;
            int sexChoise = EnterConsoleNumber(2);
            if (sexChoise == 2) sex = Sex.Female;
            Console.WriteLine("Enter cost of the Ticket:");
            int cost = EnterConsoleNumber(10000);
            Console.WriteLine("Enter Class: Business[1] / Economy[2]");
            int clas = EnterConsoleNumber(2);
            TicketClass ticketClass = TicketClass.Economy;
            if (clas == 1) ticketClass = TicketClass.Business;
            Ticket ticket = new Ticket(cost, ticketClass);
            Passenger passenger = new Passenger(fName, lName, natio, passp, birthday, sex, ticket.price, ticket.ticketClass);
            return passenger;
        }

        private void BookingOfficePassengers()
        {
            Flight[] flightAr;
            Console.WriteLine("Do you want to buy ticket [1] / return ticket [2] / Exit [0] , make choise, please");
            int choise = EnterConsoleNumberWith0(2);
            switch (choise)
            {
                case 0: break;
                case 1:
                    Console.WriteLine("Please enter Number of the Flight");
                    int number = EnterConsoleNumber(10000);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine($"Searching for Flight {number} ...");
                    flightTemp.Number = number;
                    flightAr = OnSearchFlightInfo(Jobs.DoSearchFlighByNumber, flightTemp);

                    if (flightAr.Length == 1)
                    {
                        if (flightAr.Length > 0) ConsoleP.PrintInfo(Jobs.DoPrintFlightsAllInfo, flightAr);
                        passengerTemp = EnterPassenger();
                        flightTemp.Passengers[0] = passengerTemp;
                        flightAr = null;
                        flightAr = OnInputFlightInfo(Jobs.DoInputNewPassenger, flightTemp);
                        if (flightAr.Length > 0) ConsoleP.PrintInfo(Jobs.DoPrintFlightsAllInfo, flightAr);
                        else ConsoleP.PrintInfo(Jobs.InformationNotFound, flightAr);
                    }
                    break;
                case 2:
                    Console.WriteLine("Please enter Number of the Flight to return ticket");
                    number = EnterConsoleNumber(10000);
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine($"Searching for Flight {number} ...");
                    flightTemp.Number = number;
                    flightAr = OnSearchFlightInfo(Jobs.DoSearchFlighByNumber, flightTemp);

                    if (flightAr.Length == 1)
                    {
                        ConsoleP.PrintInfo(Jobs.DoPrintFlightsAllInfo, flightAr);
                        string passp = "";
                        do
                        {
                            Console.WriteLine("Please enter Passenger's Passpor to return ticket:");
                            passp = MakeToUpperAll(EnterConsoleString(5));
                        } while (passp.Length == 0);
                        flightTemp.Number = number;
                        passengerTemp.Passport = passp;
                        flightTemp.Passengers[0] = passengerTemp;
                        flightAr = OnInputFlightInfo(Jobs.DoDeletePassenger, flightTemp);
                        if (flightAr.Length > 0) ConsoleP.PrintInfo(Jobs.DoPrintFlightsAllInfo, flightAr);
                        else ConsoleP.PrintInfo(Jobs.InformationNotFound, flightAr);
                    }
                    break;
            }
        }

        private void InputInfo()
        {
            Console.WriteLine("Input Arrival [1]  or Departure [2] , make choise, please");
            int number = EnterConsoleNumber(2);
            Flight newFlight = InputFlightInformation(number);
            Flight[] flightArray = OnInputFlightInfo(Jobs.DoInputNewFlight, newFlight);
            if (flightArray.Length > 0) ConsoleP.PrintInfo(Jobs.DoPrintFlightsOnlyInfo, flightArray);
            else ConsoleP.PrintInfo(Jobs.InformationNotFound, flightArray);
        }

        private Flight InputFlightInformation(int choise)
        {
            Console.WriteLine("Please Enter Hour[0..23]:");
            int hour = EnterConsoleNumberWith0(23);
            Console.WriteLine("Please Enter Minute[0.59]:");
            int minute = EnterConsoleNumberWith0(59);
            DateTime dateNow = DateTime.Now;
            dateNow = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, hour, minute, 0);
            Console.WriteLine("Enter Number of Flight:");
            int number = EnterConsoleNumber(100000);
            switch (choise)
            {
                case 1:
                    Console.WriteLine("Enter city Flight is arriving from:");
                    break;
                case 2:
                    Console.WriteLine("Enter city Flight is departuring to:");
                    break;
            }
            string city = Console.ReadLine();
            city = MakeToUpperFirst(city);
            string cityA = "Empty", cityB = "Empty";
            switch (choise)
            {
                case 1:
                    cityA = city;
                    cityB = CityHome;
                    break;
                case 2:
                    cityB = city;
                    cityA = CityHome;
                    break;
            }
            Console.WriteLine("Enter Airline:");
            string airline = Console.ReadLine();
            airline = MakeToUpperFirst(airline);
            Console.WriteLine("Enter Terminal:");
            string terminal = Console.ReadLine();
            terminal = MakeToUpperFirst(terminal);
            Console.WriteLine("Enter status of the Flight:");
            Console.WriteLine(@"
               1 CheckIn
               2 GateClosed
               3 Arrived
               4 DeparturedAt
               5 Unknown
               6 Canceled
               7 ExpectedAt
               8 Delayed
               9 InFlight
              10 Gate
              11 Boarding ");
            int stat = EnterConsoleNumber(11);
            FlightStatus status = FlightStatus.Unknown;
            if ((stat > 0) && (stat <= 11))
                status = (FlightStatus)stat;

            return new Flight()
            {
                At = dateNow,
                Number = number,
                CityA = cityA,
                CityB = cityB,
                AirLine = airline,
                Terminal = terminal,
                Status = status,
            };

        }

        private void EditInfo()
        {
            Console.WriteLine("Enter Number of the Flight to changing");
            int number = EnterConsoleNumber(10000);
            flightTemp.Number = number;
            Flight[] flightArray = OnSearchFlightInfo(Jobs.DoSearchFlighByNumber, flightTemp);
            if (flightArray.Length == 1)
            {
                ConsoleP.PrintInfo(Jobs.DoPrintFlightsOnlyInfo, flightArray);
                flightTemp = flightArray[0];
                string key;
                if (flightTemp.CityB == CityHome)
                {
                    Console.WriteLine("Do you want to change City from Flight is arriving [y/n]");
                    do { key = Console.ReadLine(); } while (((key[0] != 'y') || (key[0] != 'n')) & (key.Length != 1));
                    if (key[0] == 'y')
                    {
                        Console.WriteLine("Enter city From Flight is arriving to change:");
                        string cityFrom = EnterConsoleString(2);
                        cityFrom = MakeToUpperFirst(cityFrom);
                        flightTemp.CityA = cityFrom;
                    }
                }
                if (flightTemp.CityA == CityHome)
                {
                    Console.WriteLine("Do you want to change City for Flight is departuring [y/n]");
                    do { key = Console.ReadLine(); } while (((key[0] != 'y') || (key[0] != 'n')) & (key.Length != 1));
                    if (key[0] == 'y')
                    {
                        Console.WriteLine("Enter city From Flight is arriving to change:");
                        string cityFrom = EnterConsoleString(2);
                        cityFrom = MakeToUpperFirst(cityFrom);
                        flightTemp.CityB = cityFrom;
                    }
                }
                Console.WriteLine("Do you want to change Airline [y/n]");
                do { key = Console.ReadLine(); } while (((key[0] != 'y') || (key[0] != 'n')) & (key.Length != 1));
                if (key[0] == 'y')
                {
                    Console.WriteLine("Enter new Airline to change:");
                    string airline = EnterConsoleString(2);
                    airline = MakeToUpperFirst(airline);
                    flightTemp.AirLine = airline;
                }
                Console.WriteLine("Do you want to change Terminal [y/n]");
                do { key = Console.ReadLine(); } while (((key[0] != 'y') || (key[0] != 'n')) & (key.Length != 1));
                if (key[0] == 'y')
                {
                    Console.WriteLine("Enter new Terminal to change");
                    string terminal = EnterConsoleString(1);
                    char[] terminalChar = terminal.ToCharArray();
                    for (int j = 0; j < terminalChar.Length; j++)
                    {
                        terminalChar[j] = char.ToUpper(terminalChar[j]);
                    }
                    terminal = new string(terminalChar);
                    flightTemp.Terminal = terminal;
                }

                Console.WriteLine("Do you want to change Status Flight [y/n]");
                do { key = Console.ReadLine(); } while (((key[0] != 'y') || (key[0] != 'n')) & (key.Length != 1));
                if (key[0] == 'y')
                {
                    Console.WriteLine("Enter new status of Flight:");
                    Console.WriteLine(@"
                   1 CheckIn
                   2 GateClosed
                   3 Arrived
                   4 DeparturedAt
                   5 Unknown
                   6 Canceled
                   7 ExpectedAt
                   8 Delayed
                   9 InFlight
                  10 Gate
                  11 Boarding ");
                    int stat = EnterConsoleNumber(11);
                    FlightStatus status = FlightStatus.Unknown;
                    if ((stat > 0) && (stat <= 11))
                        status = (FlightStatus)stat;
                    flightTemp.Status = status;
                }
                Flight[] flightArr = OnEditFlightInfo(Jobs.DoEditFlightInfo, flightTemp);
                ConsoleP.PrintInfo(Jobs.DoPrintFlightsOnlyInfo, flightArr);
            }
            else ConsoleP.PrintInfo(Jobs.InformationNotFound, flightArray);
        }

        private void TakeInfo()
        {
            Console.WriteLine("Do you want to take all Flights information with/or without Passengers [1/2]");
            int choise = EnterConsoleNumber(2);
            Console.WriteLine(choise);
            switch (choise)
            {
                case 1:
                    ConsoleP.PrintInfo(Jobs.DoPrintFlightsAllInfo, OnMakePrintInfo(Jobs.DoPrintFlightsAllInfo, flightTemp));
                    break;
                case 2:
                    ConsoleP.PrintInfo(Jobs.DoPrintFlightsOnlyInfo, OnMakePrintInfo(Jobs.DoPrintFlightsOnlyInfo, flightTemp));
                    break;
            }
        }

        private void SearchInfo()
        {
            Console.WriteLine("Do you want to take information about Flights /or Passengers [1/2]");
            int choise = EnterConsoleNumber(2);
            Console.WriteLine(choise);
            switch (choise)
            {
                case 1:
                    SearchFlightInfo();
                    break;
                case 2:
                    SearchPassengerInfo();
                    break;
            }
        }

        private void SearchPassengerInfo()
        {
            int choiseInt;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Make one's choice for Passengers Searching By:");
            Console.WriteLine(@"
            1 Flight Number
            2 First Name
            3 Last Name
            4 Pasport");
            choiseInt = EnterConsoleNumber(4);
            switch (choiseInt)
            {
                case 1:
                    Console.WriteLine("Enter Number of Flight:");
                    int number = EnterConsoleNumber(10000);
                    flightTemp.Number = number;
                    Flight[] flightArray =OnSearchFlightInfo(Jobs.DoSearchFlighByNumber, flightTemp);
                    if (flightArray.Length > 0) ConsoleP.PrintInfo(Jobs.DoPrintFlightsAllInfo, flightArray);
                    else ConsoleP.PrintInfo(Jobs.InformationNotFound, flightArray);
                    break;
                case 2:
                    Console.WriteLine("Enter First Name of Passenger:");
                    string name = MakeToUpperFirst(EnterConsoleString(2));
                    passengerTemp.FirstName = name;
                    flightTemp.Passengers[0] = passengerTemp;
                    Flight[] flightArrayName = OnSearchFlightInfo(Jobs.DoSearchPassengerByName, flightTemp);
                    if (flightArrayName.Length > 0) ConsoleP.PrintInfo(Jobs.DoPrintFlightsAllInfo, flightArrayName);
                    else ConsoleP.PrintInfo(Jobs.InformationNotFound, flightArrayName);
                    break;
                case 3:
                    Console.WriteLine("Enter Last Name of Passenger:");
                    string nameLast = MakeToUpperFirst(EnterConsoleString(2));
                    passengerTemp.LastName = nameLast;
                    flightTemp.Passengers[0] = passengerTemp;
                    Flight[] flightArrayLName = OnSearchFlightInfo(Jobs.DoSearchPassengerByLastName, flightTemp);
                    if (flightArrayLName.Length > 0) ConsoleP.PrintInfo(Jobs.DoPrintFlightsAllInfo, flightArrayLName);
                    else ConsoleP.PrintInfo(Jobs.InformationNotFound, flightArrayLName);
                    break;
                case 4:
                    Console.WriteLine("Enter Passport of Passenger:");
                    string pasp = MakeToUpperFirst(EnterConsoleString(5));
                    pasp = pasp.ToUpper();
                    passengerTemp.Passport = pasp;
                    flightTemp.Passengers[0] = passengerTemp;
                    Flight[] flightArrayPassp = OnSearchFlightInfo(Jobs.DoSearchPassengerByPassport, flightTemp);
                    if (flightArrayPassp.Length > 0) ConsoleP.PrintInfo(Jobs.DoPrintFlightsAllInfo, flightArrayPassp);
                    else ConsoleP.PrintInfo(Jobs.InformationNotFound, flightArrayPassp);
                    break;
            }
        }

        private void SearchFlightInfo()
        {
            int choiseInt;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Make one's choice for Flight Searching By:");
            Console.WriteLine(@"
            1 Number
            2 City
            3 Time of arrival
            4 Time of departure
            5 Flight time <1 hour 
            6 Economy Price ticket");
            choiseInt = EnterConsoleNumber(6);
            switch (choiseInt)
            {
                case 1:
                    SearchFlightByNumber();
                    break;
                case 2:
                    SearchFlightByCity();
                    break;
                case 3:
                    SearchFlightByTime("Arrival");
                    break;
                case 4:
                    SearchFlightByTime("Departure");
                    break;
                case 5:
                    SearchFlightLessHour();
                    break;
                case 6:
                    SearchFlightByEconomyPriceTicket();
                    break;
            }
        }

        private void SearchFlightByEconomyPriceTicket()
        {
            double cost = 0;
            string st = "";
            do
            {
                Console.WriteLine("Enter cost of the Flight:");
                st = Console.ReadLine();
            } while (!double.TryParse(st, out cost));
            Console.WriteLine($"Finding for Flight's ticket cost <{cost}$...");
            passengerTemp.ticket.price = cost;
            flightTemp.Passengers[0] = passengerTemp;
            Flight[] flightArray = OnSearchFlightInfo(Jobs.DoSearchFlightByLowCost, flightTemp);
            if (flightArray.Length > 0) ConsoleP.PrintInfo(Jobs.DoPrintFlightsOnlyInfo, flightArray);
            else ConsoleP.PrintInfo(Jobs.InformationNotFound, flightArray);

        }

        private void SearchFlightLessHour()
        {
            Console.WriteLine("Please Enter Hour[0..23]:");
            int hour = EnterConsoleNumberWith0(23);
            Console.WriteLine("Please Enter Minute[0.59]:");
            int minute = EnterConsoleNumberWith0(59);
            Console.WriteLine($"Hour:Minute  {hour}:{minute}");
            DateTime now = DateTime.Now;
            DateTime findDateTime = new DateTime(now.Year, now.Month, now.Day, hour, minute, 00);
            flightTemp.At = findDateTime;
            Flight[] flightArray = OnSearchFlightInfo(Jobs.DosearchFlightByTimeLessHour, flightTemp);
            if (flightArray.Length > 0) ConsoleP.PrintInfo(Jobs.DoPrintFlightsOnlyInfo, flightArray);
            else ConsoleP.PrintInfo(Jobs.InformationNotFound, flightArray);

        }

        private void SearchFlightByTime(string duration)
        {
            Console.WriteLine("Please Enter Hours[0.23]:");
            int hour = EnterConsoleNumberWith0(23);
            Console.WriteLine("Please Enter Minutes[0.59]:");
            int minute = EnterConsoleNumberWith0(59);
            DateTime now = DateTime.Now;
            DateTime findDateTime = new DateTime(now.Year, now.Month, now.Day, hour, minute, 00);
            flightTemp.At = findDateTime;
            if (duration == "Arrival")
            {
                flightTemp.CityB = CityHome;
                Flight[] flightArray = OnSearchFlightInfo(Jobs.DoSearchFlightByTimeArrival, flightTemp);
                if (flightArray.Length > 0) ConsoleP.PrintInfo(Jobs.DoPrintFlightsOnlyInfo, flightArray);
                else ConsoleP.PrintInfo(Jobs.InformationNotFound, flightArray);
            }
            if (duration == "Departure")
            {
                flightTemp.CityA = CityHome;
                Flight[] flightArray = OnSearchFlightInfo(Jobs.DoSearchFlightByTimeDeparture, flightTemp);
                if (flightArray.Length > 0) ConsoleP.PrintInfo(Jobs.DoPrintFlightsOnlyInfo, flightArray);
                else ConsoleP.PrintInfo(Jobs.InformationNotFound, flightArray);
            }
        }

        private void SearchFlightByCity()
        {
            Console.WriteLine("Enter City");
            string city = MakeToUpperFirst(Console.ReadLine());
            flightTemp.CityA = city;
            flightTemp.CityB = city;
            Flight[] flightArray = OnSearchFlightInfo(Jobs.DoSearchFlightByCity, flightTemp);
            if (flightArray.Length > 0) ConsoleP.PrintInfo(Jobs.DoPrintFlightsOnlyInfo, flightArray);
            else ConsoleP.PrintInfo(Jobs.InformationNotFound, flightArray);
        }

        private void SearchFlightByNumber()
        {
            Console.WriteLine("Enter Number of the Flight");
            int number = EnterConsoleNumber(int.MaxValue);
            flightTemp.Number = number;
            Flight[] flightArray = OnSearchFlightInfo(Jobs.DoSearchFlighByNumber, flightTemp);
            if (flightArray.Length > 0) ConsoleP.PrintInfo(Jobs.DoPrintFlightsOnlyInfo, flightArray);
            else ConsoleP.PrintInfo(Jobs.InformationNotFound, flightArray);
        }

        private int EnterConsoleNumber(int maxValue)  //1 to maxValue
        {
            string choiseEnter;
            int choiseInt = 1;
            Boolean boll = true;
            do
            {
                if (boll == false) Console.WriteLine("Make your choice correct please:");
                choiseEnter = Console.ReadLine();
                boll = int.TryParse(choiseEnter, out choiseInt);
                if (boll)
                {
                    if (choiseInt > maxValue) boll = false;
                    if (choiseInt < 1) boll = false;
                };
            } while (boll != true);
            return choiseInt;
        }
        private int EnterConsoleNumberWith0(int maxValue)  //0 to maxValue
        {
            string choiseEnter;
            int choiseInt = 0;
            Boolean boll = true;
            do
            {
                if (boll == false) Console.WriteLine("Make your choice correct please:");
                choiseEnter = Console.ReadLine();
                boll = int.TryParse(choiseEnter, out choiseInt);
                if (boll)
                {
                    if (choiseInt > maxValue) boll = false;
                    if (choiseInt < 0) boll = false;
                };
            } while (boll != true);
            return choiseInt;
        }
        private static string MakeToUpperFirst(string toupper)
        {
            char[] cityChars = toupper.ToCharArray();
            for (int j = 1; j < cityChars.Length; j++)
            {
                cityChars[j] = char.ToLower(cityChars[j]);
            }
            cityChars[0] = char.ToUpper(cityChars[0]);
            toupper = new string(cityChars);
            return toupper;
        }
        private static string MakeToUpperAll(string toupper)
        {
            char[] Chars = toupper.ToCharArray();
            for (int j = 1; j < Chars.Length; j++)
            {
                Chars[j] = char.ToUpper(Chars[j]);
            }
            Chars[0] = char.ToUpper(Chars[0]);
            toupper = new string(Chars);
            return toupper;
        }
        private string EnterConsoleString(int min)  //1 to maxValue
        {
            string choiseEnter;
            Boolean boll = false;
            do
            {
                choiseEnter = Console.ReadLine();
                if (choiseEnter.Length < min) boll = false;
                else boll = true;
                if (boll == false) Console.WriteLine("Make your choice correct please:");
            } while (boll != true);
            return choiseEnter;
        }
    }
}
