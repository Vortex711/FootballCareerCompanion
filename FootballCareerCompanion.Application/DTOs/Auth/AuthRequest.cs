using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.DTOs.Auth
{
    public class AuthRequest
    {
        public string Email { get; init; } = null!;
        public string Password { get; init; } = null!;
    }
}
