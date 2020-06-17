using Microsoft.EntityFrameworkCore;
using PPAplicada1.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPAplicada1.DAL
{
    class Contexto : DbContext
    {
        public DbSet <Articulos> articulos { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\Articulos.db");
        }
    }
}
