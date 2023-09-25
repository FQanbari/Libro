using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Throtting;

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;


public class Throttler : IThrottler
{
    private readonly int _maxRequestsPerTwoMinutes;
    private readonly int _maxRequestsPerHour;
    private readonly ConcurrentDictionary<DateTime, int> _requestCountByMinute;
    private int _totalRequests;

    public Throttler(int maxRequestsPerTwoMinutes = 5, int maxRequestsPerHour = 10)
    {
        _maxRequestsPerTwoMinutes = maxRequestsPerTwoMinutes;
        _maxRequestsPerHour = maxRequestsPerHour;
        _requestCountByMinute = new ConcurrentDictionary<DateTime, int>();
        _totalRequests = 0;
    }

    public async Task<bool> TryGet()
    {
        var now = DateTime.UtcNow;

        // Calculate the time window for two minutes ago.
        var twoMinutesAgo = now.AddMinutes(-2);

        // Calculate the time window for one hour ago.
        var oneHourAgo = now.AddHours(-1);

        // Remove expired time windows.
        foreach (var minute in _requestCountByMinute.Keys)
        {
            if (minute < twoMinutesAgo)
            {
                _requestCountByMinute.TryRemove(minute, out _);
            }
        }

        // Check if the request limit for the last two minutes is reached.
        // Check if the request limit for the last hour is reached.
        if (_requestCountByMinute.Values.Sum() >= _maxRequestsPerTwoMinutes && _totalRequests >= _maxRequestsPerHour)
            return false;

        // Increment the request count for the current minute.
        _requestCountByMinute.AddOrUpdate(now, 1, (_, count) => count + 1);

        // Increment the total request count.
        Interlocked.Increment(ref _totalRequests);

        return true;
    }
}
