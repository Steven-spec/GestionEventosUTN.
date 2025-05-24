using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Modelos
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }
        public string Medio { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

        public int InscripcionId { get; set; }
        public Inscripcion Inscripcion { get; set; }
    }
}