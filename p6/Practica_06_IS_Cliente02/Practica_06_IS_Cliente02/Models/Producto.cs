using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica_06_IS_Cliente02.Models
{
    public class Producto
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public decimal precio_unitario { get; set; }

        public bool iva { get; set; }

        public Producto()
        {
        }

        public Producto(int id, string nombre, decimal precio_unitario, bool iva)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio_unitario = precio_unitario;
            this.iva = iva;
        }
    }
}