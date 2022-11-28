using Microsoft.EntityFrameworkCore;
using Newspaper_Advertisement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsPaper_Advertisement.Models;

namespace NewsPaper_Advertisement.DataAccessLayer
{
    public class NewsPaperAdvertisementContext : DbContext
    {
        public NewsPaperAdvertisementContext(DbContextOptions<NewsPaperAdvertisementContext> options) : base(options) 
        { 
        
        }
        public DbSet<CustomerModel> CustomerModels { get; set; }
        public DbSet<AdminModel> AdminModels { get; set; }
        public DbSet<AdvertisementModel> AdvertisementModels { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CustomerModel>().ToTable("tbl_Customer");

            modelBuilder.Entity<AdminModel>().ToTable("tbl_Admin");

            modelBuilder.Entity<AdvertisementModel>().ToTable("tbl_Advertisements");

            modelBuilder.Entity<Feedback>().ToTable("tbl_Feedback");

            base.OnModelCreating(modelBuilder);
        }       
    }
}

