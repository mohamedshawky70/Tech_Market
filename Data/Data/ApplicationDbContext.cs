﻿using Microsoft.EntityFrameworkCore;
using MyShop.Web.Models;

namespace MyShop.Web.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category>categories{ get; set; }
    }
}
