using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Entities
{
    //tabla de clientes, con sus respectivos campos, como id, nombre, telefono, direccion y rfc
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string TaxId { get; set; } = string.Empty;

    }
}
