using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TwoSense.Angry.Application.Services
{
    public interface IAngryDetectionService
    {
        Task<bool> IsAngryAsync(IEnumerable<int> periods, CancellationToken cancellationToken = default(CancellationToken));
    }
}
