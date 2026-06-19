using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Application.DTOs.PendingJob
{
    public class PendingJobResponseDto
    {

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; } = string.Empty;


        public string Description { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public DateTime JobDate { get; set; }

        public bool IsPaid { get; set; }







    }
}
