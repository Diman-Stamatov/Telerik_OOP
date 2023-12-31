﻿using CosmeticsShop.Models;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using static CosmeticsShop.Helpers.UtilityMethods;
using CosmeticsShop.Enums;

namespace CosmeticsShop.Core
{
    public class CosmeticsRepository
    {
        private readonly List<Category> categories;
        private readonly List<Product> products;

        public CosmeticsRepository()
        {
            this.categories = new List<Category>();
            this.products = new List<Product>();
        }
        public List<Category> Categories
        {
            get
            {
                var clonedCategories = CloneCategoriesList(this.categories);
                return clonedCategories;
            }
        }
        public List<Product> Products
        {
            get
            {
                var clonedProducts = CloneProductsList(this.products);
                return clonedProducts;
            }
        }

        public void CreateCategory(string categoryName)
        {
            if (this.CategoryExist(categoryName) == true)
            {
                throw new InvalidOperationException($"A category named {categoryName} has already been created!");
            }
            this.categories.Add(new Category(categoryName));
        }

        public void CreateProduct(string name, string brand, double price, GenderType gender)
        {
            if (this.ProductExist(name) == true)
            {
                throw new InvalidOperationException($"A product named {name} has already been created!");
            }
            this.products.Add(new Product(name, brand, price, gender));
        }

        public bool CategoryExist(string name)
        {
            foreach (var category in this.categories)
            {
                if (category.Name == name)
                {
                    return true;
                }
            }

            return false;
        }

        public Category FindCategoryByName(string name)
        {
            foreach (var category in this.categories)
            {
                if (category.Name == name)
                {
                    return category;
                }
            }
            throw new InvalidOperationException($"A category named {name} does not exist!");
        }

        public bool ProductExist(string name)
        {
            foreach (var product in this.products)
            {
                if (product.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public Product FindProductByName(string name)
        {
            foreach (var product in this.products)
            {
                if (product.Name == name)
                {
                    return product;
                }
            }
            throw new InvalidOperationException($"A product named {name} does not exist!");
        }
    }
}
