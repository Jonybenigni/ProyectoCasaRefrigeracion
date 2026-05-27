using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Entities
{
    //tabla de productos, con sus respectivos campos, como id, nombre, descripcion, stock actual, stock minimo, precio y proveedor
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CurrentStock { get; set; }
        public int MinimumStock { get; set; }
        public decimal Price { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;
    }

   
}
