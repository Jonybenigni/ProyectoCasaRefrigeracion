using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Application.DTOs.Product
{
    public class ProductRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CurrentStock { get; set; }
        public int MinimumStock { get; set; }
        public decimal Price { get; set; }

    }
}
