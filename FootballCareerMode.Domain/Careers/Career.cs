using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerMode.Domain.Careers
{
    public class Career
    {
        public Guid Id { get; }
        public string Name { get; }
        public string ClubName { get; }
        public DateTime CreatedAt { get; }

    }
}
