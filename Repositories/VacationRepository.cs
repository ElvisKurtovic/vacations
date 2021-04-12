using System;
using System.Collections.Generic;
using System.Data;
// using vacations.Interfaces;
using vacations.Models;
using Dapper;

namespace vacations.Repositories
{
    public class VacationRepository
    {
        private readonly IDbConnection _db;

        public VacationRepository(IDbConnection db)
        {
            _db = db;
        }
        internal IEnumerable<Vacation> GetAll()
        {
            string sql = @"SELECT 
      vacations.destination, 
      vacations.price, 
      vacations.id FROM vacations 
      UNION SELECT 
      cruises.destination, 
      cruises.price, 
      cruises.id FROM cruises
      UNION SELECT 
      flights.destination, 
      flights.price, 
      flights.id FROM flights;";
            return _db.Query<Vacation>(sql);
        }

        internal Vacation Get(int Id)
        {
            string sql = "SELECT * FROM vacations WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Vacation>(sql, new { Id });
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM vacations WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}