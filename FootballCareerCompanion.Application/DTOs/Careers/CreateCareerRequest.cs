using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.DTOs.Careers
{
    public class CreateCareerRequest
    {
        public string Name { get; init; } = null!;
        public string ClubName { get; init; } = null!;
        public string ManagerName { get; init; } = null!;
    }
}
