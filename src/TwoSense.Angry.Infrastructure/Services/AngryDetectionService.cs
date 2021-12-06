using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TwoSense.Angry.Application.Services;

namespace TwoSense.Angry.Infrastructure.Services
{
    public class AngryDetectionService : IAngryDetectionService
    {
        public AngryDetectionService()
        { }

        public Task<bool> IsAngryAsync(IEnumerable<int> periods, CancellationToken cancellationToken = default)
        {
            var task = Task.Run(() =>
            {
                bool result = false;
                try
                {
                    result = periods.Max() > 400;
                }
                catch (Exception)
                {
                    //TODO: log an exception
                }


                return result;
            });

            return task;
        }
    }
}
