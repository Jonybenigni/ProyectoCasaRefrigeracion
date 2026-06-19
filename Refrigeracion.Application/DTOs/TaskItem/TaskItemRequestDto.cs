using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Application.DTOs.TaskItem
{
    public class TaskItemRequestDto
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime ExpirationDate { get; set; }

        public bool IsCompleted { get; set; }



    }
}
