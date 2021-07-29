using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace EntityLayer.EntityFramework
{
    public class BankaContext : DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-OFJU1E2; Database=Banka; Trusted_connection=true;");
        }
  
        public Microsoft.EntityFrameworkCore.DbSet<Musteri> Musteri { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Hesap> Hesap { get; set; }



    }
}
