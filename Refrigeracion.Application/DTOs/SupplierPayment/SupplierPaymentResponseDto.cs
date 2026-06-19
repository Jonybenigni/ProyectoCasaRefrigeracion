using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Application.DTOs.SupplierPayment
{
    public class SupplierPaymentResponseDto
    {
        public int Id { get; set; }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }
        public bool IsPaid { get; set; }



    }
}
