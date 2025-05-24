
using Libreria.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Modelo
{
    public class Inscripcion
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }

        public int ParticipanteId { get; set; }
        public Participante Participante { get; set; }

        public int EventoId { get; set; }
        public Evento Evento { get; set; }

        public Pago? Pago { get; set; }
        public Certificado? Certificado { get; set; }
    }
}
