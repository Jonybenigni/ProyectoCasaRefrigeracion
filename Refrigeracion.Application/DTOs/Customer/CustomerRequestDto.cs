using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Application.DTOs.Customer
{
    public class CustomerRequestDto
    {

        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string TaxId { get; set; } = string.Empty;
    }
}
