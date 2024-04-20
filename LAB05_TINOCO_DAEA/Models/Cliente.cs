using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB05_TINOCO_DAEA
{
    public class Cliente
    {
        public string idCliente {  get; set; }
        public string nombreCompañia { get; set; }
        public string nombreContacto { get; set; }
        public string cargoContacto { get; set; }
        public string direccion {  get; set; }
        public string telefono {  get; set; }
        
        public Cliente (string idCliente, string nombreCompañia,
            string nombreContacto, string cargoContacto, string direccion, 
            string telefono)
        {
            this.idCliente = idCliente;
            this.nombreCompañia = nombreCompañia;
            this.nombreContacto = nombreContacto;
            this.cargoContacto = cargoContacto;
            this.direccion = direccion;
            this.telefono = telefono;
        }
    }
}
