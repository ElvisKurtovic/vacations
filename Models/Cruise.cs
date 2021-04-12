using System;
using System.ComponentModel.DataAnnotations;

namespace vacations.Models
{
    public class Cruise : Vacation
    {
        public string Description { get; set; }

        // public int Price { get; set; }

        // public Flight()
        // {
        //   Category = "Flight";
        // }


    }
}