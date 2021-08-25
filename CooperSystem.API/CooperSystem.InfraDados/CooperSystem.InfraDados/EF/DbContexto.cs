
using CooperSystem.Dominio;
using CooperSystem.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CooperSystem.InfraDados.EF
{
    public class DbContexto: DbContext
    {
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        public DbContexto(DbContextOptions<DbContexto> options) : base(options) 
        {
            
        }
        
    }
}
