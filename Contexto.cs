using DepositoComputadores.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepositoComputadores
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) :base(options) { }

        public DbSet<Equipamento> EQUIPAMENTOS { get; set; }
        public DbSet<Local> LOCAIS { get; set; }
    }
}
