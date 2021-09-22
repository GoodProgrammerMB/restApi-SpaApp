using GP.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace GP.Tests.Utils
{
    public class TestClock : IClock
    {
        private DateTime _utcNow;

        public DateTime UtcNow => _utcNow;

        public TestClock(DateTime initDate)
        {
            _utcNow = DateTime.SpecifyKind(initDate, DateTimeKind.Utc);
        }

        public TestClock TimeTravelTo(DateTime date)
        {
            _utcNow = DateTime.SpecifyKind(date, DateTimeKind.Utc);

            return this;
        }

        public TestClock TimeForward(TimeSpan timeSpan)
        {
            _utcNow = _utcNow.Add(timeSpan);

            return this;
        }

        public TestClock SkipSeconds(int seconds)
        {
            _utcNow += TimeSpan.FromSeconds(seconds);

            return this;
        }

        public TestClock SkipMinutes(int minutes)
        {
            _utcNow += TimeSpan.FromMinutes(minutes);

            return this;
        }

        public TestClock SkipHours(int hours)
        {
            _utcNow += TimeSpan.FromHours(hours);

            return this;
        }
    }
}
