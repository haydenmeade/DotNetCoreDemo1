﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace vroom.Models
{
    public class Bike
    {
        public int Id { get; set; }

        public Make Make { get; set; }
        public int MakeId { get; set; }

        public Model Model { get; set; }
        public int ModelId { get; set; }

        [Required]
        public int Year { get; set; }
        [Required]
        public int Mileage { get; set; }
        public string Features { get; set; }
        [Required]
        public string SellerName { get; set; }
        [Required]
        public string SellerEmail { get; set; }
        public string SellerPhone { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Currency { get; set; }
        public string ImagePath { get; set; }

    }
}
