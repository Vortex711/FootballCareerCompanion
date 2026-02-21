using FootballCareerCompanion.Domain.Careers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Domain.Users
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; } = null!;
        public string PasswordHash { get; private set; } = null!;
        public DateTime CreatedAt { get; private set; }

        private readonly List<Career> _careers = new();
        public IReadOnlyCollection<Career> Careers => _careers.AsReadOnly();
        public User(
            Guid id,
            string email,
            string passwordHash,
            DateTime createdAt)
        {
            Id = id;
            Email = email;
            PasswordHash = passwordHash;
            CreatedAt = createdAt;
        }
    }
}
