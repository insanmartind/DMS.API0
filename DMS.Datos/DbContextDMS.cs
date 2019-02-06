using System;
using System.Collections.Generic;
using System.Text;
using DMS.Datos.Mapping.Maestros;
using DMS.Entidades.Maestros;
using Microsoft.EntityFrameworkCore;

namespace DMS.Datos
{
    public class DbContextDMS : DbContext
    {
        public DbSet<DMSLocal> DMSLocal { get; set; }
        public DbContextDMS(DbContextOptions<DbContextDMS> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DMSLocalMap());
        }
    }
}
