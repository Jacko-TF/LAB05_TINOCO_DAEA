using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB05_TINOCO_DAEA.Models
{
    public class Cliente
    {
        string idCliente {  get; set; }
        string nombreCompañia { get; set; }
        string nombreContacto {  get; set; }
        string ciudad {  get; set; }
        string pais { get; set; }

        public Cliente(string id, string nomCom, string nomCont, string ciudad, string pais) 
        {
            this.idCliente = id;
            this.nombreCompañia = nomCom;
            this.nombreContacto = nomCont;
            this.ciudad = ciudad;
            this.pais = pais;
        }
    }
}
