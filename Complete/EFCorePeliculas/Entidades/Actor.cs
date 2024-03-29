﻿using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entidades
{
    // [NotMapped] This will ignore for mapped in the data base
    public class Actor
    {
        public int Id { get; set; }
        private string _nombre;
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = string.Join(' ',
                        value.Split(' ')
                        .Select(x => x[0].ToString().ToUpper() + x.Substring(1).ToLower()).ToArray());
            }

        }
        public string Biografia { get; set; }
        //[Column(TypeName = "Date")] configuracion del tipo de date como se guardara en la base de datos
        public DateTime? FechaNacimiento { get; set; }
        public HashSet<PeliculaActor> PeliculasActores { get; set; }
        public string FotoURL { get; set; }
        // no mapea la propiedad en la base de datos y esta sera ignorada
        [NotMapped]
        public int? Edad
        {
            get
            {
                if (!FechaNacimiento.HasValue)
                {
                    return null;
                }

                var fechaNacimiento = FechaNacimiento.Value;

                var edad = DateTime.Today.Year - fechaNacimiento.Year;

                if (new DateTime(DateTime.Today.Year, fechaNacimiento.Month, fechaNacimiento.Day) > DateTime.Today)
                {
                    edad--;
                }

                return edad;

            }
        }
        public Direccion DireccionHogar { get; set; }
        public Direccion BillingAddress { get; set; }
    }
}
