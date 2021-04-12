using System;
using System.Collections.Generic;
using vacations.Models;
using vacations.Repositories;

namespace vacations.Services
{
    public class FlightService
    {
        private readonly FlightRepository _repo;

        public FlightService(FlightRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Flight> Get()
        {
            return _repo.Get();
        }

        internal Flight Get(int id)
        {
            Flight flight = _repo.Get(id);
            if (flight == null)
            {
                throw new Exception("invalid id");
            }
            return flight;
        }

        internal Flight Create(Flight newFlight)
        {
            return _repo.Create(newFlight);
        }
        internal Flight Edit(Flight editFlight)
        {
            Flight original = Get(editFlight.Id);


            original.Destination = editFlight.Destination != null ? editFlight.Destination : original.Destination;
            original.Price = editFlight.Price != null ? editFlight.Price : original.Price;

            return _repo.Edit(original);
        }

        internal Flight Delete(int id)
        {
            Flight original = Get(id);
            _repo.Delete(id);
            return original;
        }


    }
}