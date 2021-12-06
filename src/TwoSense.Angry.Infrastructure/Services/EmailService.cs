using System.Threading;
using System.Threading.Tasks;
using TwoSense.Angry.Application.Services;
using TwoSense.Angry.Core;

namespace TwoSense.Angry.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(EmailModel email, CancellationToken cancellationToken = default)
        {
            //TODO: Call to real email service client
            return Task.Delay(2000);
        }
    }
}
