﻿using System;

namespace ParkingBL.Model
{
    public class Car
    {
        public int Id { get; private set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Number { get; set; }
        public int ClientId { get; set; }
        public override string ToString()
        {
            return Convert.ToString(Id);
        }
    }
}