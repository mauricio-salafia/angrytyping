using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TwoSense.Angry.Application.Services;

namespace TwoSense.Angry.Infrastructure.Services
{
    public class AngryDetectionService : IAngryDetectionService
    {
        public AngryDetectionService()
        { }

        public Task<bool> IsAngryAsync(IEnumerable<KeyValuePair<long, long>> periods, CancellationToken cancellationToken = default)
        {
            var task = Task.Run(() =>
            {
                bool result = false;
                try
                {
                    long keystrokes = 0;
                    long minutes = 0;
                    foreach (var period in periods)
                    {
                        minutes = period.Key / 60000;
                        keystrokes = period.Value;
                        if (keystrokes / minutes > 400)
                        {
                            result = true;
                            break;
                        }
                    }
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
