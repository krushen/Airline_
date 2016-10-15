using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMVP
{
    public enum TicketClass
    {
        Business = 1, Economy
    }
    public struct Ticket
    {
        public TicketClass ticketClass;
        public double price;
        public Ticket(double price, TicketClass ticketClass)
        {
            this.ticketClass = ticketClass;
            this.price = price;
        }
    }

    public enum Sex
    {
        Male = 1, Female
    }
    public class Passenger:IFlighter,IComparable
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string Passport { get; set; }
        public DateTime Birthday { get; set; }
        public Sex Gender { get; set; }
        public Ticket ticket;

        public Passenger(string firstName, string lastName, string nationality, string passport, DateTime birthday, Sex sex, double price, TicketClass ticketClass)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Nationality = nationality;
            this.Passport = passport;
            this.Birthday = birthday;
            this.Gender = sex;
            this.ticket = new Ticket(price, ticketClass);
        }
        public Passenger()
        {
            FirstName = "";
            LastName = "";
            Nationality = "";
            Passport = "";
            Birthday = DateTime.Now;
            Gender = Sex.Male;
            ticket.ticketClass = TicketClass.Economy;
            ticket.price = 0;
        }
        
        public override string ToString()
        {
            string passangersString = String.Format(" {0,-10} {1,-15} {2,-8} {3,-14} {4,-12} {5, -12} {6, -8} {7,6}$", FirstName, LastName, Gender, Nationality, Passport, Birthday.ToString("dd.MM.yyyy"), ticket.ticketClass, ticket.price.ToString("#.##"));
            return passangersString;
        }

        public void PrintHeader()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Passengers");
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" FirstName: LastName:       Gender:  Nationality:   Passport:    Birthday:    Class:      Cost: ");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void PrintStringInColor()
        {
            Console.WriteLine(ToString());
        }

        public void PrintHeaderTop(bool isTrue)
        {
           
        }

        public int CompareTo(object passenger)
        {
            return LastName.CompareTo(((Passenger)passenger).LastName);
        }
    }
}
