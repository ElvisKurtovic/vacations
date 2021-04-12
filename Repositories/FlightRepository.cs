using System;
using System.Collections.Generic;
using System.Data;
using vacations.Models;
using Dapper;

namespace vacations.Repositories
{
    public class FlightRepository
    {

        public readonly IDbConnection _db;

        public FlightRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Flight> Get()
        {
            string sql = "SELECT * FROM flights;";
            return _db.Query<Flight>(sql);
        }

        internal Flight Get(int Id)
        {
            string sql = "SELECT * FROM flights WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Flight>(sql, new { Id });
        }

        internal Flight Create(Flight newFlight)
        {
            string sql = @"
      INSERT INTO flights
      (destination, price)
      VALUES
      (@Destination, @Price);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newFlight);
            newFlight.Id = id;
            return newFlight;
        }

        internal Flight Edit(Flight flightToEdit)
        {
            string sql = @"
      UPDATE flights
      SET
          destination = @Destination,
          price = @Price
      WHERE id = @Id;
      SELECT * FROM flights WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Flight>(sql, flightToEdit);

        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM flights WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}