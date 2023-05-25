using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Modelos
{
    public class Plato
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Precio { get; set; }
        public bool Disponible { get; set; }

        //Relación 1-Plato => 1-Restaurante
        public int RestauranteId { get; set; }//Llave foránea
        public Restaurante? Restaurante { get; set; }
    }
}
