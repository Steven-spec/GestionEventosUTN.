using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Modelos
{
    public class Certificado
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaEmision { get; set; }
        public string CodigoVerificacion { get; set; }

        public int InscripcionId { get; set; }
        public Inscripcion Inscripcion { get; set; }
    }
}