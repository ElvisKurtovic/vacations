using System;
using System.Collections.Generic;
using System.Data;
using vacations.Models;
using Dapper;

namespace vacations.Repositories
{
    public class CruiseRepository
    {

        public readonly IDbConnection _db;

        public CruiseRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Cruise> Get()
        {
            string sql = "SELECT * FROM cruises;";
            return _db.Query<Cruise>(sql);
        }

        internal Cruise Get(int Id)
        {
            string sql = "SELECT * FROM cruises WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Cruise>(sql, new { Id });
        }

        internal Cruise Create(Cruise newCruise)
        {
            string sql = @"
      INSERT INTO cruises
      (description, destination, price)
      VALUES
      (@Description, @Destination, @Price);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newCruise);
            newCruise.Id = id;
            return newCruise;
        }

        internal Cruise Edit(Cruise cruiseToEdit)
        {
            string sql = @"
      UPDATE cruises
      SET
          description = @Description,
          destination = @Destination,
          price = @Price
      WHERE id = @Id;
      SELECT * FROM cruises WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Cruise>(sql, cruiseToEdit);

        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM cruises WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}