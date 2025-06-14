﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repositories.Extensions
{
    public static class ProductRepositoryExtensions
    {
        public static IQueryable<Product> FilteredByCategoryId(this IQueryable<Product> products, int? categoryId)
        {
            if (categoryId is null)
                return products;
            else
                return products.Where(prd => prd.CategoryID.Equals(categoryId));
        }
        public static IQueryable<Product> FilteredBySearchTerm(this IQueryable<Product> products, String? searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return products;
            else
                return products.Where(prd => prd.ProductName.ToLower().Contains(searchTerm.ToLower()));
        }
        public static IQueryable<Product> FilteredByPrice(this IQueryable<Product> products, int minPrice, int maxPrice, bool isValidPrice)
        {
            if (isValidPrice)
                return products.Where(prd => prd.ProductPrice >= minPrice && prd.ProductPrice <= maxPrice);
            else
                return products;
        }
        public static IQueryable<Product> ToPaginate(this IQueryable<Product> products, int pageNumber, int pageSize)
        {
            return products
                .Skip(((pageNumber - 1) * pageSize))
                .Take(pageSize);
        }
    }
}