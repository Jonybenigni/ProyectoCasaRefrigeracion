using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Application.DTOs.TaskItem
{
    public class TaskItemResponseDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime ExpirationDate { get; set; }

        public bool IsCompleted { get; set; }



    }
}
