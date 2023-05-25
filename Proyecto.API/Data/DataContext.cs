using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto.Modelos;

    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Proyecto.Modelos.Plato>? Platos { get; set; } = default!;

        public DbSet<Proyecto.Modelos.Restaurante>? Restaurantes { get; set; }
    }
