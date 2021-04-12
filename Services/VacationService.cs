using System;
using System.Collections.Generic;
// using vacations.Interfaces;
using vacations.Models;
using vacations.Repositories;

namespace vacations.Services
{
    public class VacationService
    {
        private readonly VacationRepository _repo;

        public VacationService(VacationRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Vacation> getAll()
        {
            var data = _repo.GetAll();
            return data;
        }

        internal Vacation Delete(int id)
        {
            Vacation original = Get(id);
            _repo.Delete(id);
            return original;
        }

        internal Vacation Get(int id)
        {
            Vacation vacation = _repo.Get(id);
            if (vacation == null)
            {
                throw new Exception("invalid id");
            }
            return vacation;
        }
    }
}
