using System;
using System.Collections.Generic;
using vacations.Models;
using vacations.Repositories;

namespace vacations.Services
{
    public class CruiseService
    {
        private readonly CruiseRepository _repo;

        public CruiseService(CruiseRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Cruise> Get()
        {
            return _repo.Get();
        }

        internal Cruise Get(int id)
        {
            Cruise cruise = _repo.Get(id);
            if (cruise == null)
            {
                throw new Exception("invalid id");
            }
            return cruise;
        }

        internal Cruise Create(Cruise newCruise)
        {
            return _repo.Create(newCruise);
        }
        internal Cruise Edit(Cruise editCruise)
        {
            Cruise original = Get(editCruise.Id);

            original.Description = editCruise.Description != null ? editCruise.Description : original.Description;
            original.Destination = editCruise.Destination != null ? editCruise.Destination : original.Destination;
            original.Price = editCruise.Price != null ? editCruise.Price : original.Price;

            return _repo.Edit(original);
        }

        internal Cruise Delete(int id)
        {
            Cruise original = Get(id);
            _repo.Delete(id);
            return original;
        }


    }
}