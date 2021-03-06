﻿using System;
using System.Collections.Generic;

namespace Proyecto_Web.Models.Domain
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            Archivo = new HashSet<Archivo>();
            Trabajadores = new HashSet<Trabajadores>();
        }

        public int Id { get; set; }
        public DateTime? FechaFin { get; set; }
        public DateTime? FechaInicio { get; set; }
        public string Nombre { get; set; }
        public string RutDirector { get; set; }

        public virtual ICollection<Archivo> Archivo { get; set; }
        public virtual ICollection<Trabajadores> Trabajadores { get; set; }
        public virtual Persona RutDirectorNavigation { get; set; }
    }
}
