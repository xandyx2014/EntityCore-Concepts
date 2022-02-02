﻿using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePeliculas.Entidades
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        // InverseProperty para dos relaciones con una misma clase
        [InverseProperty("Emisor")]
        public List<Mensaje> MensajesEnviados { get; set; }
        [InverseProperty("Receptor")]
        public List<Mensaje> MensajesRecibidos { get; set; }
    }
}
