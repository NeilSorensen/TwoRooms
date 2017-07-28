using System;
using System.Collections.Generic;
using System.Text;

namespace TwoRooms.Domain
{
    public class TimedRound
    {
        public TimeSpan RoundLength { get; set; }
        public int HostageCount { get; set; }
    }
}
