﻿using DISamples.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DISamples.Domain.Repositories
{
    public interface ProductRepository
    {
        IEnumerable<Product> Get();
        Product Save(Product product);
    }
}
