using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PresenterMVP;
using ViewMVP;

namespace MVPAirport
{
    class Program
    {
        static void Main(string[] args)
        {
            var view = new View();
            var presenter = new Presenter(view);
            view.MainMenu();
        }
        //validator - decorator pattern
    }
}
