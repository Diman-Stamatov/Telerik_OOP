﻿using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
using static Cosmetics.Helpers.ValidationHelper;

namespace Cosmetics.Models
{
    public class Toothpaste :Product, IProduct, IToothpaste
    {
        

        private string ingredients;
        
        public string Ingredients
        {
            get 
            { 
                return this.ingredients; 
            }
            set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Please specify the toothpaste ingredients!");
                }
                this.ingredients = value;
            }
        }        

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients) :base(name, brand, price, gender)
        {            
            this.Ingredients = ingredients;
        }
        public override string Print()
        {
            return $"#{this.Name} {this.Brand}\n" +
                $" #Price: ${this.Price}\n" +
                $" #Gender: {this.Gender}\n" +
                $" #Ingredients: {this.Ingredients}\n" +
                $" ===";

        }



    }
}
