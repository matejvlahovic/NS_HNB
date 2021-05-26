using HNB_Models;
using Microsoft.EntityFrameworkCore;
using NS_HNB_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NS_HNB_Client.DAL
{
    public class HNBContext : DbContext
    {
        public HNBContext(DbContextOptions<HNBContext> options) : base(options)
        {
        }

        public DbSet<NS_HNB_Model> Courses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<NS_HNB_Model>().ToTable("ExchangeRates").HasKey("NS_HNB_Key");
        }
    }
}
