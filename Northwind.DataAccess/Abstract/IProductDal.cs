﻿using Core.DataAccess;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        //Product nesnesi ile ilgili özel operasyonlar bölümü
    }
    
}
