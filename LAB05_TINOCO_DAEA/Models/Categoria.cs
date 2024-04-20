using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace LAB04_TINOCO_DAEA.models
{
    public class Categoria
    {
        public int idcategoria { get; set; }
        public string nombrecategoria { get; set; }

        public string descripcion { get; set;}

        public string CodCategoria { get; set;}

        public Categoria(int id, string nom, string des, string cod)
        {
            this.idcategoria = id;
            this.nombrecategoria = nom;
            this.descripcion = des;
            this.CodCategoria = cod;
        }
    }
}
