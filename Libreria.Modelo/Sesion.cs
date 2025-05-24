using Libreria.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Libreria.Modelo
{
    public class Sesion
    {
        [Key]
        public int Id { get; set; }
        public string Sala { get; set; }
        public DateTime Horario { get; set; }

        [ForeignKey("Evento")]
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}