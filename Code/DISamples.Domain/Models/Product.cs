﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DISamples.Domain.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public decimal ListPrice { get; set; }
    }
}
