using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Entities
{
    // tabla de tareas, con sus respectivos campos, como id, titulo, descripcion, fecha de vencimiento y estado de completado
    public class TaskItem
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime ExpirationDate { get; set; }

        public bool IsCompleted { get; set; }
    }
}
