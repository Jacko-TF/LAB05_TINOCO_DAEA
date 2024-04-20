using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB04_TINOCO_DAEA.models
{
    public class Producto
    {
        public int idproducto { get; set; }
        public string nombreProducto { get; set; }

        public string cantidadPorUnidad { get; set; }

        public decimal precioUnidad { get; set; }

        public string categoriaProducto { get; set; }

        public Producto(int id, string nom, string cant, decimal pre, string cat)
        {
            this.idproducto = id;
            this.cantidadPorUnidad = cant;
            this.nombreProducto = nom;
            this.precioUnidad = pre;
            this.categoriaProducto = cat;
        }
           
    }
}
