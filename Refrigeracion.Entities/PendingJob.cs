using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Refrigeracion.Entities
{

    //tabla de trabajos pendientes, con sus respectivos campos, como id, cliente, descripcion del trabajo, monto, fecha del trabajo y estado de pago
    public class PendingJob
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; } = null!;

        public string Description { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public DateTime JobDate { get; set; }

        public bool IsPaid { get; set; }

    }
}
