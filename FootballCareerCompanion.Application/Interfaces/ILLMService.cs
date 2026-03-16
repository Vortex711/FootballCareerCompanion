using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCareerCompanion.Application.Interfaces
{
    public interface ILLMService
    {
        Task<string> GenerateAsync(
            string prompt,
            CancellationToken cancellationToken = default);
    }
}
