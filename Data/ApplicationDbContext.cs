﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CostEstimate.Models;

namespace CostEstimate.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Options> Options { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<CostModel> CostModel { get; set; }
        public DbSet<NonConstructionItems> NonConstructionItems { get; set; }
        public DbSet<ClearingAndGrading> ClearingAndGrading { get; set; }
        public DbSet<Foundation> Foundation { get; set; }
        public DbSet<FramingAndDryIn> FramingAndDryIn { get; set; }
        public DbSet<InsulationAndSheetrock> InsulationAndSheetrock { get; set; }
        public DbSet<CabinetsAndTops> CabinetsAndTops { get; set; }

    }
}
