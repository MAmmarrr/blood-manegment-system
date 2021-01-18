using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BloodBankManegmentSystem.Models
{
    public class MyDbContext:DbContext
    {
        public DbSet<Acceptors> Acceptors { get; set; }
        public DbSet<Donors> Donors { get; set; }
        public DbSet<BloodType> BloodType { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public MyDbContext()
        {

        }
    }
}