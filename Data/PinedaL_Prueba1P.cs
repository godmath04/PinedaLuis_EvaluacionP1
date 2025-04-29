using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PinedaLuis_EvaluacionP1.Models;

    public class PinedaL_Prueba1P : DbContext
    {
        public PinedaL_Prueba1P (DbContextOptions<PinedaL_Prueba1P> options)
            : base(options)
        {
        }

        public DbSet<PinedaLuis_EvaluacionP1.Models.Cliente> Cliente { get; set; } = default!;

public DbSet<PinedaLuis_EvaluacionP1.Models.Reserva> Reserva { get; set; } = default!;
    }
