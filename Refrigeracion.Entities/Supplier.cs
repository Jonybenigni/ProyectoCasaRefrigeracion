using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Entities
{
    //tabla de proveedores, con sus respectivos campos, como id, nombre, telefono, correo, direccion y categoria
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string PhoneNumber { get; set; }= string.Empty;

        public string Mail { get; set; }=string.Empty;

        public string Address { get; set; }= string.Empty;

        public string Category { get; set; } = string.Empty;


    }
}
