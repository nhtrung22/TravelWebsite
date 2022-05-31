﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelWebsite.DataAccess.DTO
{
    public class BookingDTO
    {

        public DateTime BookingFromTime { get; set; }


        public DateTime BookingToTime { get; set; }

        public int NumberOfAdult { get; set; }

        public int NumberOfKid { get; set; }

        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        public int Status { get; set; }

        public int PaymentStatus { get; set; }

        public decimal Deposit { get; set; }

        public string PhoneNumber { get; set; }

        public string FullName { get; set; }

    }
}