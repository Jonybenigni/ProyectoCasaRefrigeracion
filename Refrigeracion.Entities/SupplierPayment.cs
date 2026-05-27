using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Entities
{
    //tabla de pagos a proveedores, con sus respectivos campos, como id, proveedor, monto, fecha de pago y estado de pago
    public class SupplierPayment
    {
       
        public int Id { get; set; }

        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; } = null!;

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }
        public bool IsPaid { get; set; }
    }
}
