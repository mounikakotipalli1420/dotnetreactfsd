﻿using Microsoft.EntityFrameworkCore;
using ShoppingApp1.Models;

using System.Collections.Generic;
using System.Reflection.Emit;

namespace ShoppingApp1.Contexts
{
    public class ShoppingContext1 : DbContext
    {
        public ShoppingContext1(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            modelBuilder.Entity<Cart>(cart =>
            {
                cart.HasKey(ck => ck.cartNumber);
            });
            modelBuilder.Entity<CartItems>(ci =>
            {
                ci.HasKey(cik => new { cik.CartNumber, cik.Product_Id });
            });
            modelBuilder.Entity<CartItems>()
                .HasOne<Product>(ci => ci.Product)
                .WithMany(p => p.CartItems);
        }
    }
}
