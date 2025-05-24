using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria.Modelo
{
    [Table("EVENTOS")]
    public class Evento
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public string Tipo { get; set; }

        public ICollection<Sesion>? Sesiones { get; set; }
        public ICollection<Inscripcion>? Inscripciones { get; set; }
        public ICollection<EventoPonente>? EventoPonentes { get; set; }
    }
}
