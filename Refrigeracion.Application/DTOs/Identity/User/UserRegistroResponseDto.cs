using System;
using System.Collections.Generic;
using System.Text;

namespace Refrigeracion.Application.DTOs.Identity.User
{
    public class UserRegistroResponseDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
