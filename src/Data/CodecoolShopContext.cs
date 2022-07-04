﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data
{
    public class CodecoolShopContext : DbContext
    {
        private const string ConnectionString = "Server=(LocalDb)\\MSSQLLocalDB;Database=Codecool_shop;Integrated Security=true";

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedProduct> OrderedProducts { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public CodecoolShopContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(ConnectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging();
            }

            base.OnConfiguring(optionsBuilder);
        }

    }
}