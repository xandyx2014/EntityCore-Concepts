﻿namespace EFCorePeliculas.Entidades
{
    public class CineOferta
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PorcentajeDescuento { get; set; }
        // relacion opcion que acepta null en sql
        public int? CineId { get; set; }
    }
}
