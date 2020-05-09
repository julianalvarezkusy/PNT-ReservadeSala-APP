using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Turnos_Sala_de_Ensayo.Reserva.Entidades;

namespace Turnos_Sala_de_Ensayo.Reserva.Datos
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
    }
}