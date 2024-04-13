using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB05_TINOCO_DAEA.Models
{
    public class Cliente
    {
        string id {  get; set; }
        string nombreCompañia { get; set; }
        string nombreContacto {  get; set; }
        string ciudad {  get; set; }
        string pais { get; set; }

        public Cliente(string id, string nomCom, string nomCont, string ciudad, string pais) 
        {
            this.ciudad = ciudad;
            this.id = id;
            this.nombreContacto = nomCont;
            this.nombreCompañia = nomCom;
            this.pais = pais;
        }
    }
}
