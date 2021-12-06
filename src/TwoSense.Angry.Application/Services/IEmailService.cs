using System.Threading;
using System.Threading.Tasks;
using TwoSense.Angry.Core;

namespace TwoSense.Angry.Application.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailModel email, CancellationToken cancellationToken = default(CancellationToken));
    }
}
