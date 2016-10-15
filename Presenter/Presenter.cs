using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelMVP;

namespace PresenterMVP
{
    public class Presenter
    {
        IView _view;
        IAirportModel _model;
        public Presenter(IView view)
        {
            _model = AirportModel.Create();
            _view = view;
            _view.CityHome = _model.CityHome;
            Initialize();
        }

        void Initialize()
        {
            _view.SearchFlightInfoEventRaised += SearchFlightsEventHandler;
            _view.DeleteFlightInfoEventRaised += DeleteFlightEventHandler;
            _view.InputFlightInfoEventRaised += InputFlightInfoHandler;
            _view.EditFlightInfoEventRaised += EditFlightInfoHandler;
            _view.MakePrintInfoEventRaised += MakePrintInfoHandler;
        }



        private Flight[] SearchFlightsEventHandler(Jobs task, Flight flight) => _model.SearchFlightInfo(task,flight);
        private Flight[] DeleteFlightEventHandler(Jobs task, Flight flight) => _model.DeleteFlightInfo(task, flight);
        private Flight[] InputFlightInfoHandler(Jobs task, Flight flight) => _model.InputNewFlightInfo(task, flight);
        private Flight[] EditFlightInfoHandler(Jobs task, Flight flight)  => _model.EditFlightInfo(task, flight);
        private Flight[] MakePrintInfoHandler(Jobs task, Flight flight)  => _model.MakePrintInfo(task, flight);


    }
}
