﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities.Concrete
{
    public class Cart
    {
        public Cart()
        {
            CartLines = new List<CartLine>();
        }
        public List<CartLine> CartLines { get; set; }
        public decimal Total
        {
            get { return CartLines.Sum(c => c.Product.UnitPrice * c.Quantity); }
        }
    }
}
