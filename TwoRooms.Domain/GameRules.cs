using System;
using System.Collections.Generic;
using System.Text;

namespace TwoRooms.Domain
{
    public class GameRules
    {
        private int currentRound;
        private TimedRound[] rounds;

        public GameRules(int roundCount, int[] perRoundHostages)
        {
            rounds = new TimedRound[roundCount];
            for (int i = 0; i < roundCount; i++)
            {
                var round = new TimedRound { HostageCount = perRoundHostages[i], RoundLength = TimeSpan.FromMinutes(i + 1) };
                rounds[i] = round;
            }
            currentRound = roundCount - 1;
        }

        public bool IsFinalRound()
        {
            return currentRound == 0;
        }

        public void Advance()
        {
            currentRound--;
        }

        public TimedRound GetCurrentRound()
        {
            return rounds[currentRound];
        }
    }


}
