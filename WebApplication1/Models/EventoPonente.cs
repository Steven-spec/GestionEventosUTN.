using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEventosUTN.Models
{
    public class EventoPonente
    {
        public int EventoId { get; set; }
        public Evento Evento { get; set; }

        public int PonenteId { get; set; }
        public Ponente Ponente { get; set; }
    }
}