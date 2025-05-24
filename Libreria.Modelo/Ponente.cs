using Libreria.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Modelo
{
    public class Ponente
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        public ICollection<EventoPonente>? EventoPonentes { get; set; }
    }
}
