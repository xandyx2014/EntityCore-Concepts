using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System.Collections.ObjectModel;

namespace EFCorePeliculas.Entidades
{
    public class Cine : Notificacion
    {
        public int Id { get; set; }
        private string _nombre;
        public string Nombre { get => _nombre; set => Set(value, ref _nombre); }
        // Utilizamos una libreray NetTopolySuit para ayudarnos con las ubicaciones

        private Point _ubicacion;
        public Point Ubicacion { get => _ubicacion; set => Set(value, ref _ubicacion); }
        private CineOferta _cineOferta;
        public CineOferta CineOferta { get => _cineOferta; set => Set(value, ref _cineOferta); }
        public ObservableCollection<SalaDeCine> SalasDeCine { get; set; }
        private CineDetalle _cineDetalle;
        public CineDetalle CineDetalle { get => _cineDetalle; set => Set(value, ref _cineDetalle); }
        private Direccion _direccion;
        // Esta es una propiedad Compartida donde se agrega los campos pero este modelo no es creado como una tabla
        // sino como una propiedad compartida
        // Donde se agrega a este campo las pripuiedades de 
        /*   public string Calle { get; set; }
             public string Provincia { get; set; }
             [Required]
             public string Pais { get; set; }
        */
        public Direccion Direccion { get => _direccion; set => Set(value, ref _direccion); }
    }
}
