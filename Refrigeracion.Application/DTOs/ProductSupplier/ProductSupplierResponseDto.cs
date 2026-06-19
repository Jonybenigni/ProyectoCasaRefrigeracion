using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Application.DTOs.ProductSupplier
{
    public class ProductSupplierResponseDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty; 
        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = string.Empty; 



    }
}
