using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Application.DTOs.SupplierPayment
{
    public class SupplierPaymentRequestDto
    {

        public int SupplierId { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

        public bool IsPaid { get; set; }


    }
}
