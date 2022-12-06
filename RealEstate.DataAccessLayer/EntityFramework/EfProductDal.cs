﻿using Microsoft.EntityFrameworkCore;
using RealEstate.DataAccessLayer.Abstract;
using RealEstate.DataAccessLayer.Concrete;
using RealEstate.DataAccessLayer.Repositories;
using RealEstate.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public List<Product> GetProductByCategory()
        {
            using (var context = new Context())
            {
                return context.Products.Include(x => x.Category).ToList();
            }
        }

        public List<Product> GetProductByGuest(int id)
        {
            using (var context = new Context())
            {
                return context.Products.Where(x => x.AppUserID == id).ToList();
            }
        }
    }
}
